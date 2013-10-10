using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using PinPayments.Models;

namespace PinPayments
{
    [Serializable]
    public class PinException : ApplicationException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public PinError PinError { get; set; }

        public PinException()
        {
        }

        public PinException(HttpStatusCode httpStatusCode, PinError pinError, string message)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            PinError = pinError;
        }
    }
}
