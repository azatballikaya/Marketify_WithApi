using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.Business.DTOs.Response
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public static Response<T> Success(T data) { 
            return new Response<T> { Data = data, IsSuccess = true };
        }
        public static Response<T> Fail()
        {
            return new Response<T> { Data=null,IsSuccess = false};
        }
    }
    public class Response
    {
        
        public bool IsSuccess { get; set; }
        public static Response Success()
        {
            return new Response {  IsSuccess = true };
        }
        public static Response Fail()
        {
            return new Response { IsSuccess=false};
        }
    }
}
