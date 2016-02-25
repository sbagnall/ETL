namespace SteveBagnall.Etl.Forex.Extract
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Etl.Forex.Common;

	public class DownloadAggregator : IDownloadAggregator
	{
		public int NumberOfFilesToAggregate { get; set; }
		public ISourceSpecification Source { get; set; }
		public IFormatIterator FormatIterator { get; set; }
		public IDownloader Downloader { get; set; }

		public Queue<Tuple<FormatObject, FileInfo>> CurrentAggregatedFiles { get; set; }

		public DownloadAggregator()
		{
			NumberOfFilesToAggregate = 1;

			if ((Source != null) && (Source.NumberOfFilesToAggregate > 0))
			{
				NumberOfFilesToAggregate = Source.NumberOfFilesToAggregate;
			}

			CurrentAggregatedFiles = new Queue<Tuple<FormatObject, FileInfo>>();
		}

		public DownloadAggregator(ISourceSpecification source, DirectoryInfo downloadLocation)
			: this()
		{
			Source = source;
			FormatIterator = new ContinuousFormatIterator(source);
			Downloader = new Downloader(source, downloadLocation);
		}

		public void Initialize()
		{
			if (NumberOfFilesToAggregate == 0)
			{
				throw new ApplicationException("Must specify number of files to aggregate.");
			}

			if (FormatIterator == null)
			{
				throw new ApplicationException("Must setup a format iterator.");
			}

			if (Downloader == null)
			{
				throw new ApplicationException("Must setup a downloader.");
			}

			CurrentAggregatedFiles = new Queue<Tuple<FormatObject, FileInfo>>();
		}

		public DownloadAggregatorResult DownloadFirst(FormatObject lastDownloadedFormat)
		{
			var aggregateResult = new DownloadAggregatorResult()
			{
				IsSuccess = false,
				CurrentPosition = lastDownloadedFormat,
			};

			var result = Downloader.TryDownload(lastDownloadedFormat);

			if (result.IsSuccess)
			{
				aggregateResult.CurrentPosition = lastDownloadedFormat;

				if (!(CurrentAggregatedFiles.Any(x => x.Item2 == result.DestinationFile)))
				{
					CurrentAggregatedFiles.Enqueue(Tuple.Create(lastDownloadedFormat, result.DestinationFile));

					if (CurrentAggregatedFiles.Count > NumberOfFilesToAggregate)
					{
						CurrentAggregatedFiles.Dequeue();
					}

					if (CurrentAggregatedFiles.Count == NumberOfFilesToAggregate)
					{
						aggregateResult.IsSuccess = true;
						aggregateResult.DestinationFiles = CurrentAggregatedFiles.Select(x => x.Item2).ToArray();
						CurrentAggregatedFiles.Dequeue();
					}
				}
			}

			return aggregateResult;
		}

		public DownloadAggregatorResult DownloadNext(FormatObject lastDownloadedFormat)
		{
			var aggregateResult = new DownloadAggregatorResult() 
			{ 
				IsSuccess = false,
				CurrentPosition = lastDownloadedFormat,
			};

			foreach (var formatObject in FormatIterator.GetNextCandidates(lastDownloadedFormat))
			{
				aggregateResult.CurrentPosition = formatObject;

				var result = Downloader.TryDownload(formatObject);

				if (result.IsSuccess)
				{
					aggregateResult.CurrentPosition = formatObject;

					if (!(CurrentAggregatedFiles.Any(x => x.Item2 == result.DestinationFile)))
					{
						CurrentAggregatedFiles.Enqueue(Tuple.Create(formatObject, result.DestinationFile));

						if (CurrentAggregatedFiles.Count > NumberOfFilesToAggregate)
						{
							CurrentAggregatedFiles.Dequeue();
						}

						if (CurrentAggregatedFiles.Count == NumberOfFilesToAggregate)
						{
							aggregateResult.IsSuccess = true;
							aggregateResult.DestinationFiles = CurrentAggregatedFiles.Select(x => x.Item2).ToArray();
							CurrentAggregatedFiles.Dequeue();

							break;
						}
					}
				}
			}

			return aggregateResult;
		}
	}
}
