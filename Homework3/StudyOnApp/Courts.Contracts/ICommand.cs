namespace Court.Contracts
{
    /// <summary>
    ///     Dafinition of Command
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    public interface ICommand<TRequest, TResult>
    {
        /// <summary>
        ///     Execute
        /// </summary>
        /// <param name="dataContext">Database context</param>
        /// <returns>Definition of Result</returns>
        IResult<TResult> Execute(IContext dataContext);

        /// <summary>
        /// Command Request
        /// </summary>
        TRequest Request { get; set; }
    }
}
