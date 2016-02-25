namespace SteveBagnall.Etl.Forex.Extract
{
	using System;
	using System.IO;
	using SteveBagnall.Core;
	using SteveBagnall.Core.Text;
	using SteveBagnall.Core.Web;
	using SteveBagnall.Etl.Forex.Common;

	public class Downloader : IDownloader
	{
		public ISourceSpecification Source { get; set; }
		public DirectoryInfo DownloadLocation { get; set; }
		public IWebClient WebClient { get; set; }

		public Downloader()
		{ }

		public Downloader(ISourceSpecification source, DirectoryInfo downloadLocation)
		{
			Source = source;
			DownloadLocation = downloadLocation;
			WebClient = new DefaultWebClient();
		}

		public TryDownloadResult TryDownload(FormatObject formatObject)
		{
			if (formatObject.Equals(default(FormatObject))
				|| (Source == null)
				|| (string.IsNullOrWhiteSpace(Source.UriFormat)) 
				|| (string.IsNullOrWhiteSpace(Source.FilenameFormat)))
			{
				return default(TryDownloadResult);
			}

			Uri uri = new Uri(Source.UriFormat.FormatWith(formatObject));
				
			FileInfo destinationFile = new FileInfo(Path.Combine(
					DownloadLocation.FullName,
					string.Format("{0}_{1}", Source.SourceName, Source.FilenameFormat.FormatWith(formatObject))));
			try
			{
				var response = WebClient.DownloadFile(uri, destinationFile.FullName);

				if (Source.IsValidFile(response))
				{
					return new TryDownloadResult()
					{
						IsSuccess = true,
						DestinationFile = destinationFile,
					};
				}
			}
			catch (System.Net.WebException)
			{ 
				// Do nothing - try the next candidate until one is available
			}

			return default(TryDownloadResult);
		}

		private TryDownloadResult GetDefaultResponse(FormatObject formatObject)
		{
			var ret = default(TryDownloadResult);
			return ret;
		}
	}
}
