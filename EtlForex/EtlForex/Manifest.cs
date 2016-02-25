namespace SteveBagnall.Etl.Forex.Extract
{
	using System;
	using System.Data;
	using System.Linq;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Extract.Abstract;
	using SteveBagnall.Persistence;
    using SteveBagnall.Persistence.Common;

	public class Manifest : IManifest
	{
		public ILocalStore LocalStore { get; set; }

		public ISourceSpecification Source { get; set; }

		public Manifest()
		{
			LocalStore = new LocalStore(string.Format("Forex.Manifest"));
		}

		public Manifest(ISourceSpecification source)
		{
			LocalStore = new LocalStore(string.Format("Forex.Manifest"));
			Source = source;
		}

		public FormatObject GetLast()
		{
			if (LocalStore.Exists(Source.SourceName))
			{
				var row = LocalStore.Read(Source.SourceName).AsEnumerable()
					.SingleOrDefault(x =>
					{
						return ((x.Field<string>("SourceName") == Source.SourceName));
					});

				if (row != null)
				{
					return new FormatObject(
						row.Field<string>("SourceName"),
						row.Field<DateTime>("LocalDateTime"));
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
			if (LocalStore.Exists(formatObject.SourceName))
			{
				var dt = LocalStore.Read(formatObject.SourceName);
				var row = dt.AsEnumerable().Single(x => 
					{
						return ((x.Field<string>("SourceName") == formatObject.SourceName));
					});
					
				UpdateRow(row, formatObject);

				LocalStore.Write(dt, true);
			}
			else
			{
				var dt = CreateDataTable(formatObject.SourceName);
				
				DataRow dr = dt.NewRow();
				UpdateRow(dr, formatObject);
				dt.Rows.Add(dr);

				LocalStore.Write(dt, false);
			}
		}

		public void Clear()
		{
			LocalStore.Delete(Source.SourceName);
		}

		private void UpdateRow(DataRow row, FormatObject formatObject)
		{
			row.SetField<string>("SourceName", formatObject.SourceName);
			row.SetField<DateTime>("LocalDateTime", formatObject.LocalDateTime);
		}

		private DataTable CreateDataTable(string name)
		{
			DataTable dt = new DataTable(name);
			dt.Columns.Add("SourceName", typeof(string));
			dt.Columns.Add("LocalDateTime", typeof(DateTime));

			return dt;
		}
	}
}
