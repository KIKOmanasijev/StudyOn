using StudyOn.Contracts.Responses;
using System.Collections.Generic;
using System.Net;

namespace StudyOn.Contracts.Responses
{
    /// <summary>
    ///     Base definition of the Response
    /// </summary>
    public class Response<T> : IResponse<T>
    {
        /// <summary>
        ///     Gets or sets status of the Response
        /// </summary>
        public HttpStatusCode Status { get; set; } = HttpStatusCode.OK;

        /// <summary>
        ///     Gets or sets List of ResponseMessage
        /// </summary>
        public List<ResponseMessage> Messages { get; set; } = new List<ResponseMessage>();

        /// <summary>
        ///     Gets or sets payload of the Response
        /// </summary>
        public T Payload { get; set; } = default(T);
    }
}
