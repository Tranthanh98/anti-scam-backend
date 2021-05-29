using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Model
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
        public ResponseModel()
        {
            Messages = new List<string>();
        }

    }
    public class ResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }
    }
}
