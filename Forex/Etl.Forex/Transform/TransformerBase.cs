namespace SteveBagnall.Etl.Forex.Transform
{
	using System.Collections.Generic;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Etl.Specification;

	public abstract class TransformerBase : ITransformer<FormatObject>
	{
		public abstract IEnumerable<ITransformationResult> TransformFileExtract(IFileNameExtractionResult fileNameExtract);

		public IEnumerable<ITransformationResult> Transform(IExtractionResult<FormatObject> extract)
		{
			return TransformFileExtract(extract as IFileNameExtractionResult);
		}
	}
}
