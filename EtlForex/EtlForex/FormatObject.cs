namespace SteveBagnall.Etl.Forex
{
	using System;
	using SteveBagnall.Financial.FinancialTypes;

	public struct FormatObject : IEquatable<FormatObject>
	{
		public string SourceName { get; private set; }
		public DateTime LocalDateTime { get; private set; }

		public int Year { get; private set; }
		public string ShortYear { get; private set; }
		public string LongMonth { get; private set; }
		public string MonthNumber { get; private set; }
		public string DayNumber { get; private set; }
		
		public FormatObject(
			string sourceName, 
			DateTime dateTime) : this()
		{
			SourceName = sourceName;
			LocalDateTime = dateTime;

			Year = dateTime.Year;

			string strYear = dateTime.Year.ToString();

			if (strYear.Length == 4)
			{
				ShortYear = dateTime.Year.ToString().Substring(2, 2);
			}

			LongMonth = dateTime.ToString("MMMM");
			MonthNumber = dateTime.ToString("MM");
			DayNumber = dateTime.ToString("dd");
		}

		public bool Equals(FormatObject other)
		{
			return (SourceName == other.SourceName)
				&& (LocalDateTime == other.LocalDateTime);
		}
	}
}
