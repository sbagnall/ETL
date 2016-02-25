namespace SteveBagnall.Etl.Forex.Extract.Abstract
{
	using System.Collections.Generic;
	using SteveBagnall.Financial.FinancialTypes;

	public interface IFormatIterator
	{
		IEnumerable<FormatObject> GetNextCandidates(FormatObject lastFormat);
	}
}
