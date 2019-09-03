using System;
using System.Collections.Generic;

namespace Weather.Data.V1
{

    #region Response

    /// <summary>
    ///     Đối tượng trả về
    /// </summary>
    public class Response
    {
        private int status;

        public Response(Code code, string message)
        {
            Code = code;
            Message = message;
        }

        public Response(string message)
        {
            Message = message;
        }

        public Response()
        {
        }

        public Response(int status, string message)
        {
            this.status = status;
            Message = message;
        }

        /// <summary>
        ///     Mã lỗi trả về
        /// </summary>
        public Code Code { get; set; } = Code.Success;

        /// <summary>
        ///     Thông tin chi tiết
        /// </summary>
        public string Message { get; set; } = "Thành công";

         /// <summary>
        ///     Thông tin chi tiết
        /// </summary>
        public long TotalTime { get; set; } = 0;
    }

    /// <summary>
    ///     Trả về Lỗi
    /// </summary>
    public class ResponseError : Response
    {
        public ResponseError(Code code, string message, IList<Dictionary<string, string>> errorDetail = null) : base(
            code,
            message)
        {
            ErrorDetail = errorDetail;
        }

        public IList<Dictionary<string, string>> ErrorDetail { get; set; }
    }

    /// <summary>
    ///     Trả về dạng đối tượng
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseObject<T> : Response
    {
        public ResponseObject(T data)
        {
            Data = data;
        }
        public ResponseObject(T data,string message)
        {
            Data = data;
            Message = message;
        }
        public ResponseObject(T data,string message, Code code)
        {
            Code = code;
            Data = data;
            Message = message;
        }
        /// <summary>
        ///     Dữ liệu trả về
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    ///     Trả về dạng mảng
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseList<T> : Response
    {
        public ResponseList(IList<T> data)
        {
            Data = data;
        }

        public ResponseList()
        {
        }

        /// <summary>
        ///     Danh sách dữ liệu trả về
        /// </summary>
        public IList<T> Data { get; set; }
    }

    /// <summary>
    ///     Trả về dạng phân trang
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponsePagination<T> : Response
    {
        public ResponsePagination(Pagination<T> data)
        {
            Data = data;
        }

        /// <summary>
        ///     Danh sách dữ liệu trả về
        /// </summary>
        public Pagination<T> Data { get; set; }
    }

    /// <summary>
    ///     Trả về kết quả cập nhật dữ liệu
    /// </summary>
    public class ResponseUpdate : Response
    {
        public ResponseUpdate(Guid id)
        {
            Data = new ResponseUpdateModel {Id = id};
        }

        public ResponseUpdate(Guid id, string message) : base(message)
        {
            Data = new ResponseUpdateModel {Id = id};
        }

        public ResponseUpdate(Code code, string message, Guid id) : base(code, message)
        {
            Data = new ResponseUpdateModel {Id = id};
        }

        public ResponseUpdate()
        {
        }

        /// <summary>
        ///     Danh sách dữ liệu trả về
        /// </summary>
        public ResponseUpdateModel Data { get; set; }
    }

    /// <summary>
    ///     Trả về kết quả cập nhật nhiều dữ liệu
    /// </summary>
    public class ResponseUpdateMulti : Response
    {
        public ResponseUpdateMulti(IList<ResponseUpdate> data)
        {
            Data = data;
        }

        public ResponseUpdateMulti()
        {
        }

        /// <summary>
        ///     Danh sách dữ liệu trả về
        /// </summary>
        public IList<ResponseUpdate> Data { get; set; }
    }

    /// <summary>
    ///     Trả về kết quả xóa dữ liệu
    /// </summary>
    public class ResponseDelete : Response
    {
        public ResponseDelete(Guid id, string name)
        {
            Data = new ResponseDeleteModel {Id = id, Name = name};
        }

        public ResponseDelete(Code code, string message, Guid id, string name) : base(code, message)
        {
            Data = new ResponseDeleteModel {Id = id, Name = name};
        }

        public ResponseDelete()
        {
        }

        /// <summary>
        ///     Danh sách dữ liệu trả về
        /// </summary>
        public ResponseDeleteModel Data { get; set; }
    }

    /// <summary>
    ///     Trả về kết quả xóa nhiều dữ liệu
    /// </summary>
    public class ResponseDeleteMulti : Response
    {
        public ResponseDeleteMulti(IList<ResponseDelete> data)
        {
            Data = data;
        }

        public ResponseDeleteMulti()
        {
        }

        /// <summary>
        ///     Danh sách dữ liệu trả về
        /// </summary>
        public IList<ResponseDelete> Data { get; set; }
    }

    /// <summary>
    ///     Trả về kết quả tìm kiếm cuộn
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseScroll<T> : Response
    {
        public ResponseScroll(Pagination<T> data,
            string scrollId, string scrollTime,
            List<string> listHighlightOtherField)
        {
            Data = data;
            ListHighlightOtherField = listHighlightOtherField;
            ScrollId = scrollId;
            ScrollTime = scrollTime;
        }

        public Pagination<T> Data { get; set; }
        public List<string> ListHighlightOtherField { get; set; }
        public string ScrollId { get; set; }
        public string ScrollTime { get; set; }
    }

    #endregion

    /// <summary>
    ///     Đối tượng phân trang
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pagination<T>
    {
        public Pagination()
        {
            Size = 20;
            Page = 1;
        }

        /// <summary>
        ///     Vị trí trang hiện tại
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        ///     Tổng số trang toàn hệ thống
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        ///     Số lượng bản ghi trên một trang
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     Số lượng bản ghi trả về
        /// </summary>
        public int NumberOfElements { get; set; }

        /// <summary>
        ///     Tổng số bản ghi tìm kiếm được
        /// </summary>
        public int TotalElements { get; set; }

        /// <summary>
        ///     Danh sách dữ liệu trả về
        /// </summary>
        public IEnumerable<T> Content { get; set; }
    }

    /// <summary>
    ///     Đối tượng mã trả về
    /// </summary>
    public enum Code
    {
        Success = 200,
        BadRequest = 400,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        ServerError = 500
    }

    /// <summary>
    ///     Đối tượng kết quả cập nhật
    /// </summary>
    public class ResponseUpdateModel
    {
        public Guid Id { get; set; }
    }

    /// <summary>
    ///     Đối tượng kết quả xóa
    /// </summary>
    public class ResponseDeleteModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    ///     Đối tượng chung
    /// </summary>
    public class BaseObject
    {
        public DateTime Modified { get; set; }
        public string Modifier { get; set; }
    }
}