using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Core.Response
{
    public class ResponseModel<T>
    {
        public ResponseModel(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    
}
