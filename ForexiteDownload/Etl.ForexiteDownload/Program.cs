namespace SteveBagnall.ScheduledTasks.ForexiteETL
{
	using System;
	using System.IO;
	using Microsoft.Practices.Unity;
	using NDesk.Options;
	using SteveBagnall.Core;
	using SteveBagnall.Etl.Forex;
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Forex.Transform;
	using SteveBagnall.Etl.Specification;
	using SteveBagnall.Financial.DataAccess;
	using SteveBagnall.Financial.DataAccess.SQLite;
	using SteveBagnall.Financial.DataAccess.SQLite.Forex.Common;

	class Program
	{
		static void Main(string[] args)
		{
			var config = new EtlForexConfig();

			OptionSet options = new OptionSet();
			options.Add("h|?|help", "Show available options", x => options.WriteOptionDescriptions(Console.Out));
			options.Add("r|restore", "Restore database to a clean state", x => config.IsRestoreCleanDb = true);
			options.Add("t=|temp=", "Specify temp folder location", x => config.RootTempFolder = x);
			options.Add("d=|db=", "Specify SQLite database folder location", x => config.RootSQLiteFolder = x);

			options.Parse(args);

			IEtlProcess process = Resolve(config, "forexite_test.db");

			if (config.IsRestoreCleanDb)
			{
				process.Initialize();
			}

			process.Execute();
		}

		public static IEtlProcess Resolve(IEtlForexConfig config, string dbName)
		{
			using (IUnityContainer container = new UnityContainer())
			{
				container.RegisterInstance(typeof(IEtlForexConfig), config);

				container.RegisterType<ISourceSpecification, ForexiteSourceSpecification>();
				var source = container.Resolve<ISourceSpecification>();

				container.RegisterType(typeof(IExtracter<>), typeof(Extracter));
				container.RegisterType(typeof(ITransformer<>), typeof(Transformer));
				container.RegisterType(typeof(ILoader<>), typeof(Loader));

				container.RegisterType(typeof(IManifest<>), typeof(Manifest), 
					new InjectionConstructor(new object[] { source, dbName }));
				
				container.RegisterType(typeof(IFileCompression), source.FileCompressionHandler, new InjectionConstructor());

				container.RegisterType<ICleaner, Cleaner>();
				container.RegisterType<IBinner, Binner>();
				
				container.RegisterType<IConnectionFactory, SQLiteConnectionFactory>(
					new InjectionConstructor(new object[] { new DirectoryInfo(config.RootSQLiteFolder), dbName }));

				container.RegisterType<IFinancialRepository, FinancialRepository>();
				
				container.RegisterType(typeof(IEtlProcess), typeof(EtlProcess<FormatObject>));
				return container.Resolve<IEtlProcess>();
			}
		}
	}
}
