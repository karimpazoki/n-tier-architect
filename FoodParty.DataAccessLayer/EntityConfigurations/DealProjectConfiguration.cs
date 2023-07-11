using FoodParty.DomainLayer;
using FoodParty.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodParty.DataAccessLayer.EntityConfigurations
{
    public class DealProjectConfiguration : IEntityTypeConfiguration<DealProject>
    {
        public void Configure(EntityTypeBuilder<DealProject> builder)
        {
            // to separate domain layer from implemetation
            // folan Entity man map mishe be folan table, flan FK ro dare , char len , ...
            // builder.Ignore(x => x.Status); use deligate
        }
    }
}
