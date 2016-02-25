namespace SteveBagnall.Etl.Forex.Transform
{
	using System;
	using System.Collections.Generic;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Transform.Abstract;
	using SteveBagnall.Financial.Types;

	public class Binner : IBinner
	{
		public static Dictionary<Periods, TimeSpan> PeriodIntervals = new Dictionary<Periods, TimeSpan>()
		{
			{ Periods.OneMinute, new TimeSpan(0, 0, 1, 0) },
			{ Periods.ThreeMinutes, new TimeSpan(0, 0, 3, 0) },
			{ Periods.FiveMinutes, new TimeSpan(0, 0, 5, 0) },
			{ Periods.TenMinutes, new TimeSpan(0, 0, 10, 0) },
			{ Periods.FifteenMinutes, new TimeSpan(0, 0, 15, 0) },
			{ Periods.ThirtyMinutes, new TimeSpan(0, 0, 30, 0) },
			{ Periods.FortyFiveMinutes, new TimeSpan(0, 0, 45, 0) },
			{ Periods.SixtyMinutes, new TimeSpan(0, 1, 0, 0) },
			{ Periods.NinetyMinutes, new TimeSpan(0, 1, 30, 0) },
			{ Periods.OneTwentyMinutes, new TimeSpan(0, 2, 0, 0) },
			{ Periods.TwoFortyMinutes, new TimeSpan(0, 4, 0, 0) },
			{ Periods.Daily, new TimeSpan(1, 0, 0, 0) },
		};

		ISourceSpecification Source { get; set; }

		public Binner()
		{ }

		public Binner(ISourceSpecification source)
		{
			Source = source;
		}

		public IList<OHLCV> Bin(IList<OHLCV> data, Periods period, TimeZoneInfo targetTimeZone)
		{
			if ((data == null) || (data.Count == 0) || (period == Periods.NotSet))
			{
				return new List<OHLCV>();
			}

			TimeSpan interval = PeriodIntervals[period];
			
			IList<OHLCV> binnedData = new List<OHLCV>();

			var sourceStartDate = new DateTimeOffset(
				TimeZoneInfo.ConvertTime(data[0].BeginDateTimeOffset, Source.TimeZoneInfo).Date + Source.DataStartTime,
				Source.TimeZoneInfo.BaseUtcOffset);

			// go back an entire day to ensure that the time zone differences between source and target are defo taken into account
			var currentBinEnd = TimeZoneInfo.ConvertTime(sourceStartDate, targetTimeZone).AddDays(-1);

			DateTimeOffset currentBinStart;
			OHLCV ohlcv = default(OHLCV);

			foreach (var d in data)
			{
				DateTimeOffset dataStartDateTime = TimeZoneInfo.ConvertTime(d.BeginDateTimeOffset, targetTimeZone);

				// if new bin add the current value, move bin to correct location and open a new one
				if (currentBinEnd <= dataStartDateTime)
				{
					// add the current value
					if (!(ohlcv.Equals(default(OHLCV))))
					{
						binnedData.Add(ohlcv);
					}
					
					// move bin to correct location
					while (currentBinEnd <= dataStartDateTime)
					{
						currentBinEnd += interval;
					}

					currentBinStart = currentBinEnd - interval;

					// open a new one
					ohlcv = new OHLCV(
						currentBinStart ,
						0.0, 
						double.MinValue, 
						double.MaxValue, 
						0.0, 
						0,
						currentBinEnd);

					ohlcv.Open = d.Open;
				}
					
				// update bin values
				ohlcv.High = (d.High > ohlcv.High) ? d.High : ohlcv.High;
				ohlcv.Low = (d.Low < ohlcv.Low) ? d.Low : ohlcv.Low;
				ohlcv.Close = d.Close;
				ohlcv.Volume += d.Volume;

				// if this is the last data then add the current bin
				if (d.Equals(data[data.Count - 1]))
				{
					binnedData.Add(ohlcv);
				}
			}
			
			return binnedData;
		}
	}
}
