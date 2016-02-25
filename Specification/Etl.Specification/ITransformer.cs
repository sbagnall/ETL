namespace SteveBagnall.Etl.Specification
{
	using System.Collections.Generic;

	public interface ITransformer<T>
	{
		IEnumerable<ITransformationResult> Transform(IExtractionResult<T> extract);
	}
}
