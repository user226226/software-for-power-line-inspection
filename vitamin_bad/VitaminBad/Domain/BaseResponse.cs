using Microsoft.AspNetCore.Http;

namespace VitaminBad.Domain
{
    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
        ErrorDB = 0,
        NotFound = 404,
        WrongData = 403
    }
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
    }
}
