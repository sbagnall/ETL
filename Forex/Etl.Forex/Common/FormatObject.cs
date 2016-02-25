namespace SteveBagnall.Etl.Forex.Common
{
	using System;
	using SteveBagnall.Financial.FinancialTypes;

	public struct FormatObject : IEquatable<FormatObject>
	{
		public string SourceName { get; private set; }
		public DateTimeOffset DateTime { get; private set; }

		public int Year { get; private set; }
		public string ShortYear { get; private set; }
		public string LongMonth { get; private set; }
		public string MonthNumber { get; private set; }
		public string DayNumber { get; private set; }
		
		public FormatObject(
			string sourceName, 
			DateTimeOffset dateTime,
			TimeZoneInfo localTimeZone) : this()
		{
			SourceName = sourceName;
			DateTime = dateTime;

			var localDateTime = TimeZoneInfo.ConvertTime(dateTime, localTimeZone).DateTime;

			Year = localDateTime.Year;

			string strYear = localDateTime.Year.ToString();

			if (strYear.Length == 4)
			{
				ShortYear = localDateTime.Year.ToString().Substring(2, 2);
			}

			LongMonth = localDateTime.ToString("MMMM");
			MonthNumber = localDateTime.ToString("MM");
			DayNumber = localDateTime.ToString("dd");
		}

		public bool Equals(FormatObject other)
		{
			return (SourceName == other.SourceName)
				&& (DateTime == other.DateTime);
		}
	}
}
