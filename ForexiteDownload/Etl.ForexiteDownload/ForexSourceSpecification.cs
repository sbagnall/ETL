namespace SteveBagnall.ScheduledTasks.ForexiteETL
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using SteveBagnall.Core.FileCompression;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types.Common;

	public class ForexiteSourceSpecification : ISourceSpecification
	{
		public string SourceName { get { return "Forexite"; } }

		/// <summary>
		/// "W. Europe Standard Time" adjusts for DST (as does the forexite data)
		/// </summary>
		public TimeZoneInfo TimeZoneInfo { get { return TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"); } }

		public DateTimeOffset FirstDateTimeOffset
		{
			get
			{
				var localDateTime = new DateTime(2001, 1, 3);
				return new DateTimeOffset(localDateTime, TimeZoneInfo.GetUtcOffset(localDateTime));
			}
		}

		public string UriFormat
		{
			get
			{
				return @"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip";
			}
		}

		public string FilenameFormat
		{
			get { return "{DayNumber}{MonthNumber}{ShortYear}.zip"; }
		}

		public Type FileCompressionHandler
		{
			get { return typeof(ZipCompression); }
		}

		public IEnumerable<Pair> GetDiscriminatingFilePairs()
		{
			yield return new Pair(Symbol.NotSet, Symbol.NotSet);
		}

		public IEnumerable<FormatObject> GetPossibleFormatObjects(DateTimeOffset utcDateTime)
		{
			yield return new FormatObject(
				SourceName,
				TimeZoneInfo.ConvertTime(utcDateTime, TimeZoneInfo).Date,
				TimeZoneInfo); // get the date only so that this represents the first data
		}

		public IEnumerable<FormatObject> GetNextPossibleFormatObjects(FormatObject lastFormatObject)
		{
			yield return new FormatObject(
				lastFormatObject.SourceName,
				lastFormatObject.DateTime.AddDays(1));
		}

		public DateTimeOffset GetUpperBoundExclusive(FormatObject formatObject)
		{
			return new DateTimeOffset(TimeZoneInfo.ConvertTime(formatObject.LocalDateTime.AddDays(1), TimeZoneInfo, TimeZoneInfo.Utc), TimeSpan.Zero);
		}

		public ParseResult Parse(string line)
		{
			try
			{
				// if header ignore
				if (line.Equals(@"<TICKER>,<DTYYYYMMDD>,<TIME>,<OPEN>,<HIGH>,<LOW>,<CLOSE>"))
				{
					return new ParseResult() { IsSuccess = false, };
				}

				string[] cols = line.Split(new char[] { ',' });

				Pair pair = new Pair(
					(Symbol)Enum.Parse(typeof(Symbol), cols[0].Substring(0, 3)),
					(Symbol)Enum.Parse(typeof(Symbol), cols[0].Substring(3, 3)));

				var lineTime = DateTime.ParseExact(
					String.Concat(cols[1], cols[2]),
					"yyyyMMddHHmmss",
					CultureInfo.InvariantCulture);

				// Forexite data labels the data for the preceding minute with the current time instead of for the following minute
				var endTime = new DateTimeOffset(lineTime, TimeZoneInfo.BaseUtcOffset);
				return new ParseResult()
				{
					IsSuccess = true,
					Data = new KeyValuePair<Pair, OHLCV>(
						pair,
						new OHLCV()
						{
							BeginDateTimeOffset = endTime.AddMinutes(-1),
							Open = Convert.ToDouble(cols[3]),
							High = Convert.ToDouble(cols[4]),
							Low = Convert.ToDouble(cols[5]),
							Close = Convert.ToDouble(cols[6]),
							Volume = 0,
							EndDateTimeOffset = endTime,
						})
				};
			}
			catch (Exception ex)
			{
				throw new ApplicationException(string.Format("Cannot parse line: {0}", line), ex);
			}
		}
	}
}
