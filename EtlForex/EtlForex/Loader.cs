namespace SteveBagnall.Etl.Forex
{
	using System;
	using System.Linq;
	using SteveBagnall.Etl.Forex.Transform.Abstract;
	using SteveBagnall.Etl.Specification.Abstract;
	using SteveBagnall.Financial.DataAccess;
	using SteveBagnall.Financial.Types;

	public class Loader : ILoader
	{
		private IFinancialRepository _repo;

		public IBinner Binner { get; set; }

		public Loader()
		{ }

		public Loader(IBinner binner, IFinancialRepository repository)
		{
			Binner = binner;
			_repo = repository;
		}

		public void Load(ITransformationResult transformation)
		{
			var result = transformation as OneMinuteTransformationResult;

			_repo.Insert(Periods.OneMinute, result.Pair, result.OneMinuteData);

			foreach (var period in Enum.GetValues(typeof(Periods)).Cast<Periods>().Where(x => ((x != Periods.NotSet) && (x != Periods.OneMinute))))
			{
				_repo.Insert(period, result.Pair, Binner.Bin(result.OneMinuteData, period, TimeZoneInfo.Utc));
			}

            _repo.SaveChanges();
		}

		public void Clear()
		{
			_repo.Delete();
		}
	}
}
