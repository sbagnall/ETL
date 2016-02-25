namespace SteveBagnall.Etl.Forex.Abstract
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using SteveBagnall.Core;
	using SteveBagnall.Financial.FinancialTypes;
	using SteveBagnall.Financial.FinancialTypes.Forex;
	using SteveBagnall.Financial.Types;

	public interface ISourceSpecification
	{
		/// <summary>
		/// The name of this source
		/// </summary>
		string SourceName { get; }

		/// <summary>
		/// The Time Zone that this source data is encorded in
		/// </summary>
		TimeZoneInfo TimeZoneInfo { get; }

		/// <summary>
		/// The DateTimeOffset of the first record sored at this data source
		/// </summary>
		DateTimeOffset FirstDateTimeOffset { get; }

		/// <summary>
		/// A local time of day that data starts (i.e. normally 00:00)
		/// </summary>
		TimeSpan DataStartTime { get; }

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
		/// If pairs are stored in different files then return an enumeration 
		/// containing all the pairs that are stored at the location in their 
		/// own file, otherwise just return an enumeration containing only 
		/// Pair.NotSet
		/// </summary>
		/// <returns></returns>
		IEnumerable<Pair> GetDiscriminatingFilePairs();

		/// <summary>
		/// For a given DateTimeOffset, return all possible 
		/// <see cref="SteveBagnall.Etl.Forex.FormatObject"/>s which should be
		/// tried using <see cref="UriFormat"/> to download the data.
		/// Multiple formats are needed in case there are slight inconsistencies 
		/// in the format for some data.
		/// </summary>
		/// <param name="utcDateTime"></param>
		/// <returns></returns>
		IEnumerable<FormatObject> GetPossibleFormatObjects(DateTimeOffset utcDateTime);

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
	}
}
