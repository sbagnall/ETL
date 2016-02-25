namespace SteveBagnall.EtfSpecificationTests
{
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Specification;
	using SteveBagnall.Etl.Specification.Abstract;
	
	[TestClass]
	public class EtlProcessTests
	{
		[TestMethod]
		public void Test_Extract_ExecutesOnceIfGetLasteturnsSameValue()
		{
			var currentPosition = "2003, 1, 1";
			
			var manifest = new Mock<IManifest<string>>();
			manifest.Setup(x => x.GetLast()).Returns(currentPosition);
			manifest.Setup(x => x.Update(It.IsAny<string>())).Callback<string>(x =>
			{
				Assert.AreEqual(x, currentPosition);
			});

			// extracter returns last current posiition as next current possition
			var extractionResult = new Mock<IExtractionResult<string>>();
			extractionResult.SetupGet(x => x.CurrentPosition).Returns(currentPosition);
			extractionResult.SetupGet(x => x.IsSuccess).Returns(true);

			var extracter = new Mock<IExtracter<string>>();
			extracter.Setup(x => x.Extract(It.IsAny<string>())).Returns(new[] { extractionResult.Object, extractionResult.Object });

			var transformer = new Mock<ITransformer<string>>();
			var loader = new Mock<ILoader>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			extractionResult.Verify(x => x.CleanUp(), Times.Once());
			manifest.Verify(x => x.GetLast(), Times.Once());
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Exactly(1));
		}

		[TestMethod]
		public void Test_Extract_ReturnsNoData()
		{
			var currentPosition = "2003, 1, 1";

			var manifest = new Mock<IManifest<string>>();
			manifest.Setup(x => x.GetLast()).Returns(currentPosition);
			manifest.Setup(x => x.Update(It.IsAny<string>())).Callback<string>(x =>
			{
				Assert.AreEqual(x, currentPosition);
			});

			var extracter = new Mock<IExtracter<string>>();
			extracter.Setup(x => x.Extract(It.IsAny<string>())).Returns(new List<IExtractionResult<string>>());

			var transformer = new Mock<ITransformer<string>>();
			var loader = new Mock<ILoader>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			manifest.Verify(x => x.GetLast(), Times.Once());
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Exactly(0));
		}

		[TestMethod]
		public void Test_Extract_DoesntUpdateManifestIfNoData()
		{
			var currentPosition = "2003, 1, 1";
			var nextPosition = "2003, 1, 2"; // day fails
			
			var manifest = new Mock<IManifest<string>>();
			manifest.Setup(x => x.GetLast()).Returns(currentPosition);
			
			var extractionResult = new Mock<IExtractionResult<string>>();
			extractionResult.SetupGet(x => x.CurrentPosition).Returns(nextPosition);
			extractionResult.SetupGet(x => x.IsSuccess).Returns(false);

			var extracter = new Mock<IExtracter<string>>();
			extracter.Setup(x => x.Extract(It.IsAny<string>())).Returns(new[] { extractionResult.Object });

			var transformer = new Mock<ITransformer<string>>();
			var loader = new Mock<ILoader>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			extractionResult.Verify(x => x.CleanUp(), Times.Never());
			manifest.Verify(x => x.GetLast(), Times.Once());
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Never());
		}

		[TestMethod]
		public void Test_Extract_UpdatesManifestOnlyOnSuccess()
		{
			var currentPosition = "2003, 1, 1";
			var failedPosition = "2003, 1, 2"; // day fails
			var successPosition = "2003, 1, 3"; // day succeeds

			var manifest = new Mock<IManifest<string>>();
			manifest.Setup(x => x.GetLast()).Returns(currentPosition);
			manifest.Setup(x => x.Update(It.IsAny<string>())).Callback<string>(x =>
			{
				Assert.AreEqual(x, successPosition);
			});

			var failedResult = new Mock<IExtractionResult<string>>();
			failedResult.SetupGet(x => x.CurrentPosition).Returns(failedPosition);
			failedResult.SetupGet(x => x.IsSuccess).Returns(false);

			var successResult = new Mock<IExtractionResult<string>>();
			successResult.SetupGet(x => x.CurrentPosition).Returns(successPosition);
			successResult.SetupGet(x => x.IsSuccess).Returns(true);

			var extracter = new Mock<IExtracter<string>>();
			extracter.Setup(x => x.Extract(It.IsAny<string>())).Returns(new[] { failedResult.Object, successResult.Object });

			var transformer = new Mock<ITransformer<string>>();
			var loader = new Mock<ILoader>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			failedResult.Verify(x => x.CleanUp(), Times.Never());
			successResult.Verify(x => x.CleanUp(), Times.Once());
			manifest.Verify(x => x.GetLast(), Times.Once());
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Exactly(1));
		}
	}
}
