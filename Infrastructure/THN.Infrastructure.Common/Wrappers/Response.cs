using System;
using System.Collections.Generic;
using System.Text;

namespace THN.Infrastructure.Common.Wrappers
{
    public class Response<T>
    {
        public Response() { }

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public T Data { get; set; }
    }
}
