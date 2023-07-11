using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodParty.DomainLayer.Contracts;
using FoodParty.DomainLayer.Enums;

namespace FoodParty.DomainLayer.Entities
{
    public class DealProject : LongEntity ,ILoggableEntity
    {
        [StringLength(100)]
        public string Title { get; set; }
        public DateTime StartData { get; set; }
        public DateTime EndDate { get; set; }
        public DealProjectStatus Status { get; set; }
        public long VendorSuperTypeId { get; set; }
        public int CapacityPerOrder { get; set; }
        public int CapacityPerUser { get; set; }
        public int ItemCountPerOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<VendorSupertype> VendorSupertypes { get; set; }
    }
}
