using System;
using System.Collections.Generic;
using System.Text;

namespace take.webhook.core.DTO
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Message = string.Empty;
            Success = true;
        }

        public T Object { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public class Collection
        {
            public List<T> List { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
            public int? Total { get; set; }

            public Collection()
            {
                Message = string.Empty;
                Success = true;
            }
        }


    }
}

