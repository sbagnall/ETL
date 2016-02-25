namespace SteveBagnall.Etl.Specification
{
	public interface ILoader<T>
	{
		void Load(ITransformationResult transformation);

		/// <summary>
		/// clear storage
		/// </summary>
		void Clear();

		/// <summary>
		/// Ensure that the next batch can be loaded 
		/// i.e. delete any partial data that may have been loaded after <paramref name="lastLoaded"/>
		/// (for instance if the last run aborted half way through )
		/// </summary>
		/// <param name="lastLoaded"></param>
		void EnsureNext(T lastLoaded);
	}
}
