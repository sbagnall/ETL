namespace SteveBagnall.Etl.EtlForexTests
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Core;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Transform;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types.Common;

	[TestClass]
	public class TransformerTests
	{
		private static Pair _pair = Pair.EURUSD;

		private static IList<OHLCV> _emptyData = new OHLCV[] { };

		private IList<TransformationData> _expectedData = new List<TransformationData>()
		{
#region data
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.OneMinute },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.ThreeMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.FiveMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.TenMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.FifteenMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.ThirtyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.FortyFiveMinutes },
			new TransformationData() { Data = null, OffsetInHours = 1, Pair = Pair.EURUSD, Period = Periods.FortyFiveMinutes },
			new TransformationData() { Data = null, OffsetInHours = 2, Pair = Pair.EURUSD, Period = Periods.FortyFiveMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.SixtyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.NinetyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 1, Pair = Pair.EURUSD, Period = Periods.NinetyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 2, Pair = Pair.EURUSD, Period = Periods.NinetyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.OneTwentyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 1, Pair = Pair.EURUSD, Period = Periods.OneTwentyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.TwoFortyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 1, Pair = Pair.EURUSD, Period = Periods.TwoFortyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 2, Pair = Pair.EURUSD, Period = Periods.TwoFortyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 3, Pair = Pair.EURUSD, Period = Periods.TwoFortyMinutes },
			new TransformationData() { Data = null, OffsetInHours = 0, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 1, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 2, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 3, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 4, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 5, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 6, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 7, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 8, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 9, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 10, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 11, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 12, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 13, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 14, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 15, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 16, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 17, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 18, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 19, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 20, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 21, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 22, Pair = Pair.EURUSD, Period = Periods.Daily },
			new TransformationData() { Data = null, OffsetInHours = 23, Pair = Pair.EURUSD, Period = Periods.Daily }
#endregion
		};


		[TestMethod]
		public void Transformer_Transform()
		{
			var extractedFiles = new FileInfo[] { };
			var compression = new Mock<IFileCompression>();
			compression.Setup(x => x.UnZip(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>())).Returns(extractedFiles);

			Dictionary<Pair, IList<OHLCV>> clean = new Dictionary<Pair, IList<OHLCV>>()
			{ 
				{ Pair.EURUSD, _emptyData }
			};

			var cleaner = new Mock<ICleaner>();
			cleaner.Setup(x => x.CleanToOneMinute(It.IsAny<List<FileInfo>>())).Returns(clean);

			var binner = new Mock<IBinner>();

			var config = new Mock<IEtlForexConfig>();
			config.SetupGet(x => x.RootTempFolder).Returns(@"d:\Temp");

			var extract = new Mock<IFileNameExtractionResult>();
			extract.SetupGet(x => x.FileFullNames).Returns(new[] { "test.zip" });

			var target = new Transformer(compression.Object, cleaner.Object, binner.Object, config.Object);


			var actual = target.Transform(extract.Object);

			Assert.IsTrue(_expectedData.SequenceEqual(actual.Cast<TransformationResult>().First().Data));
		}
	}
}
