﻿namespace StudyOn.Contracts.Requests
{
    /// <summary>
    ///     Definitino for grid paging
    /// </summary>
    public interface IPageable
    {
        /// <summary>
        ///     Gets or sets current page
        /// </summary>
        int CurrentPage { get; set; }

        /// <summary>
        ///     Gets or sets page size
        /// </summary>
        int PageSize { get; set; }
    }
}
