using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodParty.DomainLayer
{
    public static class AppConstants
    {
        public const int Apikey = 2;
        public const int PageSize = 20;
        public record MessageTemplate
        {
            public const string Required = "این {0} الزامی می باش";
            public const string DataNotFound = "Not Found";
            public const string ValidationMessage = "";
        }
    }
}
