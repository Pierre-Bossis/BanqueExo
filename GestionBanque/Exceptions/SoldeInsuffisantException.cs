using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Exceptions
{
    internal class SoldeInsuffisantException : Exception
    {
        private readonly string _message;
        public SoldeInsuffisantException(string message) : base(message)
        {
            _message = message;
        }
    }
}
