namespace SteveBagnall.Etl.Forex.Common
{
	using System.Collections.Generic;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types.Common;

	public struct ParseResult
	{
		public bool IsSuccess;
		public KeyValuePair<Pair, OHLCV> Data;
	}
}
