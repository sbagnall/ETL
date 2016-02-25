namespace SteveBagnall.Etl.Forex
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Configuration;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Etl.Forex.Extract.Abstract;
	using SteveBagnall.Etl.Specification.Abstract;
	using SteveBagnall.Financial.FinancialTypes.Forex;

	public class Extracter : IExtracter<FormatObject>
    {
		public DirectoryInfo TempDownloadLocation { get; set; }

		public ISourceSpecification Source { get; set; }

		public IDownloader Downloader { get; set; }

		public Extracter()
		{ }

		public Extracter(ISourceSpecification source, IEtlForexConfig config)
		{
			Source = source;
			TempDownloadLocation = new DirectoryInfo(Path.Combine(config.RootTempFolder, "Extracter"));
			Downloader = new Downloader(source, TempDownloadLocation); 
		}

		public IEnumerable<IExtractionResult<FormatObject>> Extract(FormatObject lastExtracted)
		{
			var lastAttemptedFormat = lastExtracted;

			foreach (Pair pair in Source.GetDiscriminatingFilePairs())
			{
				if (!(TempDownloadLocation.Exists))
				{
					TempDownloadLocation.Create();
				}

				DateTimeOffset? dateUpperBoundExclusive = null;
				bool isDownloadSuccess = true;

				while ((dateUpperBoundExclusive ?? DateTimeOffset.MinValue) < DateTimeOffset.Now)
				{
					TryDownloadResult result = Downloader.TryDownload(lastAttemptedFormat);

					var previous = dateUpperBoundExclusive;
					if (previous == result.UpperBoundExclusive)
					{
						// downloader caught in a loop
						break;
					}

					dateUpperBoundExclusive = result.UpperBoundExclusive;
					isDownloadSuccess = result.IsSuccess;
					lastAttemptedFormat = result.FormatObject;

					if (result.IsSuccess)
					{
						yield return new FileNameExtractionResult()
						{
							FileFullName = result.DestinationFile.FullName,
							Pair = pair,
							CurrentPosition = result.FormatObject,
							IsSuccess = result.IsSuccess
						};
					}
				}
			}
		}
    }
}
