namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.IO;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Core;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Etl.Forex.Extract.Abstract;
	using SteveBagnall.Financial.FinancialTypes;

	[TestClass]
	public class DownloaderTests
	{
		[TestMethod]
		public void Test_TryDownload_NothingToDownload()
		{
			var source = new Mock<ISourceSpecification>();
			var formatIterator = new Mock<IFormatIterator>();
			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var target = new Downloader(source.Object, downloadLocation);
			target.WebClient = null; 
			
			var actual = target.TryDownload();

			Assert.AreEqual(actual, default(TryDownloadResult));
		}

		[TestMethod]
		public void Test_TryDownload_NullUriFormat()
		{
			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.UriFormat).Returns(default(string));
			source.SetupGet(x => x.FilenameFormat).Returns("{DayNumber}{MonthNumber}{ShortYear}.zip");

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.IsAny<FormatObject>())).Returns(new[]
				{
					new FormatObject("test", new DateTime(2003, 3, 2)),
				});

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.SetupGet(x => x.ContentType).Returns(@"application/zip");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				FormatIterator = formatIterator.Object,
				WebClient = webClient.Object
			};

			target.TryDownload();

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Never());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Never());
			source.Verify(x => x.GetUpperBoundExclusive(It.IsAny<FormatObject>()), Times.Once());
		}

		[TestMethod]
		public void Test_TryDownload_NullFileFormat()
		{
			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.UriFormat)
				.Returns(@"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip");
			source.SetupGet(x => x.FilenameFormat).Returns(default(string));

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.IsAny<FormatObject>())).Returns(new[]
				{
					new FormatObject("test", new DateTime(2003, 3, 2)),
				});

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.SetupGet(x => x.ContentType).Returns(@"application/zip");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				FormatIterator = formatIterator.Object,
				WebClient = webClient.Object
			};

			target.TryDownload();

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Never());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Never());
			source.Verify(x => x.GetUpperBoundExclusive(It.IsAny<FormatObject>()), Times.Once());
		}

		[TestMethod]
		public void Test_TryDownload()
		{
			var formatObject = new FormatObject("test", new DateTime(2003, 3, 2));
			var newDateTime = new DateTimeOffset(new DateTime(2003, 3, 3), TimeSpan.FromHours(0));

			var source = new Mock<ISourceSpecification>();
			
			source.SetupGet(x => x.UriFormat)
				.Returns(@"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip");
			
			source.SetupGet(x => x.FilenameFormat).Returns("{DayNumber}{MonthNumber}{ShortYear}.zip");
			source.Setup(x => x.IsValidFile(It.IsAny<IWebResponse>()))
				.Returns<IWebResponse>(y => { return y.ContentType.Equals(@"application/zip"); });
			source.Setup(x => x.GetUpperBoundExclusive(formatObject)).Returns(newDateTime);

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.IsAny<FormatObject>())).Returns(new[]
				{
					formatObject,
				});

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.SetupGet(x => x.ContentType).Returns(@"application/zip");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader() 
			{ 
				Source = source.Object,
				DownloadLocation = downloadLocation,
				FormatIterator = formatIterator.Object,
				WebClient = webClient.Object
			};

			var expected = new TryDownloadResult() 
			{ 
				DestinationFile = new FileInfo(string.Format(@"{0}\_020303.zip", downloadLocation)), 
				FormatObject = formatObject,
				IsSuccess = true,
				UpperBoundExclusive = newDateTime
			};

			var actual = target.TryDownload();

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Once());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Once());
			source.Verify(x => x.GetUpperBoundExclusive(formatObject), Times.Once());

			Assert.AreEqual(actual.DestinationFile.FullName, expected.DestinationFile.FullName);
			Assert.AreEqual(actual.FormatObject, expected.FormatObject);
			Assert.AreEqual(actual.IsSuccess, expected.IsSuccess);
			Assert.AreEqual(actual.UpperBoundExclusive, expected.UpperBoundExclusive);
		}

		[TestMethod]
		public void Test_TryDownload_IncorrectResponse()
		{
			var formatObject = new FormatObject("test", new DateTime(2003, 3, 2));
			var newDateTime = new DateTimeOffset(new DateTime(2003, 3, 3), TimeSpan.FromHours(0));

			var source = new Mock<ISourceSpecification>();

			source.SetupGet(x => x.UriFormat)
				.Returns(@"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip");

			source.SetupGet(x => x.FilenameFormat).Returns("{DayNumber}{MonthNumber}{ShortYear}.zip");
			source.Setup(x => x.IsValidFile(It.IsAny<IWebResponse>()))
				.Returns<IWebResponse>(y => { return y.ContentType.Equals(@"application/zip"); });
			source.Setup(x => x.GetUpperBoundExclusive(formatObject)).Returns(newDateTime);

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.IsAny<FormatObject>())).Returns(new[]
				{
					formatObject,
				});

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.Setup(x => x.ContentType).Returns(@"text\html");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				DownloadLocation = downloadLocation,
				FormatIterator = formatIterator.Object,
				WebClient = webClient.Object
			};

			var expected = new TryDownloadResult()
			{
				DestinationFile = default(FileInfo),
				FormatObject = formatObject,
				IsSuccess = false,
				UpperBoundExclusive = newDateTime
			};

			var actual = target.TryDownload();

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Once());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Once());
			source.Verify(x => x.GetUpperBoundExclusive(formatObject), Times.Once());

			Assert.AreEqual(actual.DestinationFile, expected.DestinationFile);
			Assert.AreEqual(actual.FormatObject, expected.FormatObject);
			Assert.AreEqual(actual.IsSuccess, expected.IsSuccess);
			Assert.AreEqual(actual.UpperBoundExclusive, expected.UpperBoundExclusive);
		}

		[TestMethod]
		public void Test_TryDownload_Sequence()
		{
			var formatObject1 = new FormatObject("test", new DateTime(2003, 1, 1));
			var newDateTime1 = new DateTimeOffset(new DateTime(2003, 1, 2), TimeSpan.FromHours(0));
			var formatObject2 = new FormatObject("test", new DateTime(2003, 1, 2));
			var newDateTime2 = new DateTimeOffset(new DateTime(2003, 1, 3), TimeSpan.FromHours(0));

			var source = new Mock<ISourceSpecification>();

			source.SetupGet(x => x.UriFormat)
				.Returns(@"http://www.forexite.com/free_forex_quotes/{Year}/{MonthNumber}/{DayNumber}{MonthNumber}{ShortYear}.zip");

			source.SetupGet(x => x.FilenameFormat).Returns("{DayNumber}{MonthNumber}{ShortYear}.zip");
			source.Setup(x => x.IsValidFile(It.IsAny<IWebResponse>()))
				.Returns<IWebResponse>(y => { return y.ContentType.Equals(@"application/zip"); });
			source.Setup(x => x.GetUpperBoundExclusive(formatObject1)).Returns(newDateTime1);
			source.Setup(x => x.GetUpperBoundExclusive(formatObject2)).Returns(newDateTime2);

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.Equals(formatObject1))))
				.Returns(new[] { formatObject2, });

			DirectoryInfo downloadLocation = new DirectoryInfo(@"d:\test");

			var webResponse = new Mock<IWebResponse>();
			webResponse.SetupGet(x => x.ContentType).Returns(@"application/zip");

			var webClient = new Mock<IWebClient>();
			webClient.Setup(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webResponse.Object);

			var target = new Downloader()
			{
				Source = source.Object,
				DownloadLocation = downloadLocation,
				FormatIterator = formatIterator.Object,
				WebClient = webClient.Object,
			};

			var expected = new TryDownloadResult()
			{
				DestinationFile = new FileInfo(string.Format(@"{0}\_020103.zip", downloadLocation)),
				FormatObject = formatObject2,
				IsSuccess = true,
				UpperBoundExclusive = newDateTime2
			};

			var actual = target.TryDownload(formatObject1);

			webClient.Verify(x => x.DownloadFile(It.IsAny<Uri>(), It.IsAny<string>()), Times.Once());
			source.Verify(x => x.IsValidFile(webResponse.Object), Times.Once());
			source.Verify(x => x.GetUpperBoundExclusive(formatObject2), Times.Once());

			Assert.AreEqual(actual.DestinationFile.FullName, expected.DestinationFile.FullName);
			Assert.AreEqual(actual.FormatObject, expected.FormatObject);
			Assert.AreEqual(actual.IsSuccess, expected.IsSuccess);
			Assert.AreEqual(actual.UpperBoundExclusive, expected.UpperBoundExclusive);
		}


	}
}
