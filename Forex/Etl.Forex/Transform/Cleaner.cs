namespace SteveBagnall.Etl.Forex.Transform
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types.Common;

	public class Cleaner : ICleaner
	{
		public ISourceSpecification Source { get; set; }

		public IBinner Binner { get; set; }

		public Cleaner()
		{ }

		public Cleaner(ISourceSpecification source, IBinner binner)
		{
			Source = source;
			Binner = binner;
		}

		public Dictionary<Pair, IList<OHLCV>> CleanToOneMinute(IList<FileInfo> files)
		{
			var binnedData = new Dictionary<Pair, IList<OHLCV>>();

			foreach (var file in files)
			{
				using (TextReader tr = new StreamReader(file.FullName))
				{
					string line = tr.ReadLine();

					while (line != null)
					{
						var result = Source.Parse(line);

						if (result.IsSuccess)
						{
							var data = result.Data;

							if (!binnedData.ContainsKey(data.Key))
							{
								binnedData.Add(data.Key, new List<OHLCV>());
							}

							binnedData[data.Key].Add(data.Value);
						}

						line = tr.ReadLine();
					}
				}
			}
			
			Pair[] keys = new Pair[binnedData.Count];
			binnedData.Keys.CopyTo(keys, 0);
			foreach (var pair in keys)
			{
				binnedData[pair] = Binner.Bin(binnedData[pair], Periods.OneMinute, TimeZoneInfo.Utc);
			}

			return binnedData;
		}
	}
}
