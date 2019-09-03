using System;
using System.Collections.Generic;

namespace Weather.Data.V1
{
    //For serial
    public class OldResponseList<T> 
    {
        public T[] Data { get; set; }
        public int TotalCount { get; set; }
        public int DataCount { get; set; }
        public int Status { get; set; }
        public decimal SalaryCount { get; set; }
        public string Message { get; set; }
    }
    public class OldResponseObj<T>
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public int DataCount { get; set; }
        public decimal SalaryCount { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
    public class OldResponse<T> : OldResponse
    {
        public T Data { get; set; }

        public int TotalCount { get; set; }

        public int DataCount { get; set; }
        public decimal SalaryCount { get; set; }

        public OldResponse() { }

        public OldResponse(int status, string message = null, T data = default(T))
                : base(status, message)
        {
            Data = data;
            TotalCount = 0;
            DataCount = 0;
        }

        public OldResponse(int status, string message = null, T data = default(T), int dataCount = 0, int totalCount = 0)
            : base(status, message)
        {
            Data = data;
            TotalCount = totalCount;
            DataCount = dataCount;
        }
        
    }
    public class OldResponse1<T> : OldResponse
    {
        public T Data { get; set; }

        public OldResponse1(int status, string message = null, T data = default(T))
            : base(status, message)
        {
            Data = data;
        }

    }

    public class OldResponse
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public OldResponse(int status, string message = null)
        {
            Status = status;
            Message = message;
        }

        public OldResponse() { }
    }

}