namespace SteveBagnall.Etl.Forex
{
	using System;
	using System.Collections.Generic;
	using SteveBagnall.Etl.Forex.Common;

	public class ContinuousFormatIterator : IFormatIterator
	{
		public ISourceSpecification Source { get; set; }

		public ContinuousFormatIterator(ISourceSpecification source)
		{
			Source = source;
		}

		public IEnumerable<FormatObject> GetNextCandidates(FormatObject lastFormat)
		{
			return Validate(lastFormat, Source.GetNextPossibleFormatObjects(lastFormat));
		}

		private IEnumerable<FormatObject> Validate(FormatObject lastFormat, IEnumerable<FormatObject> newFormats)
		{
			foreach (var newFormat in newFormats)
			{
				if (newFormat.Equals(lastFormat))
				{
					throw new ApplicationException("Next possible format is is the same as previous format.");
				}

				if (Source.GetUpperBoundExclusive(lastFormat) > Source.GetUpperBoundExclusive(newFormat))
				{
					throw new ApplicationException("Next possible format is not later then previous format.");
				}
			}

			return newFormats;
		}
	}
}
