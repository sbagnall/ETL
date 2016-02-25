namespace SteveBagnall.Etl.Specification
{
	public interface IManifest<T>
	{
		/// <summary>
		/// Get last item in manifest
		/// </summary>
		/// <returns></returns>
		T GetLast();

		/// <summary>
		/// Update manifest with new value
		/// </summary>
		/// <param name="current"></param>
		void Update(T current);

		/// <summary>
		/// Clear manifest
		/// </summary>
		void Clear();
	}
}
