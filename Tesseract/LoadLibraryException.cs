using System;
using System.Collections.Generic;
using System.Text;

namespace Tesseract
{
    [Serializable]
#if NETSTANDARD2_0
    public class LoadLibraryException : Exception
#else
    public class LoadLibraryException : SystemException
#endif
    {
        public LoadLibraryException() { }
        public LoadLibraryException(string message) : base(message) { }
        public LoadLibraryException(string message, Exception inner) : base(message, inner) { }
        protected LoadLibraryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
