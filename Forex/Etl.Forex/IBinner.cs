namespace SteveBagnall.Etl.Forex
{
	using System;
	using System.Collections.Generic;
	using SteveBagnall.Financial.Types.Common;

	public interface IBinner
	{
		/// <summary>
		/// Bins <paramref name="data"/> into the <paramref name="targetTimeZone"/> with bins starting at midnight 
		/// in the target time zone after the time has been adjustment by <paramref name="phase"/> if applicable.
		/// <remarks>
		/// Does not produce bins where the source data does not provide enough information to guarantee that the
		/// bin can be filled completely, i.e. if the source data is one minute data that extends until 23:30 UTC
		/// and the target period is hourly and the target time zone is UTC, then the bins will be returned minus
		/// the last bin, even though half an hours worth of data would fit into that bin.
		/// </remarks>
		/// </summary>
		/// <param name="data">The data to bin</param>
		/// <param name="period">The size of the bins created</param>
		/// <param name="targetTimeZone">The time zone into which the data will be binned</param>
		/// <param name="phase">An offset which will be applied before the bins locations in time are calculated</param>
		/// <returns></returns>
		IList<OHLCV> Bin(IList<OHLCV> data, Periods period, TimeZoneInfo timeZone, TimeSpan offset = default(TimeSpan));
	}
}
