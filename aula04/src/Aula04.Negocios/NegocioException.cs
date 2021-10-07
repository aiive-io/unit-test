using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aula04.Negocios
{
    public class NegocioException : Exception
    {
        public NegocioException()
        {
        }

        public NegocioException(string message) : base(message)
        {
        }

        public NegocioException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NegocioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
