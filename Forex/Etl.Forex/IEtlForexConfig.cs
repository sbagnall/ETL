namespace SteveBagnall.Etl.Forex
{
	using System.IO;

	public interface IEtlForexConfig
	{
		bool IsRestoreCleanDb { get; }
		string RootTempFolder { get; }
		string RootSQLiteFolder { get; }
	}
}
