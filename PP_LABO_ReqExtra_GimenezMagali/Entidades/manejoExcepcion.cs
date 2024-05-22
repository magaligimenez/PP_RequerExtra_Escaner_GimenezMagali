using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class DocumentoDuplicadoException : Exception
    {
        /*Extiendo exception para luego poder manejarla y le proporciono 3 constructores para manejar diferentes formas
         de inicializacion de excepciones*/
        public DocumentoDuplicadoException()
        {
        }

        public DocumentoDuplicadoException(string message) : base(message)
        {
        }

        public DocumentoDuplicadoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
