
namespace Product.Common
{
    public enum ActionCode
    {
        Insert = 0,Read = 1, Update = 2, Delete = 3
    }
    public enum HttpCode
    {
        Ok = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500
    }

    public class Result
    {
        public bool Success { get; set; } = true;

        public HttpCode HttpCode { get; set; } = HttpCode.Ok;

        public object? Data { get; set; }
    }
}
