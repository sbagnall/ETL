namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.IO;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Core;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Extract;

	[TestClass]
	public class DownloaderTests
	{
		[TestMethod]
		public void Downloader_TryDownload_Default()
		{
			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.UriFormat).Returns("testUriFormat");
			source.Setup(x => x.FilenameFormat).Returns("testFilenameFormat");
			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var expected = default(TryDownloadResult);
			var target = new Downloader(source.Object, downloadLocation);

			var actual = target.TryDownload(default(FormatObject));

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Downloader_TryDownload_NothingToDownload()
		{
			var source = new Mock<ISourceSpecification>();
			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var target = new Downloader(source.Object, downloadLocation);
			target.WebClient = null;

			var actual = target.TryDownload(default(FormatObject));

			Assert.AreEqual(actual, default(TryDownloadResult));
		}

		[TestMethod]
		public void Downloader_TryDownload_NullUriFormat()
		{
			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.UriFormat).Returns(default(string));
			source.SetupGet(x => x.FilenameFormat).Returns("{DayNumber}{MonthNumber}{ShortYear}.zip");

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.SetupGet(x => x.ContentType).Returns(@"application/zip");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				WebClient = webClient.Object
			};

			target.TryDownload(default(FormatObject));

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Never());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Never());
		}

		[TestMethod]
		public void Downloader_TryDownload_NullFileFormat()
		{
			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.UriFormat)
				.Returns(@"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip");
			source.SetupGet(x => x.FilenameFormat).Returns(default(string));
		
			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.SetupGet(x => x.ContentType).Returns(@"application/zip");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				WebClient = webClient.Object
			};

			target.TryDownload(default(FormatObject));

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Never());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Never());
		}
	
		[TestMethod]
		public void Downloader_TryDownload_IncorrectResponse()
		{
			var formatObject = new FormatObject("test", new DateTime(2003, 3, 2), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var source = new Mock<ISourceSpecification>();

			source.SetupGet(x => x.UriFormat)
				.Returns(@"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip");

			source.SetupGet(x => x.FilenameFormat).Returns("{DayNumber}{MonthNumber}{ShortYear}.zip");
			source.Setup(x => x.IsValidFile(It.IsAny<IWebResponse>()))
				.Returns<IWebResponse>(y => { return y.ContentType.Equals(@"application/zip"); });

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.Setup(x => x.ContentType).Returns(@"text\html");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				DownloadLocation = downloadLocation,
				WebClient = webClient.Object
			};

			var expected = new TryDownloadResult()
			{
				DestinationFile = default(FileInfo),
				IsSuccess = false,
			};

			var actual = target.TryDownload(formatObject);

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Once());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Once());

			Assert.AreEqual(actual.DestinationFile, expected.DestinationFile);
			//Assert.AreEqual(actual.FormatObject, expected.FormatObject);
			Assert.AreEqual(actual.IsSuccess, expected.IsSuccess);
		}

		[TestMethod]
		public void Downloader_TryDownload()
		{
			var formatObject = new FormatObject("test", new DateTime(2003, 3, 2), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var source = new Mock<ISourceSpecification>();

			source.SetupGet(x => x.UriFormat)
				.Returns(@"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip");

			source.SetupGet(x => x.FilenameFormat).Returns("{DayNumber}{MonthNumber}{ShortYear}.zip");
			source.Setup(x => x.IsValidFile(It.IsAny<IWebResponse>()))
				.Returns<IWebResponse>(y => { return y.ContentType.Equals(@"application/zip"); });

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.SetupGet(x => x.ContentType).Returns(@"application/zip");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				DownloadLocation = downloadLocation,
				WebClient = webClient.Object
			};

			var expected = new TryDownloadResult()
			{
				DestinationFile = new FileInfo(string.Format(@"{0}\_020303.zip", downloadLocation)),
				IsSuccess = true,
			};

			var actual = target.TryDownload(formatObject);

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Once());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Once());

			Assert.AreEqual(actual.DestinationFile.FullName, expected.DestinationFile.FullName);
			Assert.AreEqual(actual.IsSuccess, expected.IsSuccess);
		}

	}
}
