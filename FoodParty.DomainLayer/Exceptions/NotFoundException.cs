using FoodParty.DomainLayer;

namespace FoodParty.DomainLayer.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : this(AppConstants.MessageTemplate.DATA_NOT_FOUND)
        {

        }
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
