namespace SteveBagnall.Etl.Forex.Extract
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Etl.Forex.Common;

	public struct DownloadAggregatorResult
	{
		public bool IsSuccess;
		public FormatObject CurrentPosition;
		public IList<FileInfo> DestinationFiles;
	}
}
