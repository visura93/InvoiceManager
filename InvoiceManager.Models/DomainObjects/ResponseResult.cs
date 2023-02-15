using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models.DomainObjects
{
    public class ResponseResult
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        object Data { get; set; }
    }
}
