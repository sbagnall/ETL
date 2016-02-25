namespace SteveBagnall.Etl.Forex
{
	using System.Collections.Generic;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types;

	public struct ParseResult
	{
		public bool IsSuccess;
		public KeyValuePair<Pair, OHLCV> Data;
	}
}
