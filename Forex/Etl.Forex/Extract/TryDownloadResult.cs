namespace SteveBagnall.Etl.Forex.Extract
{
	using System.IO;
	using SteveBagnall.Etl.Forex.Common;

	public struct TryDownloadResult
	{
		public bool IsSuccess;
		public FileInfo DestinationFile;
	}
}
