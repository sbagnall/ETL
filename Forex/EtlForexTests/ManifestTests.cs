namespace SteveBagnall.Etl.EtlForexTests
{
	using System;
	using System.Data;
	using System.IO;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Extract;
	using SteveBagnall.Persistence;
	using SteveBagnall.Persistence.Common;

	[TestClass]
	public class ManifestTests
	{
		private Manifest GetTarget(string sourceName = "test")
		{
			var source = new Mock<ISourceSpecification>();
			source.SetupGet(x => x.SourceName).Returns(sourceName);
			source.SetupGet(x => x.TimeZoneInfo).Returns(TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			return new Manifest(source.Object); 
		}

		[TestCleanup]
		public void CleanUp()
		{
			var di = new DirectoryInfo(@"D:\Data\Forex.Test.Manifest");
			if (di.Exists)
			{
				di.Delete(true);
			}

			di = new DirectoryInfo(@"D:\Data\Forex.Test.Manifest");
			if (di.Exists)
			{
				di.Delete(true);
			}
		}

		private ILocalStore CreateUnmockedStore()
		{
			var local = new LocalStore("Forex.Test.Manifest");

			return local;
		}

		private DataTable CreateDataTable(string name)
		{
			DataTable dt = new DataTable(name);
			dt.Columns.Add("SourceName", typeof(string));
			dt.Columns.Add("LocalDateTime", typeof(DateTime));

			return dt;
		}

		private void UpdateRow(DataRow row, FormatObject formatObject)
		{
			row.SetField<string>("SourceName", formatObject.SourceName);
			row.SetField<DateTime>("LocalDateTime", TimeZoneInfo.ConvertTime(formatObject.DateTime, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")).DateTime);
		}

		[TestMethod]
		public void Manifest_GetLastFormatObject_NoStoreExists()
		{
			var store = new Mock<ILocalStore>();
			store.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

			var target = GetTarget("test");
			target.LocalStore = store.Object;

			var actual = target.GetLast();

			Assert.AreEqual(actual, default(FormatObject));
		}

		[TestMethod]
		public void Manifest_GetLastFormatObject_StoreExistsMultipleNames()
		{
			DataTable dt = CreateDataTable("manifest");
			var expected = new FormatObject("test1", new DateTime(2003, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			DataRow dr = dt.NewRow();
			UpdateRow(dr, expected);
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			UpdateRow(dr, new FormatObject("test2", new DateTime(2004, 6, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")));
			dt.Rows.Add(dr);

			var store = new Mock<ILocalStore>();
			store.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
			store.Setup(x => x.Read(It.IsAny<string>())).Returns(dt);

			var target = GetTarget("test1");
			target.LocalStore = store.Object;

			var actual = target.GetLast();

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void Manifest_GetLastFormatObject_StoreExistsWrongSourceName()
		{
			DataTable dt = CreateDataTable("manifest");
			
			DataRow dr = dt.NewRow();
			UpdateRow(dr, new FormatObject("test1", new DateTime(2003, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")));
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			UpdateRow(dr, new FormatObject("test2", new DateTime(2004, 6, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")));
			dt.Rows.Add(dr);

			var store = new Mock<ILocalStore>();
			store.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
			store.Setup(x => x.Read(It.IsAny<string>())).Returns(dt);

			var target = GetTarget("test3");
			target.LocalStore = store.Object;

			var actual = target.GetLast();

			Assert.AreEqual(actual, default(FormatObject));
		}
		
		[TestMethod]
		public void Manifest_GetLastFormatObject_StoreExists()
		{
			DataTable dt = CreateDataTable("test");

			DataRow dr = dt.NewRow();
			UpdateRow(dr, new FormatObject("test", new DateTime(2003, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")));
			dt.Rows.Add(dr);

			var store = new Mock<ILocalStore>();
			store.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
			store.Setup(x => x.Read(It.IsAny<string>())).Returns(dt);

			var target = GetTarget("test");
			target.LocalStore = store.Object;

			var expected = new FormatObject("test", new DateTime(2003, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var actual = target.GetLast();
			
			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void Manifest_UpdateManifest_DoesNotExist()
		{
			var formatObject = new FormatObject("test", new DateTime(2003, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			var store = new Mock<ILocalStore>();
			store.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

			var target = GetTarget();
			target.LocalStore = store.Object;
			
			target.Update(formatObject);

			store.Verify(x => x.Exists("test"), Times.Once());
			store.Verify(x => x.Write(It.IsAny<DataTable>(), false), Times.Once());
		}

		[TestMethod]
		public void Manifest_UpdateManifest_Exists()
		{
			var formatObject = new FormatObject("test", new DateTime(2003, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			DataTable dt = CreateDataTable("test");

			DataRow dr = dt.NewRow();
			UpdateRow(dr, formatObject);
			dt.Rows.Add(dr);

			var store = new Mock<ILocalStore>();
			store.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
			store.Setup(x => x.Read("test")).Returns(dt);

			var target = GetTarget();
			target.LocalStore = store.Object;

			target.Update(formatObject);

			store.Verify(x => x.Exists("test"), Times.Once());
			store.Verify(x => x.Read("test"), Times.Once());
			store.Verify(x => x.Write(dt, true), Times.Once());
		}

		[TestMethod]
		public void Manifest_UpdateManifest_UpdatesOnlyOneRow()
		{
			var formatObject1 = new FormatObject("test1", new DateTime(2001, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject2 = new FormatObject("test", new DateTime(2001, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var formatObject3 = new FormatObject("test", new DateTime(2002, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			DataTable dtStored = CreateDataTable("test");
			DataRow drStored = dtStored.NewRow();
			UpdateRow(drStored, formatObject1);
			dtStored.Rows.Add(drStored);
			drStored = dtStored.NewRow();
			UpdateRow(drStored, formatObject2);
			dtStored.Rows.Add(drStored);

			DataTable dtExpected = CreateDataTable("test");
			DataRow drExpected = dtExpected.NewRow();
			UpdateRow(drExpected, formatObject1);
			dtExpected.Rows.Add(drExpected);
			drExpected = dtExpected.NewRow();
			UpdateRow(drExpected, formatObject3);
			dtExpected.Rows.Add(drExpected);

			var store = new Mock<ILocalStore>();
			store.Setup(x => x.Exists("test")).Returns(true);
			store.Setup(x => x.Read("test")).Returns(dtStored);
			store.Setup(x => x.Write(It.IsAny<DataTable>(), true)).Callback<DataTable, bool>((x, y) =>
				{
					for (int r = 0; r < dtExpected.Rows.Count; r++)
					{
						for (int c = 0; c < dtExpected.Columns.Count; c++)
						{
							Assert.AreEqual(dtExpected.Rows[r][c], x.Rows[r][c]);
						}
					}
				});

			var target = GetTarget();
			target.LocalStore = store.Object;

			target.Update(formatObject3);

			store.Verify(x => x.Exists("test"), Times.Once());
			store.Verify(x => x.Read("test"), Times.Once());
			store.Verify(x => x.Write(It.IsAny<DataTable>(), true), Times.Once());
		}

		[TestMethod]
		public void Manifest_UnMocked()
		{
			var expected = new FormatObject("test", new DateTime(2003, 1, 1), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			DataTable dt = CreateDataTable("test");

			DataRow dr = dt.NewRow();
			UpdateRow(dr, expected);
			dt.Rows.Add(dr);

			var store = CreateUnmockedStore();

			var target = GetTarget("test");
			target.LocalStore = store;

			target.Update(expected);

			var actual = target.GetLast();

			Assert.AreEqual(actual, expected);
		}

		[TestMethod]
		public void Manifest_Clear()
		{
			var target = GetTarget("test1");
			var other = GetTarget("test2");
			var expected = new DateTime(2003, 1, 1);

			target.LocalStore = CreateUnmockedStore();
			other.LocalStore = CreateUnmockedStore();

			var format1 = new FormatObject("test1", expected, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
			var format2 = new FormatObject("test2", expected, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));

			target.Update(format1);
			other.Update(format2);

			target.Clear();

			Assert.AreEqual(new DateTime(2003, 1, 1), other.GetLast().DateTime);
			Assert.AreEqual(default(DateTime), target.GetLast().DateTime);
		}
	}
}
