namespace SteveBagnall.Etl.Forex.Transform
{
	using System.Collections.Generic;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types.Common;

	public struct TransformationData
	{
		public Periods Period { get; set; }
		public Pair Pair { get; set; }
		public int OffsetInHours { get; set; }
		public IList<OHLCV> Data { get; set; }
	}
}
