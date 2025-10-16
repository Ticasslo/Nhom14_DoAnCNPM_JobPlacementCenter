using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPC.Business.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() { }
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception inner) : base(message, inner) { }
    }

    public class DomainValidationException : BusinessException
    {
        public string ErrorCode { get; }
        public DomainValidationException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
        public DomainValidationException(string errorCode, string message, Exception inner) : base(message, inner)
        {
            ErrorCode = errorCode;
        }
    }
}
