namespace SteveBagnall.Etl.Forex.Transform.Abstract
{
	using System;
	using System.Collections.Generic;
	using SteveBagnall.Financial.Types;

	public interface IBinner
	{
		IList<OHLCV> Bin(IList<OHLCV> data, Periods period, TimeZoneInfo timeZone);
	}
}
