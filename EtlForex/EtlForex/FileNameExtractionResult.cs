namespace SteveBagnall.Etl.Forex
{
	using System.IO;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Specification.Abstract;
	using SteveBagnall.Financial.FinancialTypes.Forex;

	public struct FileNameExtractionResult : IExtractionResult<FormatObject>
	{
		public string FileFullName { get; set; }
		public Pair Pair { get; set; }
		public FormatObject CurrentPosition { get; set; }
		public bool IsSuccess { get; set; }
		
		public void CleanUp()
		{
			File.Delete(FileFullName);
		}
	}
}
