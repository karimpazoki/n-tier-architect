using FoodParty.DomainLayer;

namespace FoodParty.DomainLayer.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : this(AppConstants.MessageTemplate.DataNotFound)
        {

        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
