namespace SteveBagnall.Etl.Forex.Transform.Abstract
{
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types;
	
	public interface ICleaner
	{
		Dictionary<Pair, IList<OHLCV>> CleanToOneMinute(List<FileInfo> files);
	}
}
