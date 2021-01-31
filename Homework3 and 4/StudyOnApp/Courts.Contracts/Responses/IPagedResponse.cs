using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Court.Contracts.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedResponse<T> : IResponse<IEnumerable<T>>
    {
        /// <summary>
        /// 
        /// </summary>
        Meta Meta { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResponse<T> : IPagedResponse<T>
    {
        /// <summary>
        ///     Gets or sets https status of the response
        /// </summary>
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;

        /// <summary>
        ///     Gets or sets list of messages of the response
        /// </summary>
        public List<ResponseMessage> Messages { get; set; } = new List<ResponseMessage>();

        /// <summary>
        /// </summary>
        public IEnumerable<T> Payload { get; set; } = default(IEnumerable<T>);

        /// <summary>
        /// 
        /// </summary>
        public Meta Meta { get; set; } = new Meta();
    }

    /// <summary>
    /// 
    /// </summary>
    public class Meta
    {
        /// <summary>
        ///     Gets or sets total numer of records
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        ///     Gets or sets current page
        /// </summary>
        public int CurrentPage { get; set; } = 1;

        /// <summary>
        ///     Gets or sets page size
        /// </summary>
        public int PageSize { get; set; }
    }
}
