namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Abstract;

	[TestClass]
	public class ContinuousFormatIteratorTests
	{
		[TestMethod]
		public void Test_GetNextCandidatesDefaultFormat()
		{
			Mock<ISourceSpecification> source = new Mock<ISourceSpecification>();

			var target = new ContinuousFormatIterator(source.Object);

			target.GetNextCandidates(default(FormatObject));

			source.Verify(x => x.GetPossibleFormatObjects(It.IsAny<DateTimeOffset>()), Times.Once());
			source.Verify(x => x.GetNextPossibleFormatObjects(It.IsAny<FormatObject>()), Times.Never());
		}

		[TestMethod]
		public void Test_GetNextCandidatesNonDefaultFormat()
		{
			Mock<ISourceSpecification> source = new Mock<ISourceSpecification>();

			var format = new FormatObject("test", DateTime.MinValue);

			var target = new ContinuousFormatIterator(source.Object);

			target.GetNextCandidates(format);

			source.Verify(x => x.GetPossibleFormatObjects(It.IsAny<DateTimeOffset>()), Times.Never());
			source.Verify(x => x.GetNextPossibleFormatObjects(format), Times.Once());
		}
	}
}
