namespace SteveBagnall.Etl.Specification.Abstract
{
	public interface IExtractionResult<T>
	{
		T CurrentPosition { get; }
		bool IsSuccess { get; }
		void CleanUp();
	}
}
