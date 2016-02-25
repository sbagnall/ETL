namespace SteveBagnall.Etl.Forex.Common
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Etl.Specification;

	public class Extracter : IExtracter<FormatObject>
    {
		public ISourceSpecification Source { get; set; }
		public DirectoryInfo TempDownloadLocation { get; set; }
		public IDownloadAggregator Aggregator { get; set; }
		
		public Extracter()
		{ }

		public Extracter(ISourceSpecification source, IEtlForexConfig config)
		{
			Source = source;
			TempDownloadLocation = new DirectoryInfo(Path.Combine(config.RootTempFolder, "Extracter"));
			Aggregator = new DownloadAggregator(Source, TempDownloadLocation);
		}

		public IEnumerable<IExtractionResult<FormatObject>> Extract(FormatObject lastExtracted = default(FormatObject))
		{
			if (!(TempDownloadLocation.Exists))
			{
				TempDownloadLocation.Create();
			}

			Aggregator.Initialize();

			IEnumerable<FormatObject> firstFormats;

			if (lastExtracted.Equals(default(FormatObject)))
			{
				firstFormats = Source.GetPossibleFormatObjects(Source.FirstDateTimeOffset);
			}
			else
			{
				firstFormats = new [] { lastExtracted };
			}

			foreach (var format in firstFormats)
			{
				var aggregatorResult = Aggregator.DownloadFirst(format);

				foreach (var result in ProcessResult(aggregatorResult))
				{
					yield return result;
				}

				lastExtracted = aggregatorResult.CurrentPosition;
			}

			do
			{
				var aggregatorResult = Aggregator.DownloadNext(lastExtracted);

				foreach (var result in ProcessResult(aggregatorResult))
				{
					yield return result;
				}

				lastExtracted = aggregatorResult.CurrentPosition;
			}
			while (Source.GetUpperBoundExclusive(lastExtracted) < DateTimeOffset.Now);
		}

		private IEnumerable<IExtractionResult<FormatObject>> ProcessResult(DownloadAggregatorResult result)
		{
			if (result.IsSuccess)
			{
				yield return new FileNameExtractionResult()
				{
					FileFullNames = result.DestinationFiles.Select(x => x.FullName).ToList(),
					CurrentPosition = result.CurrentPosition,
					IsSuccess = result.IsSuccess
				};
			}
		}
    }
}
