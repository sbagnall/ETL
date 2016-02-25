namespace SteveBagnall.Etl.Specification
{
	public interface IExtractionResult<T>
	{
		T CurrentPosition { get; }
		bool IsSuccess { get; }
		void CleanUp();
	}
}
