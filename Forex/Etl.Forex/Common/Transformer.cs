namespace SteveBagnall.Etl.Forex.Common
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using SteveBagnall.Core;
	using SteveBagnall.Core.Time;
	using SteveBagnall.Etl.Forex.Transform;
	using SteveBagnall.Etl.Specification;
	using SteveBagnall.Financial.Types.Common;

	public class Transformer : TransformerBase
	{
		private readonly IList<TimeSpan> _offsets = new List<TimeSpan>();

		public DirectoryInfo TempLocation { get; set; }

		public IFileCompression Compression { get; set; }

		public ICleaner Cleaner { get; set; }

		public IBinner Binner { get; set; }

		public Transformer()
		{
			for (int offset = -12; offset <= 14; offset++)
			{
				_offsets.Add(TimeSpan.FromHours(offset));
			}
		}

		public Transformer(IFileCompression compression, ICleaner cleaner, IBinner binner, IEtlForexConfig config)
			: this()
		{
			TempLocation = new DirectoryInfo(Path.Combine(config.RootTempFolder, "Transformer"));

			Compression = compression;
			Cleaner = cleaner;
			Binner = binner;
		}

		public override IEnumerable<ITransformationResult> TransformFileExtract(IFileNameExtractionResult fileNameExtract)
		{
			if (!(TempLocation.Exists))
			{
				TempLocation.Create();
			}

			var extractedFiles = new List<FileInfo>();

			foreach (string fileName in fileNameExtract.FileFullNames)
			{
				foreach (var file in Compression.UnZip(new FileInfo(fileName), TempLocation))
				{
					extractedFiles.Add(file);
				}
			}

			var binnedOneMinute = Cleaner.CleanToOneMinute(extractedFiles);

			// get all the results at once to avoid unecessary d/b access
			var data = new List<TransformationData>();
			foreach (var period in Enum.GetValues(typeof(Periods)).Cast<Periods>().Where(x => ((x != Periods.NotSet))))
			{
				foreach (var pair in binnedOneMinute.Keys)
				{
					foreach (var offset in AlignedIntervals.Instance.GetMinimumDistinctOffsets(_offsets, PeriodIntervals.Instance[period]))
					{
						data.Add(new TransformationData()
						{
							Data = Binner.Bin(binnedOneMinute[pair], period, TimeZoneInfo.Utc, offset),
							OffsetInHours = offset.Hours,
							Pair = pair,
							Period = period
						});
					}
				}
			}

			yield return new TransformationResult() { Data = data, ExtractedFiles = extractedFiles };
		}
	}
}
