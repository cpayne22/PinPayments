using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PinPayments.Models;

namespace PinPayments
{
    public class Response
    {
        public string error { get; set; }
        public string error_description { get; set; }
        public string charge_token { get; set; }
        public Message[] messages { get; set; }
        
    }
}
