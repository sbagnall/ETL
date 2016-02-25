namespace SteveBagnall.Etl.Specification.Abstract
{
	public interface IEtlProcess
	{
		void Initialize();

		void Execute();
	}
}
