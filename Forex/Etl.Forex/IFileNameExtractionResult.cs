namespace SteveBagnall.Etl.Forex
{
	using System.Collections.Generic;
using SteveBagnall.Etl.Forex.Common;
using SteveBagnall.Etl.Specification;

	public interface IFileNameExtractionResult : IExtractionResult<FormatObject>
	{
		IList<string> FileFullNames { get; set; }
	}
}
