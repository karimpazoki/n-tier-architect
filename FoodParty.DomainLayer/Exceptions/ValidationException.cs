using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodParty.DomainLayer.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base(AppConstants.MessageTemplate.ValidationMessage)
        {

        }

        public ValidationException(string message) : base(message)
        {

        }
    }
}
