namespace SteveBagnall.Etl.Forex
{
	using System;
	using System.Collections.Generic;
	using SteveBagnall.Core;
	using SteveBagnall.Etl.Forex.Common;

	public interface ISourceSpecification
	{
		/// <summary>
		/// The name of this source
		/// </summary>
		string SourceName { get; }

		/// <summary>
		/// Time zone of the data
		/// </summary>
		TimeZoneInfo TimeZoneInfo { get; }

		/// <summary>
		/// The DateTimeOffset of the first record sored at this data source
		/// </summary>
		DateTimeOffset FirstDateTimeOffset { get; }

		/// <summary>
		/// The format of the Uri of the download location - to be used with:
		/// <see cref="SteveBagnall.Core.Extensions.StringExtensions.FormatWith"/>
		/// </summary>
		string UriFormat { get; }

		/// <summary>
		/// The format of the downloaded file name - to be used with:
		/// <see cref="SteveBagnall.Core.Extensions.StringExtensions.FormatWith"/>
		/// </summary>
		string FilenameFormat { get; }

		/// <summary>
		/// Checks that the downloaded file is actual data - i.e. not a 404 HTML page etc
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		bool IsValidFile(IWebResponse response);

		/// <summary>
		/// How to unzip the files
		/// </summary>
		Type FileCompressionHandler { get; }
		
		/// <summary>
		/// For a given DateTimeOffset, return all possible 
		/// <see cref="SteveBagnall.Etl.Forex.FormatObject"/>s which should be
		/// tried using <see cref="UriFormat"/> to download the data.
		/// Multiple formats are needed in case there are slight inconsistencies 
		/// in the format for some data.
		/// </summary>
		/// <param name="utcDateTime"></param>
		/// <returns></returns>
		IEnumerable<FormatObject> GetPossibleFormatObjects(DateTimeOffset dateTime);

		/// <summary>
		/// Given a previously downloaded format return all possible 
		/// <see cref="SteveBagnall.Etl.Forex.FormatObject"/>s which should be
		/// tried using <see cref="UriFormat"/> to download the data for the 
		/// next time period.
		/// Multiple formats are needed in case there are slight inconsistencies 
		/// in the format for some data.
		/// </summary>
		/// <param name="lastFormatObject"></param>
		/// <returns></returns>
		IEnumerable<FormatObject> GetNextPossibleFormatObjects(FormatObject lastFormatObject);

		/// <summary>
		/// For a given <see cref="SteveBagnall.Etl.Forex.FormatObject"/>
		/// return the DateTimeOffset which is the first instant that 
		/// would correspond to the next time period according to this
		/// data source.
		/// </summary>
		/// <param name="formatObject"></param>
		/// <returns></returns>
		DateTimeOffset GetUpperBoundExclusive(FormatObject formatObject);

		/// <summary>
		/// Extract a single line from a file at this source.
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		ParseResult Parse(string line);

		/// <summary>
		/// The number of the latest files that will be used to bin data. 
		/// This should cover a period of about 48 hours in order to ensure 
		/// that all the positive and negative date offsets can be binned 
		/// without gaps, since bins will not be filled unless data is 
		/// available for the entire time period covered by the bin.
		/// </summary>
		int NumberOfFilesToAggregate { get; }
	}
}
