using StudyOn.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudyOn.Contracts.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SortablePageableRequest : IPageRequest
    {
        /// <summary>
        ///     Ignore pagination
        /// </summary>
        public bool All { get; set; }
        /// <summary>
        ///     Gets or sets current page
        /// </summary>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        ///     Gts or sets page size
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        ///     Gets or sets sortign of the page request
        /// </summary>
        public SortOrderEnum SortOrder { get; set; } = SortOrderEnum.Ascending;

        /// <summary>
        ///     Gets or sets sorting column of the page drequest
        /// </summary>
        public string OrderColumnName { get; set; } = string.Empty;
    }
}
