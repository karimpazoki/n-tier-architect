using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodParty.DomainLayer.Enums;

namespace FoodParty.DomainLayer
{

    public class AppSetting
    {
        public ConnectionString? ConnectionStrings { get; set; }
        public DBConnectionType DbConnectionType { get; set; }
        
        public class ConnectionString
        {
            public string? SqlServerConnection { get; set; }
            public string? MySqlConnection { get; set; }
        }
    }
}
