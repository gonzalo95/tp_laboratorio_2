using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class TrackingIdRepetioException : Exception
    {
        public TrackingIdRepetioException(string mensaje) : base(mensaje) { }

        public TrackingIdRepetioException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
    }
}

