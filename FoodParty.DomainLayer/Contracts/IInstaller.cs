﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodParty.DomainLayer.Contracts
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration, IServiceProvider provider);

    }
}
