using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static APICustomer.API.ModelViews.CustomerModelViews;

namespace APICustomer.API.ErorrMessages
{
    public class CustomerMessage
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class CustomerReponse : CustomerMessage
    {      
        public CustomerModelView Customer { get; set; }
    }
}
