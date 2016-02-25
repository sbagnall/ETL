namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Etl.Forex.Extract.Abstract;
	using SteveBagnall.Etl.Specification.Abstract;
	using SteveBagnall.Financial.FinancialTypes;
	using SteveBagnall.Financial.FinancialTypes.Forex;

	[TestClass]
	public class ExtracterTests
	{
		private DirectoryInfo TempLocation = new DirectoryInfo(@"D:\Temp\Extracter");

		[TestCleanup]
		public void Cleanup()
		{
			if (TempLocation.Exists)
			{
				TempLocation.Delete(true);
			}
		}

		[TestMethod]
		public void Test_Extract_Default()
		{
			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetDiscriminatingFilePairs()).Returns(() => { return new [] { default(Pair) }; });

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(default(FormatObject))).Returns(default(TryDownloadResult));
			downloader.SetupAllProperties();

			var target = new Extracter()
			{
				TempDownloadLocation = TempLocation,
				Source = source.Object,
				Downloader = downloader.Object,
			};

			var expected = new FileNameExtractionResult[] { };
			
			var actual = target.Extract(default(FormatObject));

			Assert.IsTrue(actual.SequenceEqual(expected.Cast<IExtractionResult<FormatObject>>()));

			// twice - as attempts to load the default datetime twice in a row
			downloader.Verify(x => x.TryDownload(default(FormatObject)), Times.Exactly(2));
		}

		[TestMethod]
		public void Test_Extract_EscapesIfDownloadSameTwice()
		{
			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetDiscriminatingFilePairs()).Returns(() => { return new[] { default(Pair) }; });

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(default(FormatObject)))
				.Returns(new TryDownloadResult()
				{
					IsSuccess = true,
					DestinationFile = new FileInfo(@"d:\test.test"),
				});

			var target = new Extracter()
			{
				TempDownloadLocation = TempLocation,
				Source = source.Object,
				Downloader = downloader.Object,
			};

			var expected = new FileNameExtractionResult[] 
			{
				new FileNameExtractionResult() { FileFullName = @"d:\test.test", Pair = default(Pair), CurrentPosition = default(FormatObject) },
			};

			var actual = target.Extract(default(FormatObject));

			Task.Factory.StartNew(() => actual.ToList()).Wait(TimeSpan.FromSeconds(1));

			downloader.Verify(x => x.TryDownload(default(FormatObject)), Times.Exactly(2));
		}

		[TestMethod]
		public void Test_Extract_Sequence()
		{
			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetDiscriminatingFilePairs()).Returns(() => { return new[] { default(Pair) }; });

			var formatObject1 = new FormatObject("test", DateTime.Now.AddDays(-2));
			var formatObject2 = new FormatObject("test", DateTime.Now.AddDays(-1));

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(default(FormatObject))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = true,
						DestinationFile = new FileInfo(@"d:\test.test"),
						FormatObject = formatObject1,
						UpperBoundExclusive = DateTimeOffset.Now.AddDays(-1)
					});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.LocalDateTime == formatObject1.LocalDateTime))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = true,
						DestinationFile = new FileInfo(@"d:\test.test"),
						FormatObject = formatObject2,
						UpperBoundExclusive = DateTimeOffset.Now.AddDays(0)
					});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.LocalDateTime == formatObject2.LocalDateTime))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = false,
						DestinationFile = new FileInfo(@"d:\test.test"),
						FormatObject = default(FormatObject),
						UpperBoundExclusive = DateTimeOffset.Now.AddDays(1)
					});

			var target = new Extracter()
			{
				TempDownloadLocation = TempLocation,
				Source = source.Object,
				Downloader = downloader.Object,
			};

			var expected = new FileNameExtractionResult[] 
			{
				new FileNameExtractionResult() 
				{ 
					FileFullName = @"d:\test.test", 
					Pair = default(Pair), 
					CurrentPosition = formatObject1,
					IsSuccess = true
				},
				new FileNameExtractionResult() 
				{ 
					FileFullName = @"d:\test.test", 
					Pair = default(Pair), 
					CurrentPosition = formatObject2,
					IsSuccess = true
				},
			};

			var actual = target.Extract(default(FormatObject));

			Assert.IsTrue(actual.SequenceEqual(expected.Cast<IExtractionResult<FormatObject>>()));

			downloader.Verify(x => x.TryDownload(default(FormatObject)), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject1), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject2), Times.Exactly(1));
		}

		[TestMethod]
		public void Test_Extract_ExtractBreaksOutOfLoopIfAttemptSameDownloadTwice()
		{
			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetDiscriminatingFilePairs()).Returns(() => { return new[] { default(Pair) }; });

			var formatObject = new FormatObject("test", new DateTime(2003, 1, 1));

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(default(FormatObject)))
				.Returns(new TryDownloadResult()
				{
					IsSuccess = true,
					DestinationFile = new FileInfo(@"d:\test.test"),
					FormatObject = formatObject,
				});

			var target = new Extracter()
			{
				TempDownloadLocation = TempLocation,
				Source = source.Object,
				Downloader = downloader.Object,
			};

			var expected = new FileNameExtractionResult[] 
			{
				new FileNameExtractionResult() 
				{ 
					FileFullName = @"d:\test.test", 
					Pair = default(Pair), 
					CurrentPosition = formatObject,
					IsSuccess = true
				},
			};

			var actual = target.Extract(default(FormatObject));

			Assert.IsTrue(actual.SequenceEqual(expected.Cast<IExtractionResult<FormatObject>>()));

			downloader.Verify(x => x.TryDownload(default(FormatObject)), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject), Times.Exactly(1));
		}

		[TestMethod]
		public void Test_Extract_OnlyStopsWhenCurrentDate()
		{
			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetDiscriminatingFilePairs()).Returns(() => { return new[] { default(Pair) }; });

			var formatObject1 = new FormatObject("test", DateTime.Now.AddDays(-2));
			var formatObject2 = new FormatObject("test", DateTime.Now.AddDays(-1));

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(default(FormatObject))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = false,
						DestinationFile = new FileInfo(@"d:\test.test"),
						FormatObject = formatObject1,
						UpperBoundExclusive = DateTimeOffset.Now.AddDays(-1),
					});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.LocalDateTime == formatObject1.LocalDateTime))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = false,
						DestinationFile = new FileInfo(@"d:\test.test"),
						FormatObject = formatObject2,
						UpperBoundExclusive = DateTimeOffset.Now.AddDays(0),
					});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.LocalDateTime == formatObject2.LocalDateTime))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = false,
						DestinationFile = new FileInfo(@"d:\test.test"),
						FormatObject = formatObject2,
						UpperBoundExclusive = DateTimeOffset.Now.AddDays(1),
					});

			var target = new Extracter()
			{
				TempDownloadLocation = TempLocation,
				Source = source.Object,
				Downloader = downloader.Object,
			};

			var expected = new FileNameExtractionResult[] {};

			var actual = target.Extract(default(FormatObject));

			Assert.IsTrue(actual.SequenceEqual(expected.Cast<IExtractionResult<FormatObject>>()));

			downloader.Verify(x => x.TryDownload(default(FormatObject)), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject1), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject2), Times.Exactly(1));
		}

	}
}
