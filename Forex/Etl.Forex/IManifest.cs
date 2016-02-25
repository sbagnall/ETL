namespace SteveBagnall.Etl.Forex
{
	using SteveBagnall.Etl.Forex.Common;
	using SteveBagnall.Etl.Specification;
	using SteveBagnall.Persistence;

	public interface IManifest : IManifest<FormatObject>
	{
		ILocalStore LocalStore { get; }

		ISourceSpecification Source { get; }
	}
}
