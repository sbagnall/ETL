namespace SteveBagnall.Etl.Forex.Common
{
	using System;
	using System.Data;
	using System.Linq;
	using SteveBagnall.Persistence;
	using SteveBagnall.Persistence.Common;

	public class Manifest : IManifest
	{
		private readonly string _tableName;

		public ILocalStore LocalStore { get; set; }

		public ISourceSpecification Source { get; set; }

		public Manifest()
		{
			LocalStore = new LocalStore(string.Format("Forex.Manifest"));

			_tableName = "default";
		}

		public Manifest(ISourceSpecification source)
		{
			LocalStore = new LocalStore(string.Format("Forex.Manifest"));
			Source = source;

			_tableName = Source.SourceName;
		}

		public Manifest(ISourceSpecification source, string dbSuffix)
		{
			LocalStore = new LocalStore(string.Format("Forex.Manifest"));
			Source = source;

			_tableName = string.Format("{0}_{1}", Source.SourceName, dbSuffix);
		}

		public FormatObject GetLast()
		{
			if (LocalStore.Exists(_tableName))
			{
				var row = LocalStore.Read(_tableName).AsEnumerable()
					.SingleOrDefault(x =>
					{
						return ((x.Field<string>("SourceName") == Source.SourceName));
					});

				if (row != null)
				{
					var date = row.Field<DateTime>("LocalDateTime");
					return new FormatObject(
						row.Field<string>("SourceName"),
						new DateTimeOffset(date, Source.TimeZoneInfo.GetUtcOffset(date)),
						Source.TimeZoneInfo);
				}
				else
				{
					return default(FormatObject);
				}
			}
			else
			{
				return default(FormatObject);
			}
		}

		public void Update(FormatObject formatObject)
		{
			if (LocalStore.Exists(_tableName))
			{
				var dt = LocalStore.Read(_tableName);
				var row = dt.AsEnumerable().Single(x => 
					{
						return ((x.Field<string>("SourceName") == formatObject.SourceName));
					});
					
				UpdateRow(row, formatObject);

				LocalStore.Write(dt, true);
			}
			else
			{
				var dt = CreateDataTable();
				
				DataRow dr = dt.NewRow();
				UpdateRow(dr, formatObject);
				dt.Rows.Add(dr);

				LocalStore.Write(dt, false);
			}
		}

		public void Clear()
		{
			LocalStore.Delete(_tableName);
		}

		private void UpdateRow(DataRow row, FormatObject formatObject)
		{
			row.SetField<string>("SourceName", formatObject.SourceName);
			row.SetField<DateTime>("LocalDateTime", TimeZoneInfo.ConvertTime(formatObject.DateTime, Source.TimeZoneInfo).DateTime);
		}

		private DataTable CreateDataTable()
		{
			DataTable dt = new DataTable(_tableName);
			dt.Columns.Add("SourceName", typeof(string));
			dt.Columns.Add("LocalDateTime", typeof(DateTime));

			return dt;
		}
	}
}
