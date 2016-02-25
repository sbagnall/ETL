namespace SteveBagnall.Etl.Forex.Extract
{
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Etl.Forex.Common;

	public struct FileNameExtractionResult : IFileNameExtractionResult
	{
		public IList<string> FileFullNames { get; set; }
		public FormatObject CurrentPosition { get; set; }
		public bool IsSuccess { get; set; }
		
		public void CleanUp()
		{
			foreach (string fileName in FileFullNames)
			{
				File.Delete(fileName);
			}
		}
	}
}
