namespace SteveBagnall.Etl.Specification.Abstract
{
	using System.Collections.Generic;

	public interface ITransformer<T>
	{
		IEnumerable<ITransformationResult> Transform(IExtractionResult<T> extract);
	}
}
