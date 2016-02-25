namespace SteveBagnall.EtfSpecificationTests
{
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Specification;
	
	[TestClass]
	public class EtlProcessTests
	{
		[TestMethod]
		public void Test_Extract_ExecutesOnceIfGetLastReturnsSameValue()
		{
			var currentPosition = "current";
			
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
			var loader = new Mock<ILoader<string>>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			extractionResult.Verify(x => x.CleanUp(), Times.Once());

			extractionResult.VerifyGet(x => x.CurrentPosition, Times.Exactly(2));
			extractionResult.VerifyGet(x => x.IsSuccess, Times.Exactly(1));

			manifest.Verify(x => x.GetLast(), Times.Once());
			manifest.Verify(x => x.Update("current"), Times.Exactly(1));
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Exactly(1));
		}

		[TestMethod]
		public void Test_Extract_ReturnsNoData()
		{
			var currentPosition = "current";

			var manifest = new Mock<IManifest<string>>();
			manifest.Setup(x => x.GetLast()).Returns(currentPosition);
			manifest.Setup(x => x.Update(It.IsAny<string>())).Callback<string>(x =>
			{
				Assert.AreEqual(x, currentPosition);
			});

			var extracter = new Mock<IExtracter<string>>();
			extracter.Setup(x => x.Extract(It.IsAny<string>())).Returns(new List<IExtractionResult<string>>());

			var transformer = new Mock<ITransformer<string>>();
			var loader = new Mock<ILoader<string>>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			manifest.Verify(x => x.GetLast(), Times.Once());

			loader.Verify(x => x.EnsureNext(It.IsAny<string>()), Times.Never());
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Never());
		}

		[TestMethod]
		public void Test_Extract_DoesntUpdateManifestIfNoData()
		{
			var currentPosition = "current";
			var nextPosition = "failed day"; 
			
			var manifest = new Mock<IManifest<string>>();
			manifest.Setup(x => x.GetLast()).Returns(currentPosition);
			
			var extractionResult = new Mock<IExtractionResult<string>>();
			extractionResult.SetupGet(x => x.CurrentPosition).Returns(nextPosition);
			extractionResult.SetupGet(x => x.IsSuccess).Returns(false);

			var extracter = new Mock<IExtracter<string>>();
			extracter.Setup(x => x.Extract(It.IsAny<string>())).Returns(new[] { extractionResult.Object });

			var transformer = new Mock<ITransformer<string>>();
			var loader = new Mock<ILoader<string>>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			manifest.Verify(x => x.GetLast(), Times.Once());
			extracter.Verify(x => x.Extract("current"), Times.Once());

			loader.Verify(x => x.EnsureNext("failed day"), Times.Never());
			extractionResult.Verify(x => x.CleanUp(), Times.Never());
			manifest.Verify(x => x.Update("failed day"), Times.Never());
			
			loader.Verify(x => x.EnsureNext(It.IsAny<string>()), Times.Never());
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Never());

			extractionResult.VerifyGet(x => x.CurrentPosition, Times.Exactly(1));
			extractionResult.VerifyGet(x => x.IsSuccess, Times.Exactly(1));
		}

		[TestMethod]
		public void Test_Extract_UpdatesManifestOnlyOnSuccess()
		{
			var currentPosition = "current";
			var failedPosition = "failed day"; 
			var successPosition = "success day";

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
			var loader = new Mock<ILoader<string>>();

			var target = new EtlProcess<string>()
			{
				Manifest = manifest.Object,
				Extracter = extracter.Object,
				Transformer = transformer.Object,
				Loader = loader.Object,
			};

			target.Execute();

			manifest.Verify(x => x.GetLast(), Times.Once());
			extracter.Verify(x => x.Extract("current"), Times.Once());

			failedResult.VerifyGet(x => x.CurrentPosition, Times.Once());
			failedResult.VerifyGet(x => x.IsSuccess, Times.Once());
			loader.Verify(x => x.EnsureNext("failed day"), Times.Never());
			failedResult.Verify(x => x.CleanUp(), Times.Never());
			manifest.Verify(x => x.Update("failed day"), Times.Never());

			failedResult.VerifyGet(x => x.CurrentPosition, Times.Once());
			failedResult.VerifyGet(x => x.IsSuccess, Times.Once());
			loader.Verify(x => x.EnsureNext("success day"), Times.Once());
			successResult.Verify(x => x.CleanUp(), Times.Once());
			manifest.Verify(x => x.Update("success day"), Times.Once());

			loader.Verify(x => x.EnsureNext(It.IsAny<string>()), Times.Once());
			manifest.Verify(x => x.Update(It.IsAny<string>()), Times.Once());
		}
	}
}
