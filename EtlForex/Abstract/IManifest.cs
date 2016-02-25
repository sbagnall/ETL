namespace SteveBagnall.Etl.Forex.Abstract
{
	using SteveBagnall.Etl.Forex.Extract.Abstract;
	using SteveBagnall.Etl.Specification.Abstract;
	using SteveBagnall.Financial.FinancialTypes;
	using SteveBagnall.Persistence.Abstract;

	public interface IManifest : IManifest<FormatObject>
	{
		ILocalStore LocalStore { get; }

		ISourceSpecification Source { get; }
	}
}
