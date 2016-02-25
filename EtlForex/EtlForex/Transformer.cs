namespace SteveBagnall.Etl.Forex
{
	using System.Collections.Generic;
	using System.IO;
    using SteveBagnall.Core;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Configuration;
	using SteveBagnall.Etl.Forex.Transform.Abstract;
	using SteveBagnall.Etl.Specification.Abstract;

	public class Transformer : ITransformer<FormatObject>
	{
		public DirectoryInfo TempLocation { get; set; }

		public ISourceSpecification Source { get; set; }

		public IFileCompression Compression { get; set; }

		public ICleaner Cleaner { get; set; }

		public IBinner Binner { get; set; }

		public Transformer()
		{ }

		public Transformer(ISourceSpecification source, IFileCompression compression, ICleaner cleaner, IBinner binner, IEtlForexConfig config)
		{
			TempLocation = new DirectoryInfo(Path.Combine(config.RootTempFolder, "Transformer"));

			Source = source;
			Compression = compression;
			Cleaner = cleaner;
			Binner = binner;
		}

		public IEnumerable<ITransformationResult> Transform(IExtractionResult<FormatObject> extract)
		{
			var fileNameExtract = (FileNameExtractionResult)extract;

			if (!(TempLocation.Exists))
			{
				TempLocation.Create();
			}

			var extractedFiles = new List<FileInfo>();
			foreach (var file in Compression.UnZip(new FileInfo(fileNameExtract.FileFullName), TempLocation))
			{
				extractedFiles.Add(file);
			}

			var binnedOneMinute = Cleaner.CleanToOneMinute(extractedFiles);

			foreach (var pair in binnedOneMinute.Keys)
			{
				yield return new OneMinuteTransformationResult
				{
					OneMinuteData = binnedOneMinute[pair],
					Pair = pair,
					ExtractedFiles = extractedFiles,
				};
			}
		}
	}
}
