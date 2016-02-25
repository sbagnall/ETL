namespace SteveBagnall.ScheduledTasks.ForexiteETL
{
	using SteveBagnall.Etl.Forex;

	public class EtlForexConfig : IEtlForexConfig
	{
		private const bool DEFAULT_ISRESTORE = false;
		private const string DEFAULT_ROOTSQLITEFOLDER = @"D:\Data\SQLite";
		private const string DEFAULT_ROOTTEMPFOLDER = @"D:\Temp";

		public bool IsRestoreCleanDb { get; set; }

		public string RootTempFolder { get; set; }

		public string RootSQLiteFolder { get; set; }

		public EtlForexConfig()
		{
			IsRestoreCleanDb = DEFAULT_ISRESTORE;
			RootTempFolder = DEFAULT_ROOTTEMPFOLDER;
			RootSQLiteFolder = DEFAULT_ROOTSQLITEFOLDER;
		}
	}
}
