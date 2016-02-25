namespace SteveBagnall.Etl.EtlForexTests
{
	using System.Collections.Generic;
	using System.IO;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Configuration;
	using SteveBagnall.Financial.DataAccess;
	using SteveBagnall.Financial.FinancialTypes;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types;
    using SteveBagnall.Financial.DataAccess.Common;
	
	[TestClass]
	public class LoadTest
	{
		[TestMethod]
		public void Test_Load()
		{
			var data = new List<OHLCV>();

			var factory = new SSDConnectionFactory(@"STEVE-PC\SQL_SSD", "Forexite");

			var repo = new FinancialRepository(factory);
			
            // CANNOT ACTUALLY INSERT
            //repo.Insert(Periods.OneMinute, new Pair(Symbol.NotSet, Symbol.NotSet), data);
		}
	}
}
