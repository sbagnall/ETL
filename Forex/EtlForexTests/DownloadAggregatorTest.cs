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
	public class DownloadAggregatorTest
	{
		private void AreEqual(DownloadAggregatorResult expected, DownloadAggregatorResult actual)
		{
			if (expected.DestinationFiles == null)
			{
				Assert.AreEqual(actual.DestinationFiles, null);
			}
			else
			{
				Assert.IsTrue(expected.DestinationFiles.SequenceEqual(actual.DestinationFiles));
			}

			Assert.AreEqual(expected.CurrentPosition, actual.CurrentPosition);
			Assert.AreEqual(expected.IsSuccess, actual.IsSuccess);
		}

		[TestMethod]
		public void DownloadAggregator_DownloadNext_Default()
		{
			var downloader = new Mock<IDownloader>();
			var formatIterator = new Mock<IFormatIterator>();
			var source = new Mock<ISourceSpecification>();

			var target = new DownloadAggregator()
			{
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			var expected = default(DownloadAggregatorResult);

			var actual = target.DownloadNext(default(FormatObject));

			Assert.AreEqual(expected, actual);
			Assert.AreEqual(0, target.CurrentAggregatedFiles.Count());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadNext_DownloadFailure()
		{
			var numDaysToAggregate = 1;

			var format1 = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var format2 = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 2), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(It.IsAny<FormatObject>())).Returns(new TryDownloadResult() { IsSuccess = false });

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == format1.DateTime))).Returns(new [] { format2 });

			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.NumberOfFilesToAggregate).Returns(numDaysToAggregate);

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult() 
			{ 
				CurrentPosition = format2,
			};

			var actual = target.DownloadNext(format1);

			Assert.AreEqual(expected, actual);
			Assert.AreEqual(0, target.CurrentAggregatedFiles.Count());
			formatIterator.Verify(x => x.GetNextCandidates(format1), Times.Once());
			downloader.Verify(x => x.TryDownload(format2), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadNext_One()
		{
			var numDaysToAggregate = 1;

			var format = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var file = new FileInfo(@"d:\temp\test1.test");

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(format)).Returns(new TryDownloadResult()
			{
				DestinationFile = file,
				IsSuccess = true
			});


			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(default(FormatObject))).Returns(new[] { format });

			var source = new Mock<ISourceSpecification>();

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = format,
				DestinationFiles = new [] { file },
			};

			var actual = target.DownloadNext(default(FormatObject));

			AreEqual(expected, actual);
			Assert.AreEqual(0, target.CurrentAggregatedFiles.Count());
			formatIterator.Verify(x => x.GetNextCandidates(default(FormatObject)), Times.Once());
			downloader.Verify(x => x.TryDownload(format), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadNext_Two_Incomplete()
		{
			var numDaysToAggregate = 2;

			var format = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var file = new FileInfo(@"d:\temp\test1.test");

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(format)).Returns(new TryDownloadResult()
			{
				DestinationFile = file,
				IsSuccess = true
			});


			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(default(FormatObject))).Returns(new[] { format });

			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.NumberOfFilesToAggregate).Returns(numDaysToAggregate);

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult() 
			{ 
				CurrentPosition = format,
			};

			var actual = target.DownloadNext(default(FormatObject));

			AreEqual(expected, actual);
			Assert.AreEqual(1, target.CurrentAggregatedFiles.Count());
			Assert.IsTrue(target.CurrentAggregatedFiles.SequenceEqual(new[] { Tuple.Create(format, file) }));
			formatIterator.Verify(x => x.GetNextCandidates(default(FormatObject)), Times.Once());
			downloader.Verify(x => x.TryDownload(format), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadNext_Two()
		{
			var numDaysToAggregate = 2;

			var format1 = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var format2 = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 2), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var file1 = new FileInfo(@"d:\temp\test1.test");
			var file2 = new FileInfo(@"d:\temp\test2.test");

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format1.DateTime))).Returns(new TryDownloadResult()
			{
				DestinationFile = file1,
				IsSuccess = true
			});
			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format2.DateTime))).Returns(new TryDownloadResult()
			{
				DestinationFile = file2,
				IsSuccess = true
			});


			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(default(FormatObject))).Returns(new[] { format1 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == format1.DateTime))).Returns(new[] { format2 });

			var source = new Mock<ISourceSpecification>();

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = format2,
				DestinationFiles = new[] { file1, file2 },
			};

			var actual = target.DownloadNext(target.DownloadNext(default(FormatObject)).CurrentPosition);

			AreEqual(expected, actual);
			Assert.AreEqual(1, target.CurrentAggregatedFiles.Count());
			Assert.IsTrue(target.CurrentAggregatedFiles.SequenceEqual(new[] { Tuple.Create(format2, file2) }));
			formatIterator.Verify(x => x.GetNextCandidates(default(FormatObject)), Times.Exactly(1));
			formatIterator.Verify(x => x.GetNextCandidates(format1), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(format1), Times.Once());
			downloader.Verify(x => x.TryDownload(format2), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadNext_Two_IgnoresSameFile()
		{
			var numDaysToAggregate = 2;

			var format1 = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var format2 = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 2), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var format3 = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 3), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var file1 = new FileInfo(@"d:\temp\test1.test");
			var file2 = new FileInfo(@"d:\temp\test2.test");

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format1.DateTime))).Returns(new TryDownloadResult()
			{
				DestinationFile = file1,
				IsSuccess = true
			});
			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format2.DateTime))).Returns(new TryDownloadResult()
			{
				DestinationFile = file1,
				IsSuccess = true
			});
			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format3.DateTime))).Returns(new TryDownloadResult()
			{
				DestinationFile = file2,
				IsSuccess = true
			});
			

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(default(FormatObject))).Returns(new[] { format1 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == format1.DateTime))).Returns(new[] { format2 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == format2.DateTime))).Returns(new[] { format3 });

			var source = new Mock<ISourceSpecification>();

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = format3,
				DestinationFiles = new[] { file1, file2 },
			};

			var actual = target.DownloadNext(target.DownloadNext(target.DownloadNext(default(FormatObject)).CurrentPosition).CurrentPosition);

			AreEqual(expected, actual);
			Assert.AreEqual(1, target.CurrentAggregatedFiles.Count());
			Assert.IsTrue(target.CurrentAggregatedFiles.SequenceEqual(new[] { Tuple.Create(format3, file2) }));
			formatIterator.Verify(x => x.GetNextCandidates(default(FormatObject)), Times.Exactly(1));
			formatIterator.Verify(x => x.GetNextCandidates(format1), Times.Exactly(1));
			formatIterator.Verify(x => x.GetNextCandidates(format2), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(format1), Times.Once());
			downloader.Verify(x => x.TryDownload(format2), Times.Once());
			downloader.Verify(x => x.TryDownload(format3), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadFirst_Default()
		{
			var downloader = new Mock<IDownloader>();
			var formatIterator = new Mock<IFormatIterator>();
			var source = new Mock<ISourceSpecification>();

			var target = new DownloadAggregator()
			{
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			var expected = default(DownloadAggregatorResult);

			var actual = target.DownloadFirst(default(FormatObject));

			Assert.AreEqual(expected, actual);
			Assert.AreEqual(0, target.CurrentAggregatedFiles.Count());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadFirst_DownloadFailure()
		{
			var numDaysToAggregate = 1;

			var format = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var downloader = new Mock<IDownloader>();
			var formatIterator = new Mock<IFormatIterator>();

			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.NumberOfFilesToAggregate).Returns(numDaysToAggregate);

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult()
			{
				CurrentPosition = format,
			};

			var actual = target.DownloadFirst(format);

			Assert.AreEqual(expected, actual);
			Assert.AreEqual(0, target.CurrentAggregatedFiles.Count());
			downloader.Verify(x => x.TryDownload(format), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadFirst_One()
		{
			var numDaysToAggregate = 1;

			var format = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var file = new FileInfo(@"d:\temp\test1.test");

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(format)).Returns(new TryDownloadResult()
			{
				DestinationFile = file,
				IsSuccess = true
			});


			var formatIterator = new Mock<IFormatIterator>();

			var source = new Mock<ISourceSpecification>();

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = format,
				DestinationFiles = new[] { file },
			};

			var actual = target.DownloadFirst(format);

			AreEqual(expected, actual);
			Assert.AreEqual(0, target.CurrentAggregatedFiles.Count());
			downloader.Verify(x => x.TryDownload(format), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_DownloadFirst_Two_Incomplete()
		{
			var numDaysToAggregate = 2;

			var format = new FormatObject(
				sourceName: "test",
				dateTime: new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0)),
				localTimeZone: TimeZoneInfo.Utc);

			var file = new FileInfo(@"d:\temp\test1.test");


			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(format)).Returns(new TryDownloadResult()
			{
				DestinationFile = file,
				IsSuccess = true
			});


			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(default(FormatObject))).Returns(new[] { format });

			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.NumberOfFilesToAggregate).Returns(numDaysToAggregate);

			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult()
			{
				CurrentPosition = format,
			};

			var actual = target.DownloadFirst(format);

			AreEqual(expected, actual);
			Assert.AreEqual(1, target.CurrentAggregatedFiles.Count());
			Assert.IsTrue(target.CurrentAggregatedFiles.SequenceEqual(new[] { Tuple.Create(format, file) }));
			downloader.Verify(x => x.TryDownload(format), Times.Once());
		}

		[TestMethod]
		public void DownloadAggregator_Sequence()
		{
			var numDaysToAggregate = 2;

			var firstDate = new DateTimeOffset(new DateTime(2001, 1, 1), TimeSpan.FromHours(0));

			var format1 = new FormatObject("test", DateTime.Now.AddDays(-2), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var format2 = new FormatObject("test", DateTime.Now.AddDays(-1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var format3 = new FormatObject("test", DateTime.Now.AddDays(0), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var format4 = new FormatObject("test", DateTime.Now.AddDays(1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetUpperBoundExclusive(It.IsAny<FormatObject>())).Returns<FormatObject>(y => y.DateTime.AddDays(1));
			source.SetupGet(x => x.FirstDateTimeOffset).Returns(firstDate);
			source.Setup(x => x.GetPossibleFormatObjects(firstDate)).Returns(new[] { format1 });

			var formatIterator = new Mock<IFormatIterator>();
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == format1.DateTime))).Returns(new[] { format2 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == format2.DateTime))).Returns(new[] { format3 });
			formatIterator.Setup(x => x.GetNextCandidates(It.Is<FormatObject>(y => y.DateTime == format3.DateTime))).Returns(new[] { format4 });

			var file1 = new FileInfo(@"d:\temp\test1.test");
			var file2 = new FileInfo(@"d:\temp\test2.test");
			var file3 = new FileInfo(@"d:\temp\test3.test");
			var file4 = new FileInfo(@"d:\temp\test4.test");

			var downloader = new Mock<IDownloader>();
			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format1.DateTime))).Returns(
				new TryDownloadResult()
				{
					IsSuccess = true,
					DestinationFile = file1,
				});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format2.DateTime))).Returns(
				new TryDownloadResult()
				{
					IsSuccess = true,
					DestinationFile = file2,
				});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format3.DateTime))).Returns(
				new TryDownloadResult()
				{
					IsSuccess = true,
					DestinationFile = file3,
				});

			downloader.Setup(x => x.TryDownload(It.Is<FormatObject>(y => y.DateTime == format4.DateTime))).Returns(
				new TryDownloadResult()
				{
					IsSuccess = true,
					DestinationFile = file4,
				});


			var target = new DownloadAggregator()
			{
				NumberOfFilesToAggregate = numDaysToAggregate,
				Source = source.Object,
				Downloader = downloader.Object,
				FormatIterator = formatIterator.Object
			};

			target.Initialize();

			var expected = new DownloadAggregatorResult()
			{
				IsSuccess = true,
				CurrentPosition = format3,
				DestinationFiles = new[] { file2, file3 },
			};

			var actual = target.DownloadNext(target.DownloadNext(target.DownloadFirst(format1).CurrentPosition).CurrentPosition);

			AreEqual(expected, actual);
			Assert.AreEqual(1, target.CurrentAggregatedFiles.Count());
			Assert.IsTrue(target.CurrentAggregatedFiles.SequenceEqual(new[] { Tuple.Create(format3, file3) }));
			downloader.Verify(x => x.TryDownload(default(FormatObject)), Times.Exactly(0));
			downloader.Verify(x => x.TryDownload(format1), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(format2), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(format3), Times.Exactly(1));
			downloader.Verify(x => x.TryDownload(format4), Times.Exactly(0));
		}
	}
}
