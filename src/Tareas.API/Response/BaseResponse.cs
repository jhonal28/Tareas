namespace Tareas.API.Response
{
    public class BaseResponse<T>
    {
        public BaseResponse(T data, string message)
        {
            Data = data;
            Message = message;
        }
        public string Message { get; set; }
        public T Data { get; set; }

        public static BaseResponse<T> Build(T data, string message) 
        { 
            return new BaseResponse<T>(data, message);
        }
    }
}
