namespace SteveBagnall.Etl.Specification
{
	using System.Collections.Generic;

	public interface IExtracter<T>
	{
		IEnumerable<IExtractionResult<T>> Extract(T lastExtracted);
	}
}
