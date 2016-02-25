namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Forex.Abstract;
	using SteveBagnall.Etl.Forex.Transform;
	using SteveBagnall.Etl.Forex.Transform.Abstract;
	using SteveBagnall.Financial.Types;

	[TestClass]
	public class BinnerTests
	{
		private IList<OHLCV> SourceOneMinute = new[] 
		{
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 1, 1), TimeSpan.FromHours(1)), Open = 0.891, High = 0.8911, Low = 0.891, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 2, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 3, 1), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 4, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 5, 1), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 6, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 6, 1), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 7, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 12, 1), TimeSpan.FromHours(1)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 13, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 14, 1), TimeSpan.FromHours(1)), Open = 0.8911, High = 0.8911, Low = 0.8911, Close = 0.8911, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 15, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 15, 1), TimeSpan.FromHours(1)), Open = 0.891, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 16, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 16, 1), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 17, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 18, 1), TimeSpan.FromHours(1)), Open = 0.8909, High = 0.891, Low = 0.8909, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 19, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 19, 1), TimeSpan.FromHours(1)), Open = 0.891, High = 0.891, Low = 0.891, Close = 0.891, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 20, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 21, 1), TimeSpan.FromHours(1)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 22, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 22, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 23, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 23, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 24, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 24, 1), TimeSpan.FromHours(1)), Open = 0.8904, High = 0.8904, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 25, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 25, 1), TimeSpan.FromHours(1)), Open = 0.8904, High = 0.8905, Low = 0.8904, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 26, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 29, 1), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 30, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 30, 1), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 31, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 34, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 35, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 36, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 37, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 37, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 38, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 38, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 39, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 40, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8904, Close = 0.8904, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 41, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 44, 1), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 45, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 45, 1), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 46, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 46, 1), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8905, Low = 0.8905, Close = 0.8905, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 47, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 48, 1), TimeSpan.FromHours(1)), Open = 0.8905, High = 0.8909, Low = 0.8905, Close = 0.8909, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 49, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 49, 1), TimeSpan.FromHours(1)), Open = 0.8909, High = 0.8909, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 50, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 50, 1), TimeSpan.FromHours(1)), Open = 0.8906, High = 0.8906, Low = 0.8906, Close = 0.8906, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 51, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 51, 1), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 52, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 52, 1), TimeSpan.FromHours(1)), Open = 0.8908, High = 0.8908, Low = 0.8908, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 53, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 54, 1), TimeSpan.FromHours(1)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 55, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 56, 1), TimeSpan.FromHours(1)), Open = 0.8907, High = 0.8907, Low = 0.8907, Close = 0.8907, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 57, 0), TimeSpan.FromHours(1)) },
			new OHLCV() { BeginDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 25, 23, 59, 1), TimeSpan.FromHours(1)), Open = 0.8908, High = 0.8908, Low = 0.8907, Close = 0.8908, Volume = 0, EndDateTimeOffset = new DateTimeOffset(new DateTime(2001, 3, 26, 0, 0, 0), TimeSpan.FromHours(1)) },
		};

		private IList<OHLCV> UtcOneMinute = new[] 
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

		private IList<OHLCV> UtcThreeMinute = new[] 
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



		private IList<OHLCV> FullDay45DataUTC = new[] 
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

		private IList<OHLCV> FullDay45DataWST = new[] 
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

		private IList<OHLCV> FullDay45Expected = new[] 
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

		private IList<OHLCV> FourHourData = new[] 
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

		private IList<OHLCV> FourHourDataExpected = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 3, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 130.0,
					Low = 90.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 7, 0, 0), TimeSpan.FromHours(0)),
				},
			};

		private IList<OHLCV> HourData = new[] 
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

		private IList<OHLCV> HourDataExpected = new[] 
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

		private IList<OHLCV> FortyFiveMinuteData = new[] 
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

		private IList<OHLCV> FortyFiveMinuteDataExpected = new[] 
			{ 
				new OHLCV() 
				{ 
					BeginDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 0, 0), TimeSpan.FromHours(0)),
					Open = 100.0,
					High = 130.0,
					Low = 90.0,
					Close = 120.0,
					Volume = 0,
					EndDateTimeOffset = new DateTimeOffset(new DateTime(2012, 1, 1, 23, 45, 0), TimeSpan.FromHours(0)),
				},
			};

		private IList<OHLCV> MinuteData = new[] 
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

		private IList<OHLCV> MinuteDataExpected = new[] 
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

		[TestMethod]
		public void Test_Bin_NullData()
		{
			IList<OHLCV> data = null;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new List<OHLCV>();

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_Bin_EmptyData()
		{
			IList<OHLCV> data = new OHLCV[] { };
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new List<OHLCV>();

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_Bin_PeriodNotSet()
		{
			IList<OHLCV> data = MinuteData;
			Periods period = Periods.NotSet;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = new List<OHLCV>();

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		
		[TestMethod]
		public void Test_Bin_UtcMinuteSuccess()
		{
			IList<OHLCV> data = MinuteData;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = MinuteDataExpected;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_Bin_UtcHourSuccess()
		{
			IList<OHLCV> data = HourData;
			Periods period = Periods.SixtyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = HourDataExpected;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);
			
			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_Bin_UtcFourHourSuccess()
		{
			IList<OHLCV> data = FourHourData;
			Periods period = Periods.TwoFortyMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = FourHourDataExpected;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_Bin_Utc45MinInputUTCSuccess()
		{
			IList<OHLCV> data = FortyFiveMinuteData;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = FortyFiveMinuteDataExpected;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_Bin_WstFullDayOddPeriod()
		{
			IList<OHLCV> data = FullDay45DataWST;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = FullDay45Expected;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_Bin_UtcFullDayOddPeriod()
		{
			IList<OHLCV> data = FullDay45DataUTC;
			Periods period = Periods.FortyFiveMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = FullDay45Expected;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_SourceToUtc()
		{
			IList<OHLCV> data = SourceOneMinute;
			Periods period = Periods.OneMinute;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UtcOneMinute;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}

		[TestMethod]
		public void Test_UtcToThree()
		{
			IList<OHLCV> data = UtcOneMinute;
			Periods period = Periods.ThreeMinutes;
			TimeZoneInfo timeZone = TimeZoneInfo.Utc;

			var expected = UtcThreeMinute;

			var source = new Mock<ISourceSpecification>();
			source.Setup(x => x.DataStartTime).Returns(new TimeSpan(0, 0, 0));
			source.Setup(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var target = new Binner(source.Object);

			var actual = target.Bin(data, period, timeZone);

			Assert.IsTrue(actual.SequenceEqual(expected));
		}
	}
}
