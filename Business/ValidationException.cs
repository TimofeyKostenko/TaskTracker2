using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ValidationException : IOException
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message) => Property = prop;
    }
}
