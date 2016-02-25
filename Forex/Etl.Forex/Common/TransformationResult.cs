namespace SteveBagnall.Etl.Forex.Common
{
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Etl.Forex.Transform;
	using SteveBagnall.Etl.Specification;
	using SteveBagnall.Financial.DataAccess.Common;

	public class TransformationResult : ITransformationResult
	{
		public IEnumerable<TransformationData> Data { get; set; }
		public IList<FileInfo> ExtractedFiles { get; set; }

		public void CleanUp()
		{
			foreach (var file in ExtractedFiles)
			{
				File.Delete(file.FullName);
			}
		}

		public IEnumerable<FinancialData> ToFinancialData()
		{
			foreach (var d in Data)
			{
				yield return new FinancialData()
				{
					Period = d.Period,
					Pair = d.Pair,
					UtcOffset = d.OffsetInHours,
					Bars = d.Data
				};
			}
		}
	}
}
