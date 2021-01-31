using Court.Contracts.Enums;

namespace Court.Contracts.Responses
{
    /// <summary>
    ///     Definition of the response message
    /// </summary>
    public class ResponseMessage
    {
        /// <summary>
        ///     Gets or sets type of the response message
        /// </summary>
        public ResponseMessageEnum Type { get; set; }

        /// <summary>
        ///     Gets or sets code of the response message
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Gets mesage arguments 
        /// </summary>
        public object[] Args { get; set; }
    }
}
