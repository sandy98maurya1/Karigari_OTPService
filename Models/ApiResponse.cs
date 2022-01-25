using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   
    public partial class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public partial class ApiExposeResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Error { get; set; }
    }

    public partial class ApiListResponse<T> : ApiResponse<T>
    {
        public int TotalRecords { get; set; } //1000
        public int TotalRecordsAfterFilter { get; set; } //900
        public int RecordsInOneSlot { get; set; } //50
        public int PageSize { get; set; } //900/50=18        
    }


    public partial class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
    }
}
