using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ESFramework.Exceptions
{
    public class ESException : Exception
    {
        public ESException() { }
        public ESException(string message) : base(message) { }
        public ESException(string message, Exception inner) : base(message, inner) { }
        public ESException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
