using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.ApiResponse
{
    public class Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public long? Count { get; set; }
        public bool IsSuccess { get; set; }
    }
}
