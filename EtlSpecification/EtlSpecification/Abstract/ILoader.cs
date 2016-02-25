namespace SteveBagnall.Etl.Specification.Abstract
{
	public interface ILoader
	{
		void Load(ITransformationResult transformation);

		/// <summary>
		/// clear storage
		/// </summary>
		void Clear();
	}
}
