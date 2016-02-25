namespace SteveBagnall.Etl.Forex.Common
{
	using System.Linq;
	using SteveBagnall.Etl.Specification;
	using SteveBagnall.Financial.DataAccess;

	public class Loader : ILoader<FormatObject>
	{
		private IFinancialRepository _repo;

		public ISourceSpecification Source { get; set; }

		public IBinner Binner { get; set; }

		public Loader()
		{ }

		public Loader(ISourceSpecification source, IBinner binner, IFinancialRepository repository)
		{
			Source = source;
			Binner = binner;
			_repo = repository;
		}

		public void Load(ITransformationResult transformation)
		{
			var result = transformation as TransformationResult;

			_repo.Insert(result.ToFinancialData().ToList());
		}

		public void Clear()
		{
			_repo.Delete();
		}

		public void EnsureNext(FormatObject lastLoaded)
		{
			_repo.DeleteOnOrAfter(Source.GetUpperBoundExclusive(lastLoaded));
		}
	}
}
