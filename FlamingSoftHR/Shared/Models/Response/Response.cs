﻿namespace FlamingSoftHR.Shared.Models.Response
{
    public class Response<T>
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Response()
        {
            this.Success = 0;
        }
    }
}
