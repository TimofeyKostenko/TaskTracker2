using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class EntityNotExistException : Exception
    {
        public EntityNotExistException(string entity, int id)
            :base($"{entity} with id - {id} does not exist.")
        {

        }
    }
}
