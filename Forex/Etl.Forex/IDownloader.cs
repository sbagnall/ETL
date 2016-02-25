namespace SteveBagnall.Etl.Forex
{
	using System.IO;
	using SteveBagnall.Core;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Extract;

	public interface IDownloader
	{
		ISourceSpecification Source { get; }
		DirectoryInfo DownloadLocation { get; }
		IWebClient WebClient { get; }

		TryDownloadResult TryDownload(FormatObject formatObject);
	}
}
