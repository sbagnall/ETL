namespace SteveBagnall.Etl.Specification
{
	public interface IEtlProcess
	{
		void Initialize();

		void Execute();
	}
}
