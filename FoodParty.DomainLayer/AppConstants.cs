using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodParty.DomainLayer
{
    public static class AppConstants
    {
        public const int apikey = 2;
        public const int PAGE_SIZE = 20;
        public record MessageTemplate
        {
            public const string REQUIRED = "این {0} الزامی می باش";
            public const string DATA_NOT_FOUND = "Not Found";
            public const string VALIDATION_MESSAGE = "";
        }
    }
}
