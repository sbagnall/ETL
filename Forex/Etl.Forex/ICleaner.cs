namespace SteveBagnall.Etl.Forex
{
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types.Common;
	
	public interface ICleaner
	{
		Dictionary<Pair, IList<OHLCV>> CleanToOneMinute(IList<FileInfo> files);
	}
}
