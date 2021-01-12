using Court.Contracts.Enums;

namespace Court.Contracts.Requests
{
    /// <summary>
    ///     Definition for paging request
    /// </summary>
    public interface IPageRequest : IRequest, IPageable
    {
        /// <summary>
        ///     Gets or sets sorting of the paged request
        /// </summary>
        SortOrderEnum SortOrder { get; set; }

        /// <summary>
        ///     Gets or sets sorting column of the page drequest
        /// </summary>
        string OrderColumnName { get; set; }
    }
}
