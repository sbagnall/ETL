namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Financial.FinancialTypes;
using SteveBagnall.Financial.FinancialTypes.Forex;
using SteveBagnall.Financial.Types;
	
	[TestClass]
	public class ForexiteSourceHandlerTests
	{
		/// <summary>
		/// The Forexite source starts at 3/1/2001 WST (GMT+1)
		/// </summary>
		[TestMethod]
		public void Test_Forexite_Construction()
		{
			var actual = new ForexiteSourceSpecification();

			Assert.AreEqual(actual.SourceName, "Forexite");
			Assert.AreEqual(actual.FirstDateTimeOffset, new DateTimeOffset(2001, 1, 3, 0, 0, 0, new TimeSpan(1, 0, 0)));
		}

		/// <summary>
		/// The Forexite source is Western European Time and so in the winter will be one hour ahead of UTC
		/// </summary>
		[TestMethod]
		public void Test_Forexite_GetPossibleFormatObjectsWinter()
		{
			var forexite = new ForexiteSourceSpecification();
		
			IEnumerable<FormatObject> expected = new FormatObject[] 
			{
				new FormatObject("Forexite", new DateTime(2002, 1, 3, 0, 0, 0))
			};

			var actual = forexite.GetPossibleFormatObjects(new DateTimeOffset(2002, 1, 2, 23, 0, 0, TimeSpan.Zero));

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		/// <summary>
		/// The Forexite source is Western European Time and so in the summer will be two hours ahead of UTC
		/// </summary>
		[TestMethod]
		public void Test_Forexite_GetPossibleFormatObjectsSummer()
		{
			var forexite = new ForexiteSourceSpecification();
			
			IEnumerable<FormatObject> expected = new FormatObject[] 
			{
				new FormatObject("Forexite", new DateTime(2002, 6, 3, 0, 0, 0))
			};

			var actual = forexite.GetPossibleFormatObjects(new DateTimeOffset(2002, 6, 2, 22, 0, 0, TimeSpan.Zero));

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		/// <summary>
		/// Each day in the Forexite source gets a new file
		/// </summary>
		[TestMethod]
		public void Test_Forexite_GetNextPossibleFormatObjects()
		{
			var forexite = new ForexiteSourceSpecification();

			FormatObject formatObject = new FormatObject("Forexite", new DateTime(2001, 1, 3));

			IEnumerable<FormatObject> expected = new FormatObject[] 
			{
				new FormatObject("Forexite", new DateTime(2001, 1, 4))
			};
			
			var actual = forexite.GetNextPossibleFormatObjects(formatObject);

			Assert.IsTrue(expected.SequenceEqual(actual));
		}

		[TestMethod]
		public void Test_Forexite_ParseHeader()
		{
			var forexite = new ForexiteSourceSpecification();
			var header = @"<TICKER>,<DTYYYYMMDD>,<TIME>,<OPEN>,<HIGH>,<LOW>,<CLOSE>";
			var expected = default(ParseResult);

			var actual = forexite.Parse(header);

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void Test_Forexite_ParseData()
		{
			var forexite = new ForexiteSourceSpecification();
			var header = @"EURUSD,20030116,002800,1.0558,1.0558,1.0557,1.0557";
			
			var endTime = new DateTimeOffset(new DateTime(2003, 01, 16, 0, 28, 0), forexite.TimeZoneInfo.BaseUtcOffset);
			var expected = new ParseResult()
			{
				IsSuccess = true,
				Data = new KeyValuePair<Pair, OHLCV>(
					new Pair(Symbol.EUR, Symbol.USD),
					new OHLCV()
					{
						BeginDateTimeOffset = endTime.AddMinutes(-1),
						Open = 1.0558,
						High = 1.0558,
						Low = 1.0557,
						Close = 1.0557,
						Volume = 1,
						EndDateTimeOffset = endTime
					})
			};
			

			var actual = forexite.Parse(header);

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void Test_Forexite_ParseMissingDate()
		{
			var forexite = new ForexiteSourceSpecification();
			var header = @"EURUSD,,,1.0558,1.0558,1.0557,1.0557";
			
			var expected = default(ParseResult);

			var actual = forexite.Parse(header);

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void Test_Forexite_ParseDataMissingData()
		{
			var forexite = new ForexiteSourceSpecification();
			var header = @"EURUSD,20030116,002800,,,,";

			var expected = default(ParseResult);

			var actual = forexite.Parse(header);

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void Test_Forexite_ParseDataExtraCommas()
		{
			var forexite = new ForexiteSourceSpecification();
			var header = @"EURUSD,20030116,002800,1.0558,1.0558,1.0557,1.0557,,";

			var endTime = new DateTimeOffset(new DateTime(2003, 01, 16, 0, 28, 0), forexite.TimeZoneInfo.BaseUtcOffset);
			var expected = new ParseResult()
			{
				IsSuccess = true,
				Data = new KeyValuePair<Pair, OHLCV>(
					new Pair(Symbol.EUR, Symbol.USD),
					new OHLCV()
					{
						BeginDateTimeOffset = endTime.AddMinutes(-1),
						Open = 1.0558,
						High = 1.0558,
						Low = 1.0557,
						Close = 1.0557,
						Volume = 1,
						EndDateTimeOffset = endTime
					})
			};

			var actual = forexite.Parse(header);

			Assert.AreEqual(actual, expected);
		}
	}
}
