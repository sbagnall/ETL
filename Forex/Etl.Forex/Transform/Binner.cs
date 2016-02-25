namespace SteveBagnall.Etl.Forex.Transform
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using SteveBagnall.Financial.Types.Common;

	public class Binner : IBinner
	{
		public Binner()
		{ }
		
		/// <inheritdoc/>
		public IList<OHLCV> Bin(IList<OHLCV> data, Periods period, TimeZoneInfo targetTimeZone, TimeSpan phase = default(TimeSpan))
		{
			if ((data == null) || (data.Count == 0) || (period == Periods.NotSet))
			{
				return new List<OHLCV>();
			}

			TimeSpan interval = PeriodIntervals.Instance[period];
			
			IList<OHLCV> binnedData = new List<OHLCV>();

			DateTime targetStartMidnight = (TimeZoneInfo.ConvertTime(data[0].BeginDateTimeOffset, targetTimeZone) + phase).Date;
			DateTimeOffset currentBinEnd = new DateTimeOffset(
				targetStartMidnight,
				targetTimeZone.GetUtcOffset(targetStartMidnight));

			DateTimeOffset currentBinStart;
			OHLCV ohlcv = default(OHLCV);

			var lastDate = TimeZoneInfo.ConvertTime(data.Last().EndDateTimeOffset, targetTimeZone) + phase;

			foreach (var d in data)
			{
				DateTimeOffset dataStartDateTime = TimeZoneInfo.ConvertTime(d.BeginDateTimeOffset, targetTimeZone) + phase;

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

					// do not bin beyond the source data (i.e. don't create partial bins
					if (currentBinEnd > lastDate)
					{
						break;
					}

					currentBinStart = currentBinEnd - interval;

					// open a new one
					ohlcv = new OHLCV(
						currentBinStart - phase,
						d.Open,
						0,
						currentBinEnd - phase);

					ohlcv.Open = d.Open;
				}
					
				// update bin values
				ohlcv.AddData(d);

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
