namespace demo_webapi.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Sccess { get; set; } = true;
        public string Message { get; set; } = null;
    }
}