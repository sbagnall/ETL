namespace SteveBagnall.Etl.Forex
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Extract;

	public interface IDownloadAggregator
	{
		int NumberOfFilesToAggregate { get; }
		ISourceSpecification Source { get; }
		IFormatIterator FormatIterator { get; }
		IDownloader Downloader { get; }

		Queue<Tuple<FormatObject, FileInfo>> CurrentAggregatedFiles { get; }

		void Initialize();

		DownloadAggregatorResult DownloadFirst(FormatObject lastDownloadedFormat);

		DownloadAggregatorResult DownloadNext(FormatObject lastDownloadedFormat);
	}
}
