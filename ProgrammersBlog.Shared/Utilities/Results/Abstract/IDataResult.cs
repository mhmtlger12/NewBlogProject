namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult
    {
        public T Data { get; } //new DataResult<Category>(ResultStatus.Succes,category)
                               //new DataResult<<IList<Category>>(ResultStatus.Succes,category)

    }
}
