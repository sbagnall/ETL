namespace SteveBagnall.Etl.Forex.Extract.Abstract
{
    using SteveBagnall.Core;
    using SteveBagnall.Etl.Forex.Abstract;
    using System.IO;

	public interface IDownloader
	{
		ISourceSpecification Source { get; }
		DirectoryInfo DownloadLocation { get; }
		IFormatIterator FormatIterator { get; }
		IWebClient WebClient { get; }

		TryDownloadResult TryDownload(FormatObject lastExtracted);
	}
}
