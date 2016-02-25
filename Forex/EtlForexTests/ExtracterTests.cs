namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Extract;

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

		private void AreEqual(IEnumerable<FileNameExtractionResult> expected, IEnumerable<FileNameExtractionResult> actual)
		{
			Assert.AreEqual(expected.Count(), actual.Count());

			expected.Zip(actual, (e, a) =>
				{
					Assert.AreEqual(e.CurrentPosition, a.CurrentPosition);
					Assert.AreEqual(e.IsSuccess, a.IsSuccess);
					Assert.IsTrue(e.FileFullNames.SequenceEqual(a.FileFullNames));
					return true;
				});

		}

		[TestMethod]
		public void Extracter_Extract_Default()
		{
			var format = new FormatObject("test", DateTime.Now, TimeZoneInfo.Utc);

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetUpperBoundExclusive(It.IsAny<FormatObject>())).Returns<FormatObject>(y => y.DateTime.AddDays(1));

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(default(FormatObject))).Returns(default(TryDownloadResult));
			downloader.SetupAllProperties();

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.IsAny<FormatObject>()))
				.Returns<FormatObject>(y =>
				{
					if (y.DateTime == default(FormatObject).DateTime)
					{
						return new[] { format };
					}
					else
					{
						var ret = y;
						ret.DateTime.AddDays(1);
						return new[] { ret };
					}
				});

			var downloadAggregator = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = 2,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			downloadAggregator.Initialize();

			var target = new Extracter()
			{
				Source = source.Object,
				TempDownloadLocation = TempLocation,
				Aggregator = downloadAggregator
			};

			var expected = new FileNameExtractionResult[] { };

			var actual = target.Extract(default(FormatObject));

			AreEqual(expected, actual.Cast<FileNameExtractionResult>());

			formatIterator.Verify(x => x.GetNextCandidates(default(FormatObject)), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(format), Times.Exactly(1));
		}

		[TestMethod]
		public void Extracter_Extract_Sequence()
		{
			var firstDate = new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0));

			var formatObject1 = new FormatObject("test", DateTime.Now.AddDays(-2), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject2 = new FormatObject("test", DateTime.Now.AddDays(-1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject3 = new FormatObject("test", DateTime.Now.AddDays(0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject4 = new FormatObject("test", DateTime.Now.AddDays(1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetUpperBoundExclusive(It.IsAny<FormatObject>())).Returns<FormatObject>(y => y.DateTime.AddDays(1));
			source.SetupGet(x => x.FirstDateTimeOffset).Returns(firstDate);
			source.Setup(x => x.GetPossibleFormatObjects(firstDate)).Returns(new[] { formatObject1 });

			var downloadAggregator = new Mock<IDownloadAggregator>();
			downloadAggregator.Setup(x => x.DownloadFirst(It.Is<FormatObject>(y => y.DateTime == formatObject1.DateTime))).Returns(new DownloadAggregatorResult()
			{
				IsSuccess = false,
				CurrentPosition = formatObject1,
			});

			downloadAggregator.Setup(x => x.DownloadNext(It.Is<FormatObject>(y => y.DateTime == formatObject1.DateTime))).Returns(new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = formatObject2,
				DestinationFiles = new[] { new FileInfo(@"d:\test1.test"), new FileInfo(@"d:\test2.test") }
			});

			downloadAggregator.Setup(x => x.DownloadNext(It.Is<FormatObject>(y => y.DateTime == formatObject2.DateTime))).Returns(new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = formatObject3,
				DestinationFiles = new[] { new FileInfo(@"d:\test2.test"), new FileInfo(@"d:\test3.test") }
			});

			downloadAggregator.Setup(x => x.DownloadNext(It.Is<FormatObject>(y => y.DateTime == formatObject3.DateTime))).Returns(new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = formatObject4,
				DestinationFiles = new[] { new FileInfo(@"d:\test3.test"), new FileInfo(@"d:\test4.test") }
			});


			var target = new Extracter()
			{
				Source = source.Object,
				TempDownloadLocation = TempLocation,
				Aggregator = downloadAggregator.Object
			};

			var expected = new FileNameExtractionResult[] 
			{
				new FileNameExtractionResult() 
				{ 
					FileFullNames = new [] { @"d:\test1.test", @"d:\test2.test" }, 
					CurrentPosition = formatObject2,
					IsSuccess = true
				},
				new FileNameExtractionResult() 
				{ 
					FileFullNames = new [] { @"d:\test2.test", @"d:\test3.test" }, 
					CurrentPosition = formatObject3,
					IsSuccess = true
				},
			};

			var actual = target.Extract(default(FormatObject));

			AreEqual(expected, actual.Cast<FileNameExtractionResult>());
			downloadAggregator.Verify(x => x.Initialize(), Times.Once());
			source.Verify(x => x.GetPossibleFormatObjects(firstDate), Times.Once());
			downloadAggregator.Verify(x => x.DownloadFirst(formatObject1), Times.Once());
			downloadAggregator.Verify(x => x.DownloadNext(formatObject1), Times.Once());
			downloadAggregator.Verify(x => x.DownloadNext(formatObject2), Times.Once());
			downloadAggregator.Verify(x => x.DownloadNext(formatObject3), Times.Never());
			downloadAggregator.Verify(x => x.DownloadNext(formatObject4), Times.Never());
		}

		[TestMethod]
		public void Extracter_Extract_OnlyStopsWhenCurrentDateNotOnDownloadFail()
		{
			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetUpperBoundExclusive(It.IsAny<FormatObject>())).Returns<FormatObject>((x) => x.DateTime.AddDays(1));

			var formatObject1 = new FormatObject("test", DateTime.Now.AddDays(-2), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject2 = new FormatObject("test", DateTime.Now.AddDays(-1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject3 = new FormatObject("test", DateTime.Now.AddDays(0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject4 = new FormatObject("test", DateTime.Now.AddDays(1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(default(FormatObject))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = false,
						DestinationFile = new FileInfo(@"d:\test.test"),
					});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == formatObject1.DateTime))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = false,
						DestinationFile = new FileInfo(@"d:\test.test"),
					});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == formatObject2.DateTime))).Returns(
					new TryDownloadResult()
					{
						IsSuccess = false,
						DestinationFile = new FileInfo(@"d:\test.test"),
					});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == formatObject3.DateTime))).Returns(
				new TryDownloadResult()
				{
					IsSuccess = false,
					DestinationFile = new FileInfo(@"d:\test.test"),
				});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == formatObject4.DateTime))).Returns(
				new TryDownloadResult()
				{
					IsSuccess = false,
					DestinationFile = new FileInfo(@"d:\test.test"),
				});

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(default(FormatObject))).Returns(new[] { formatObject1 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == formatObject1.DateTime))).Returns(new[] { formatObject2 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == formatObject2.DateTime))).Returns(new[] { formatObject3 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == formatObject3.DateTime))).Returns(new[] { formatObject4 });

			var downloadAggregator = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = 2,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			downloadAggregator.Initialize();

			var target = new Extracter()
			{
				Source = source.Object,
				TempDownloadLocation = TempLocation,
				Aggregator = downloadAggregator
			};

			var expected = new FileNameExtractionResult[] { };

			var actual = target.Extract(default(FormatObject));

			AreEqual(expected, actual.Cast<FileNameExtractionResult>());

			downloader.Verify(x => x.TryDownload(default(FormatObject)), Times.Exactly(0));
			downloader.Verify(x => x.TryDownload(formatObject1), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject2), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject3), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(formatObject4), Times.Exactly(0));
		}
	}
}
