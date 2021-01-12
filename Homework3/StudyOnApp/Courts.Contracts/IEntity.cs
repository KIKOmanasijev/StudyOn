namespace Court.Contracts
{
    /// <summary>
    /// </summary>
    public interface IEntity<T>
    {
        /// <summary>
        /// </summary>
        T Id { get; set; }
    }
}
