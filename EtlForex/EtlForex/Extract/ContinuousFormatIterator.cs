namespace SteveBagnall.Etl.Forex
{
	using System.Collections.Generic;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Extract.Abstract;

	public class ContinuousFormatIterator : IFormatIterator
	{
		public ISourceSpecification Source { get; set; }

		public ContinuousFormatIterator(ISourceSpecification source)
		{
			Source = source;
		}

		public IEnumerable<FormatObject> GetNextCandidates(FormatObject lastFormat = default(FormatObject))
		{
			if (lastFormat.Equals(default(FormatObject)))
			{
				return Source.GetPossibleFormatObjects(Source.FirstDateTimeOffset);
			}
			else
			{
				return Source.GetNextPossibleFormatObjects(lastFormat);
			}
		}
	}
}
