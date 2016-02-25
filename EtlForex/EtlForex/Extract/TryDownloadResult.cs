namespace SteveBagnall.Etl.Forex.Extract
{
	using System;
	using System.IO;

	public struct TryDownloadResult
	{
		public bool IsSuccess;
		public FormatObject FormatObject;
		public FileInfo DestinationFile;
		public DateTimeOffset UpperBoundExclusive;
	}
}
