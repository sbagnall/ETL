namespace SteveBagnall.Etl.Forex
{
	using System.Collections.Generic;
	using SteveBagnall.Etl.Forex.Common;

	public interface IFormatIterator
	{
		IEnumerable<FormatObject> GetNextCandidates(FormatObject lastFormat);
	}
}
