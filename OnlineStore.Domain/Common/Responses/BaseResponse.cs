namespace OnlineStore.Domain.Common.Responses
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }

        public ErrorResponse Error { get; set; } = new ErrorResponse(200, "OK");
    }
}
