namespace SteveBagnall.Etl.Forex.Configuration
{
	using System.IO;

	public interface IEtlForexConfig
	{
		bool IsRestoreCleanDb { get; }
		string RootTempFolder { get; }
		string DBLocation { get; }
	}
}
