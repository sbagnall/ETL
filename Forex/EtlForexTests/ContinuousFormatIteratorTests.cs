namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Common;

	[TestClass]
	public class ContinuousFormatIteratorTests
	{
		[TestMethod]
		public void ContinuousFormatIterator_GetNextCandidates_DefaultFormat()
		{
			Mock<ISourceSpecification> source = new Mock<ISourceSpecification>();

			var target = new ContinuousFormatIterator(source.Object);

			target.GetNextCandidates(default(FormatObject));

			source.Verify(x => x.GetPossibleFormatObjects(It.IsAny<DateTimeOffset>()), Times.Never());
			source.Verify(x => x.GetNextPossibleFormatObjects(It.IsAny<FormatObject>()), Times.Once());
		}

		[TestMethod]
		public void ContinuousFormatIterator_GetNextCandidates_NonDefaultFormat()
		{
			Mock<ISourceSpecification> source = new Mock<ISourceSpecification>();

			var format = new FormatObject("test", DateTime.MinValue, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new ContinuousFormatIterator(source.Object);

			target.GetNextCandidates(format);

			source.Verify(x => x.GetPossibleFormatObjects(It.IsAny<DateTimeOffset>()), Times.Never());
			source.Verify(x => x.GetNextPossibleFormatObjects(format), Times.Once());
		}

		[TestMethod]
		[ExpectedException(typeof(ApplicationException))]
		public void ContinuousFormatIterator_GetNextCandidates_ExceptionIfOneIsTheSame()
		{
			var format = new FormatObject("test", DateTime.MinValue, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			Mock<ISourceSpecification> source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetNextPossibleFormatObjects(It.IsAny<FormatObject>())).Returns<FormatObject>(y => new [] { y });

			var target = new ContinuousFormatIterator(source.Object);

			target.GetNextCandidates(format);
		}

		[TestMethod]
		[ExpectedException(typeof(ApplicationException))]
		public void ContinuousFormatIterator_GetNextCandidates_ExceptionIfOneIsPrevious()
		{
			var format1 = new FormatObject("test", new DateTime(2001, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var format2 = new FormatObject("test", new DateTime(2001, 1, 2), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			Mock<ISourceSpecification> source = new Mock<ISourceSpecification>();
			source.Setup(x => x.GetUpperBoundExclusive(It.IsAny<FormatObject>())).Returns<FormatObject>(y => y.DateTime.AddDays(1));
			source.Setup(x => x.GetNextPossibleFormatObjects(It.Is<FormatObject>(y => y.DateTime == format2.DateTime))).Returns(new [] { format1 });

			var target = new ContinuousFormatIterator(source.Object);

			target.GetNextCandidates(format2);
		}
	}
}
