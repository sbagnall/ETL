namespace SteveBagnall.Etl.Forex
{
	using System;
	using System.IO;
    using SteveBagnall.Core;
	using SteveBagnall.Core.Text;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Etl.Forex.Extract.Abstract;
    using SteveBagnall.Core.Web;

	public class Downloader : IDownloader
	{
		public ISourceSpecification Source { get; set; }
		public DirectoryInfo DownloadLocation { get; set; }
		public IFormatIterator FormatIterator { get; set; }
		public IWebClient WebClient { get; set; }

		public Downloader()
		{ }

		public Downloader(ISourceSpecification source, DirectoryInfo downloadLocation)
		{
			Source = source;
			DownloadLocation = downloadLocation;
			FormatIterator = new ContinuousFormatIterator(Source);
			WebClient = new DefaultWebClient();
		}

		public TryDownloadResult TryDownload(FormatObject lastDownloadedFormat = default(FormatObject))
		{
			FileInfo lastDestinationFile = default(FileInfo);
			DateTimeOffset lastAttemptedDateTime = DateTimeOffset.MinValue;
			FormatObject lastAttemptedFormatObject = default(FormatObject);

			foreach (var formatObject in FormatIterator.GetNextCandidates(lastDownloadedFormat))
			{
				lastAttemptedDateTime = Source.GetUpperBoundExclusive(formatObject);
				lastAttemptedFormatObject = formatObject;

				if ((string.IsNullOrWhiteSpace(Source.UriFormat)) || (string.IsNullOrWhiteSpace(Source.FilenameFormat)))
				{
					continue;
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
						lastDestinationFile = destinationFile;

						return new TryDownloadResult()
						{
							IsSuccess = true,
							FormatObject = formatObject,
							DestinationFile = lastDestinationFile,
							UpperBoundExclusive = lastAttemptedDateTime,
						};
					}
				}
				catch (System.Net.WebException)
				{ 
					// Do nothing - try the next candidate until one is available
				}
			}

			return new TryDownloadResult() 
			{ 
				IsSuccess = false,
				FormatObject = lastAttemptedFormatObject,
				DestinationFile = default(FileInfo),
				UpperBoundExclusive = lastAttemptedDateTime,
			};
		}
	}
}
