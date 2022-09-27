using FlamingSoftHR.Shared.Models;

namespace FlamingSoftHR.Client.Data
{
    public class Response<T>
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
