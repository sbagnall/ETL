namespace SteveBagnall.Etl.Forex
{
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Etl.Specification.Abstract;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types;

	public class OneMinuteTransformationResult : ITransformationResult
	{
		public IList<OHLCV> OneMinuteData { get; set; }
		public Pair Pair { get; set; }
		public IList<FileInfo> ExtractedFiles { get; set; }

		public void CleanUp()
		{
			foreach (var file in ExtractedFiles)
			{
				File.Delete(file.FullName);
			}
		}
	}
}
