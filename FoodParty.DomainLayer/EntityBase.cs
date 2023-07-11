using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodParty.DomainLayer.Contracts;

namespace FoodParty.DomainLayer
{
    public abstract class EntityBase<TKey> : IEntity
    {
        [Key]
        public TKey Id { get; set; }
    }
    public abstract class LongEntity : EntityBase<long>
    {

    }
}
