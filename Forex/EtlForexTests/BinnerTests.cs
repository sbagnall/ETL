namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using SteveBagnall.Etl.Forex.Transform;
	using SteveBagnall.Financial.Types.Common;

	[TestClass]
	public class BinnerTests
	{
		#region WSTWinter_OneMinuteData_Start20010325_230100_End20010325_235900
		private IList<OHLCV> WSTWinter_OneMinuteData_Start20010325_230100_End20010325_235900 = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 1, 0), TimeSpan.FromHours(1)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 2, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 3, 0), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 4, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 5, 0), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 6, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 6, 0), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 7, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 12, 0), TimeSpan.FromHours(1)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 13, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 14, 0), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 15, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 15, 0), TimeSpan.FromHours(1)), Open = 0.891, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 16, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 16, 0), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 17, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 18, 0), TimeSpan.FromHours(1)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 19, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 19, 0), TimeSpan.FromHours(1)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 20, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 21, 0), TimeSpan.FromHours(1)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 22, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 22, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 23, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 23, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 24, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 24, 0), TimeSpan.FromHours(1)), Open = 0.8904, High = 0.8904, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 25, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 25, 0), TimeSpan.FromHours(1)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 26, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 29, 0), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 30, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 30, 0), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 31, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 34, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 35, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 36, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 37, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 37, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 38, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 38, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 39, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 40, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 41, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 44, 0), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 45, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 45, 0), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 46, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 46, 0), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 47, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 48, 0), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 49, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 49, 0), TimeSpan.FromHours(1)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 50, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 50, 0), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 51, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 51, 0), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 52, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 52, 0), TimeSpan.FromHours(1)), Open = 0.8908, High = 0.8908, Low = 0.8908, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 53, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 54, 0), TimeSpan.FromHours(1)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 55, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 56, 0), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 57, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 59, 0), TimeSpan.FromHours(1)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 0, 0, 0), TimeSpan.FromHours(1)) },
		};
		#endregion

		#region WSTSummer_OneMinuteData_Start20010625_230100_End20010625_235900
		private IList<OHLCV> WSTSummer_OneMinuteData_Start20010625_230100_End20010625_235900 = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 1, 0), TimeSpan.FromHours(2)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 2, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 3, 0), TimeSpan.FromHours(2)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 4, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 5, 0), TimeSpan.FromHours(2)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 6, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 6, 0), TimeSpan.FromHours(2)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 7, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 12, 0), TimeSpan.FromHours(2)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 13, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 14, 0), TimeSpan.FromHours(2)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 15, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 15, 0), TimeSpan.FromHours(2)), Open = 0.891, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 16, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 16, 0), TimeSpan.FromHours(2)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 17, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 18, 0), TimeSpan.FromHours(2)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 19, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 19, 0), TimeSpan.FromHours(2)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 20, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 21, 0), TimeSpan.FromHours(2)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 22, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 22, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 23, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 23, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 24, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 24, 0), TimeSpan.FromHours(2)), Open = 0.8904, High = 0.8904, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 25, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 25, 0), TimeSpan.FromHours(2)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 26, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 29, 0), TimeSpan.FromHours(2)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 30, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 30, 0), TimeSpan.FromHours(2)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 31, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 34, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 35, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 36, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 37, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 37, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 38, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 38, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 39, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 40, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 41, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 44, 0), TimeSpan.FromHours(2)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 45, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 45, 0), TimeSpan.FromHours(2)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 46, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 46, 0), TimeSpan.FromHours(2)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 47, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 48, 0), TimeSpan.FromHours(2)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 49, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 49, 0), TimeSpan.FromHours(2)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 50, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 50, 0), TimeSpan.FromHours(2)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 51, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 51, 0), TimeSpan.FromHours(2)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 52, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 52, 0), TimeSpan.FromHours(2)), Open = 0.8908, High = 0.8908, Low = 0.8908, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 53, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 54, 0), TimeSpan.FromHours(2)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 55, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 56, 0), TimeSpan.FromHours(2)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 57, 0), TimeSpan.FromHours(2)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 59, 0), TimeSpan.FromHours(2)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 0, 0, 0), TimeSpan.FromHours(2)) },
		};
		#endregion

		#region UTCWinter_OneMinuteData_Start20010325_220100_End20010325_225900
		private IList<OHLCV> UTCWinter_OneMinuteData_Start20010325_220100_End20010325_225900 = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 1, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 2, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 3, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 4, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 5, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 6, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 6, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 7, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 12, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 13, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 14, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 15, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 15, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 16, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 16, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 17, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 18, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 19, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 19, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 20, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 21, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 22, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 22, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 23, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 23, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 24, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 24, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8904, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 25, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 25, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 26, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 29, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 30, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 30, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 31, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 34, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 35, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 36, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 37, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 37, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 38, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 38, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 39, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 40, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 41, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 44, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 45, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 45, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 46, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 46, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 47, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 48, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 49, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 49, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 50, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 50, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 51, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 51, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 52, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 52, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8908, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 53, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 54, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 55, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 56, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 57, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 59, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 0, 0), TimeSpan.FromHours(0)) },
		};
		#endregion

		#region UTCSummer_OneMinuteData_Start20010625_220100_End20010625_225900
		private IList<OHLCV> UTCSummer_OneMinuteData_Start20010625_220100_End20010625_225900 = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 1, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 2, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 3, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 4, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 5, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 6, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 6, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 7, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 12, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 13, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 14, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 15, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 15, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 16, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 16, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 17, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 18, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 19, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 19, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 20, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 21, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 22, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 22, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 23, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 23, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 24, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 24, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8904, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 25, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 25, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 26, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 29, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 30, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 30, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 31, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 34, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 35, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 36, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 37, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 37, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 38, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 38, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 39, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 40, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 41, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 44, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 45, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 45, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 46, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 46, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 47, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 48, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 49, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 49, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 50, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 50, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 51, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 51, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 52, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 52, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8908, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 53, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 54, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 55, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 56, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 57, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 59, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 0, 0), TimeSpan.FromHours(0)) },
		};
		#endregion

		#region UTCSummer_OneMinuteData_Start20010625_210100_End20010625_215900
		private IList<OHLCV> UTCSummer_OneMinuteData_Start20010625_210100_End20010625_215900 = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 1, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 2, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 3, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 4, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 5, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 6, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 6, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 7, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 12, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 13, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 14, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 15, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 15, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 16, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 16, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 17, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 18, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 19, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 19, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 20, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 21, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 22, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 22, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 23, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 23, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 24, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 24, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8904, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 25, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 25, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 26, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 29, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 30, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 30, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 31, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 34, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 35, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 36, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 37, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 37, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 38, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 38, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 39, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 40, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 41, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 44, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 45, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 45, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 46, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 46, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 47, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 48, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 49, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 49, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 50, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 50, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 51, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 51, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 52, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 52, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8908, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 53, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 54, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 55, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 56, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 57, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 21, 59, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 0, 0), TimeSpan.FromHours(0)) },
		};
		#endregion

		#region UTCWinter_ThreeMinuteData_Start20010325_220000_End20010325_225700
		private IList<OHLCV> UTCWinter_ThreeMinuteData_Start20010325_220000_End20010325_225700 = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 0, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 3, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 3, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 6, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 6, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 9, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 12, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 15, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 15, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 18, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 18, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 21, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 21, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 24, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 24, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 27, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 27, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 30, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 30, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 33, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 33, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 36, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 36, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 39, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 39, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 42, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 42, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 45, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 45, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 48, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 48, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 51, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 51, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 54, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 54, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 57, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 22, 57, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 0, 0), TimeSpan.FromHours(0)) },
		};
		#endregion

		#region UTCSummer_ThreeMinuteData_Start20010625_220000_End20010625_225700
		private IList<OHLCV> UTCSummer_ThreeMinuteData_Start20010625_220000_End20010625_225700 = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 0, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 3, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 3, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 6, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 6, 0), TimeSpan.FromHours(0)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 9, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 12, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 15, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 15, 0), TimeSpan.FromHours(0)), Open = 0.891, High = 0.891, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 18, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 18, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 21, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 21, 0), TimeSpan.FromHours(0)), Open = 0.8909, High = 0.8909, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 24, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 24, 0), TimeSpan.FromHours(0)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 27, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 27, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 30, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 30, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 33, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 33, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 36, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 36, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 39, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 39, 0), TimeSpan.FromHours(0)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 42, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 42, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 45, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 45, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 48, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 48, 0), TimeSpan.FromHours(0)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 51, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 51, 0), TimeSpan.FromHours(0)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 54, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 54, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 57, 0), TimeSpan.FromHours(0)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 22, 57, 0), TimeSpan.FromHours(0)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 25, 23, 0, 0), TimeSpan.FromHours(0)) },
		};
		#endregion

		#region UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600
		private IList<OHLCV> UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 2, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 59, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 44, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 46, 0), TimeSpan.FromHours(0)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 47, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion
		
		#region UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600_Padding
		private IList<OHLCV> UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600_Padding = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 2, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 59, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 44, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 46, 0), TimeSpan.FromHours(0)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 47, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2002, 3, 27, 22, 46, 0), TimeSpan.FromHours(0)),
					Open = 0.0, High = 0.0, Low = 0.0, Close = 0.0, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2002, 3, 27, 22, 47, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600
		private IList<OHLCV> UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 2, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 21, 59, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 44, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 46, 0), TimeSpan.FromHours(0)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 47, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600_Padding
		private IList<OHLCV> UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600_Padding = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 2, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 21, 59, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 44, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 46, 0), TimeSpan.FromHours(0)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 47, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2002, 6, 27, 22, 46, 0), TimeSpan.FromHours(0)),
					Open = 0.0, High = 0.0, Low = 0.0, Close = 0.0, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2002, 6, 27, 22, 47, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600
		private IList<OHLCV> WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 0, 1, 0), TimeSpan.FromHours(1)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 0, 2, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 59, 0), TimeSpan.FromHours(1)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 0, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 0, 0), TimeSpan.FromHours(1)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 44, 0), TimeSpan.FromHours(1)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 45, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 46, 0), TimeSpan.FromHours(1)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 47, 0), TimeSpan.FromHours(1)),
				},
			};
		#endregion

		#region WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600_Padding
		private IList<OHLCV> WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600_Padding = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 0, 1, 0), TimeSpan.FromHours(1)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 0, 2, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 59, 0), TimeSpan.FromHours(1)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 0, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 0, 0), TimeSpan.FromHours(1)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 44, 0), TimeSpan.FromHours(1)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 45, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 46, 0), TimeSpan.FromHours(1)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 47, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2002, 3, 27, 23, 46, 0), TimeSpan.FromHours(1)),
					Open = 0.0, High = 0.0, Low = 0.0, Close = 0.0, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2002, 3, 27, 23, 47, 0), TimeSpan.FromHours(1)),
				},
			};
		#endregion

		#region WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600
		private IList<OHLCV> WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 0, 1, 0), TimeSpan.FromHours(2)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 0, 2, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 22, 59, 0), TimeSpan.FromHours(2)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 0, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 0, 0), TimeSpan.FromHours(2)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 44, 0), TimeSpan.FromHours(2)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 45, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 46, 0), TimeSpan.FromHours(2)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 47, 0), TimeSpan.FromHours(2)),
				},
			};
		#endregion

		#region WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600_Padding
		private IList<OHLCV> WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600_Padding = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 0, 1, 0), TimeSpan.FromHours(2)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 0, 2, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 22, 59, 0), TimeSpan.FromHours(2)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 0, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 0, 0), TimeSpan.FromHours(2)),
					Open = 0.8933, High = 0.8933, Low = 0.8933, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 44, 0), TimeSpan.FromHours(2)),
					Open = 0.8927, High = 0.8927, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 45, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 46, 0), TimeSpan.FromHours(2)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 23, 47, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2002, 4, 1, 23, 46, 0), TimeSpan.FromHours(2)),
					Open = 0.0, High = 0.0, Low = 0.0, Close = 0.0, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2002, 4, 1, 23, 47, 0), TimeSpan.FromHours(2)),
				},
			};
		#endregion
		
		#region UTCWinter_45MinuteData_Start20010326_230000_End20010327_221500
		private IList<OHLCV> UTCWinter_45MinuteData_Start20010326_230000_End20010327_221500 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 15, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 15, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8928, Low = 0.8927, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_45MinuteData_Start20010326_230000_End20010327_221500_Incomplete
		private IList<OHLCV> UTCWinter_45MinuteData_Start20010326_230000_End20010327_221500_Incomplete = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 15, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000
		private IList<OHLCV> UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 15, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 30, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8928, Low = 0.8927, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 15, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000_Incomplete
		private IList<OHLCV> UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000_Incomplete = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 15, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 30, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010626_223000_End20010627_223000
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010626_223000_End20010627_223000 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 15, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 21, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 30, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8928, Low = 0.8927, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 23, 15, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010626_223000_End20010627_223000_Incomplete
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010626_223000_End20010627_223000_Incomplete = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 15, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 21, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 30, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010331_214500_End20010331_214500
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010331_214500_End20010401_214500 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 21, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 22, 30, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 20, 15, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 22, 30, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010331_214500_End20010401_214500_Incomplete
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010331_214500_End20010401_214500_Incomplete = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 21, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 22, 30, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 20, 15, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 45, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region WSTWinter_OneMinuteData_Start20120101_050000_End20120101_060000
		private IList<OHLCV> WSTWinter_OneMinuteData_Start20120101_050000_End20120101_060000 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 0, 0), TimeSpan.FromHours(1)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 0, 0), TimeSpan.FromHours(1)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 1, 0), TimeSpan.FromHours(1)),
				},
			};
		#endregion

		#region WSTWinter_OneMinuteData_Start20120101_050000_End20120101_060000_Padding
		private IList<OHLCV> WSTWinter_OneMinuteData_Start20120101_050000_End20120101_060000_Padding = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 0, 0), TimeSpan.FromHours(1)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 0, 0), TimeSpan.FromHours(1)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2013, 1, 1, 6, 0, 0), TimeSpan.FromHours(1)),
					Open = 0.0,
					High = 0.0,
					Low = 0.0,
					Close = 0.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2013, 1, 1, 6, 1, 0), TimeSpan.FromHours(1)),
				},
			};
		#endregion

		#region WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000
		private IList<OHLCV> WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 0, 0), TimeSpan.FromHours(2)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 0, 0), TimeSpan.FromHours(2)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 1, 0), TimeSpan.FromHours(2)),
				},
			};
		#endregion
		
		#region WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000_Padding
		private IList<OHLCV> WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000_Padding = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 0, 0), TimeSpan.FromHours(2)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 0, 0), TimeSpan.FromHours(2)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2013, 6, 1, 6, 0, 0), TimeSpan.FromHours(2)),
					Open = 0.0,
					High = 0.0,
					Low = 0.0,
					Close = 0.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2013, 6, 1, 6, 1, 0), TimeSpan.FromHours(2)),
				},
			};
		#endregion

		#region UTCWinter_FourHourData_Start20120101_040000_
		private IList<OHLCV> UTCWinter_FourHourData_Start20120101_040000_ = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 4, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 130.0,
					Low = 90.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 8, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_FourHourData_Start20120601_000000_End20120601_040000
		private IList<OHLCV> UTCSummer_FourHourData_Start20120601_000000_End20120601_040000 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 0, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 4, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 4, 0, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 8, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_FourHourData_Start20120601_000000_End20120601_040000_Incomplete
		private IList<OHLCV> UTCSummer_FourHourData_Start20120601_000000_End20120601_040000_Incomplete = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 0, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 4, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region WSTWinter_OneHourData_Start20120101_050000_End20120101_060000
		private IList<OHLCV> WSTWinter_OneHourData_Start20120101_050000_End20120101_060000 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 0, 0), TimeSpan.FromHours(1)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 0, 0), TimeSpan.FromHours(1)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 1, 0), TimeSpan.FromHours(1)),
				},
			};
		#endregion

		#region WSTWinter_OneHourData_Start20120101_050000_End20120101_060000_Padding
		private IList<OHLCV> WSTWinter_OneHourData_Start20120101_050000_End20120101_060000_Padding = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 0, 0), TimeSpan.FromHours(1)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 0, 0), TimeSpan.FromHours(1)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2013, 1, 1, 6, 0, 0), TimeSpan.FromHours(1)),
					Open = 0.0,
					High = 0.0,
					Low = 0.0,
					Close = 0.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2013, 1, 1, 6, 1, 0), TimeSpan.FromHours(1)),
				},
			};
		#endregion

		#region WSTSummer_OneHourData_Start20120601_050000_End20120601_060000
		private IList<OHLCV> WSTSummer_OneHourData_Start20120601_050000_End20120601_060000 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 0, 0), TimeSpan.FromHours(2)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 0, 0), TimeSpan.FromHours(2)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 1, 0), TimeSpan.FromHours(2)),
				},
			};
		#endregion

		#region WSTSummer_OneHourData_Start20120601_050000_End20120601_060000_Padding
		private IList<OHLCV> WSTSummer_OneHourData_Start20120601_050000_End20120601_060000_Padding = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 0, 0), TimeSpan.FromHours(2)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 0, 0), TimeSpan.FromHours(2)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 6, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2013, 6, 1, 6, 0, 0), TimeSpan.FromHours(2)),
					Open = 0.0,
					High = 0.0,
					Low = 0.0,
					Close = 0.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2013, 6, 1, 6, 1, 0), TimeSpan.FromHours(2)),
				},
			};
		#endregion

		#region UTCWinter_OneHourData_Start20120101_040000_End20120101_050000
		private IList<OHLCV> UTCWinter_OneHourData_Start20120101_040000_End20120101_050000 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 4, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 0, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 6, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_OneHourData_Start20120101_040000_End20120101_050000_Incomplete
		private IList<OHLCV> UTCWinter_OneHourData_Start20120101_040000_End20120101_050000_Incomplete = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 4, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 5, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_OneHourData_Start20120601_030000_End20120601_040000
		private IList<OHLCV> UTCSummer_OneHourData_Start20120601_030000_End20120601_040000 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 3, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 4, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 4, 0, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 5, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion
		
		#region UTCSummer_OneHourData_Start20120601_030000_End20120601_040000_Incomplete
		private IList<OHLCV> UTCSummer_OneHourData_Start20120601_030000_End20120601_040000_Incomplete = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 3, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 4, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_OneMinuteData_Start20120101_230000_End20120101_230100
		private IList<OHLCV> UTCWinter_OneMinuteData_Start20120101_230000_End20120101_230100 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 2, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_OneMinuteData_Start20120101_230000_End20120101_230100_Padding
		private IList<OHLCV> UTCWinter_OneMinuteData_Start20120101_230000_End20120101_230100_Padding = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 2, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2013, 1, 1, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 0.0,
					High = 0.0,
					Low = 0.0,
					Close = 0.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2013, 1, 1, 23, 2, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010626_224500_End20010627_224500
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010626_224500_End20010627_224500 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 22, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 30, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 21, 15, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8928, High = 0.8928, Low = 0.8928, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 23, 30, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010626_224500_End20010627_224500_Incomplete
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010626_224500_End20010627_224500_Incomplete = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 22, 45, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 26, 23, 30, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 21, 15, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8932, Low = 0.8932, Close = 0.8932, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8933, High = 0.8933, Low = 0.8927, Close = 0.8927, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 6, 27, 22, 45, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010401_060000_End20010401_211500
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010401_060000_End20010401_211500 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 22, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 20, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 15, 0), TimeSpan.FromHours(0)),
				},
	
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 15, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8928, Low = 0.8927, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 22, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20010401_060000_End20010401_211500_Incomplete
		private IList<OHLCV> UTCSummer_45MinuteData_Start20010401_060000_End20010401_211500_Incomplete = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 22, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 31, 22, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 20, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 4, 1, 21, 15, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_FourHourData_Start20120601_030000_
		private IList<OHLCV> UTCSummer_FourHourData_Start20120601_030000_ = new[] 
			{
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 3, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 130.0,
					Low = 90.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 7, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_45MinuteData_Start20010326_230000_End20010326_221500
		private IList<OHLCV> UTCWinter_45MinuteData_Start20010326_230000_End20010326_221500 = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 15, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 15, 0), TimeSpan.FromHours(0)),
					Open = 0.8927, High = 0.8928, Low = 0.8927, Close = 0.8928, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 23, 0, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_45MinuteData_Start20010326_230000_End20010326_221500_Incomplete
		private IList<OHLCV> UTCWinter_45MinuteData_Start20010326_230000_End20010326_221500_Incomplete = new[] 
			{
				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 0.8961, High = 0.8961, Low = 0.8960, Close = 0.8960, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 23, 45, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV()
				{
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 21, 30, 0), TimeSpan.FromHours(0)),
					Open = 0.8932, High = 0.8933, Low = 0.8932, Close = 0.8933, Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 27, 22, 15, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100_Padding
		private IList<OHLCV> UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100_Padding = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 2, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2013, 6, 1, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 0.0,
					High = 0.0,
					Low = 0.0,
					Close = 0.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2013, 6, 1, 23, 2, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100
		private IList<OHLCV> UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 1, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 2, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCWinter_45MinuteData_Start20120101_223000_
		private IList<OHLCV> UTCWinter_45MinuteData_Start20120101_223000_ = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 130.0,
					Low = 90.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 15, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20120601_223000_
		private IList<OHLCV> UTCSummer_45MinuteData_Start20120601_223000_ = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 22, 30, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 130.0,
					Low = 90.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 15, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_45MinuteData_Start20120601_230000_
		private IList<OHLCV> UTCSummer_45MinuteData_Start20120601_230000_ = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 00, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 130.0,
					Low = 90.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 23, 45, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion
			    
		#region WSTWinter_OneMinuteData_Start20120101_090000_End20120101_090100
		private IList<OHLCV> WSTWinter_OneMinuteData_Start20120101_090000_End20120101_090100 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 9, 0, 0), TimeSpan.FromHours(1)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 9, 1, 0), TimeSpan.FromHours(1)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 9, 1, 0), TimeSpan.FromHours(1)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 9, 2, 0), TimeSpan.FromHours(1)),
				},
			};
		#endregion

		#region WSTSummer_OneMinuteData_Start20120601_090000_End20120601_090100
		private IList<OHLCV> WSTSummer_OneMinuteData_Start20120601_090000_End20120601_090100 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 9, 0, 0), TimeSpan.FromHours(2)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 9, 1, 0), TimeSpan.FromHours(2)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 9, 1, 0), TimeSpan.FromHours(2)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 9, 2, 0), TimeSpan.FromHours(2)),
				},
			};
		#endregion

		#region UTCWinter_OneMinuteData_Start20120101_080000_End20120101_080100
		private IList<OHLCV> UTCWinter_OneMinuteData_Start20120101_080000_End20120101_080100 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 8, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 8, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 8, 1, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 8, 2, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion

		#region UTCSummer_OneMinuteData_Start20120601_070000_End20120601_070100
		private IList<OHLCV> UTCSummer_OneMinuteData_Start20120601_070000_End20120601_070100 = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 7, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 120.0,
					Low = 90.0,
					Close = 110.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 7, 1, 0), TimeSpan.FromHours(0)),
				},

				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 7, 1, 0), TimeSpan.FromHours(0)),
					Open = 110.0,
					High = 130.0,
					Low = 100.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 6, 1, 7, 2, 0), TimeSpan.FromHours(0)),
				},
			};
		#endregion


		[TestMethod]
		public void Binner_Bin_SourceWST_InputNull_TargetUTC_NullData()
		{
			IList<OHLCV> data = null;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new List<OHLCV>();
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputEmpty_TargetUTC_EmptyData()
		{
			IList<OHLCV> data = new OHLCV[] { };
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new List<OHLCV>();
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_PeriodNotSet()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20120101_090000_End20120101_090100;
			Periods period = Periods.NotSet;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new List<OHLCV>();
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		
		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_WinterOneMinute_Success()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20120101_090000_End20120101_090100;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_OneMinuteData_Start20120101_080000_End20120101_080100;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerOneMinute_Success()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20120601_090000_End20120601_090100;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_OneMinuteData_Start20120601_070000_End20120601_070100;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_WinterOneHour_Success()
		{
			IList<OHLCV> data = WSTWinter_OneHourData_Start20120101_050000_End20120101_060000_Padding;
			Periods period = Periods.SixtyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_OneHourData_Start20120101_040000_End20120101_050000;
			var target = new Binner();
			
			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_WinterOneHour_IncompleteBin()
		{
			IList<OHLCV> data = WSTWinter_OneHourData_Start20120101_050000_End20120101_060000;
			Periods period = Periods.SixtyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_OneHourData_Start20120101_040000_End20120101_050000_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerOneHour_Success()
		{
			IList<OHLCV> data = WSTSummer_OneHourData_Start20120601_050000_End20120601_060000_Padding;
			Periods period = Periods.SixtyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_OneHourData_Start20120601_030000_End20120601_040000;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerOneHour_IncompleteBin()
		{
			IList<OHLCV> data = WSTSummer_OneHourData_Start20120601_050000_End20120601_060000;
			Periods period = Periods.SixtyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_OneHourData_Start20120601_030000_End20120601_040000_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_WinterFourHour_Success()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20120101_050000_End20120101_060000_Padding;
			Periods period = Periods.TwoFortyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_FourHourData_Start20120101_040000_;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_WinterFourHour_IncopleteBin()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20120101_050000_End20120101_060000;
			Periods period = Periods.TwoFortyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new OHLCV[] {};
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerFourHour_Success()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000_Padding;
			Periods period = Periods.TwoFortyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_FourHourData_Start20120601_000000_End20120601_040000;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerFourHour_IncompleteBin()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000;
			Periods period = Periods.TwoFortyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_FourHourData_Start20120601_000000_End20120601_040000_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Winter45Minute_Success()
		{
			IList<OHLCV> data = UTCWinter_OneMinuteData_Start20120101_230000_End20120101_230100_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20120101_223000_;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Winter45Minute_Success_IncompleteBin()
		{
			IList<OHLCV> data = UTCWinter_OneMinuteData_Start20120101_230000_End20120101_230100;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new OHLCV[] {};
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minute_Success()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20120601_223000_;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minute_IncompleteBin()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new OHLCV[] {};
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Winter45Minutes_FullDay_Success()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Winter45Minutes_FullDay_IncompleteBin()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Summer45Minutes_FullDay_Success()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010331_214500_End20010401_214500;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Summer45Minutes_FullDay_IncompleteBin()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010331_214500_End20010401_214500_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Winter45Minutes_FullDay_Success()
		{
			IList<OHLCV> data = UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Winter45Minutes_FullDay_IncompleteBin()
		{
			IList<OHLCV> data = UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_223000_End20010327_223000_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minutes_FullDay_Success()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010626_223000_End20010627_223000;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minutes_FullDay_IncompleteBin()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010626_223000_End20010627_223000_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_WinterOneMinute_SourceToUtc()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20010325_230100_End20010325_235900;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_OneMinuteData_Start20010325_220100_End20010325_225900;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerOneMinute_SourceToUtc()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20010625_230100_End20010625_235900;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_OneMinuteData_Start20010625_210100_End20010625_215900;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_WinterThreeMinutes_UtcToThree()
		{
			IList<OHLCV> data = UTCWinter_OneMinuteData_Start20010325_220100_End20010325_225900;
			Periods period = Periods.ThreeMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_ThreeMinuteData_Start20010325_220000_End20010325_225700;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_SummerThreeMinutes_UtcToThree()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20010625_220100_End20010625_225900;
			Periods period = Periods.ThreeMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_ThreeMinuteData_Start20010625_220000_End20010625_225700;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minute_Phase_Success()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20120601_230000_;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(-5));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minute_Phase_IncompleteBin()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20120601_230000_End20120601_230100;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new OHLCV[] {};
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(-5));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minutes_FullDay_Phase_Success()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010626_224500_End20010627_224500;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(-4));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Summer45Minutes_FullDay_Phase_IncompleteBin()
		{
			IList<OHLCV> data = UTCSummer_OneMinuteData_Start20010626_230100_End20010627_224600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010626_224500_End20010627_224500_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(-4));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Winter45Minutes_FullDay_Phase_Success()
		{
			IList<OHLCV> data = UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_230000_End20010327_221500;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+1));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputUTC_TargetUTC_Winter45Minutes_FullDay_Phase_IncompleteBin()
		{
			IList<OHLCV> data = UTCWinter_OneMinuteData_Start20010326_230100_End20010327_224600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_230000_End20010327_221500_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+1));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Summer45Minutes_FullDay_Phase_Success()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010401_060000_End20010401_211500;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+8));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Summer45Minutes_FullDay_Phase_IncompleteBin()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20010401_000100_End20010401_234600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_45MinuteData_Start20010401_060000_End20010401_211500_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+8));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerFourHour_Phase_Success()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000_Padding;
			Periods period = Periods.TwoFortyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_FourHourData_Start20120601_030000_;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+9));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerFourHour_Phase_IncompleteBin()
		{
			IList<OHLCV> data = WSTSummer_OneMinuteData_Start20120601_050000_End20120601_060000;
			Periods period = Periods.TwoFortyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new OHLCV[] {};
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+9));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Winter45Minutes_FullDay_Phase_Success()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600_Padding;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_230000_End20010326_221500;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+10));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_Winter45Minutes_FullDay_Phase_IncompleteBin()
		{
			IList<OHLCV> data = WSTWinter_OneMinuteData_Start20010327_000100_End20010327_234600;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCWinter_45MinuteData_Start20010326_230000_End20010326_221500_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+10));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerOneHour_Phase_Success()
		{
			IList<OHLCV> data = WSTSummer_OneHourData_Start20120601_050000_End20120601_060000_Padding;
			Periods period = Periods.SixtyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_OneHourData_Start20120601_030000_End20120601_040000;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+12));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Binner_Bin_SourceWST_InputWST_TargetUTC_SummerOneHour_Phase_IncompleteBin()
		{
			IList<OHLCV> data = WSTSummer_OneHourData_Start20120601_050000_End20120601_060000;
			Periods period = Periods.SixtyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UTCSummer_OneHourData_Start20120601_030000_End20120601_040000_Incomplete;
			var target = new Binner();

			var actual = target.Bin(data, period, timeZone, TimeSpan.FromHours(+12));

			Assert.IsTrue(actual.SequenceEqual(expected));
		}
	}
}
