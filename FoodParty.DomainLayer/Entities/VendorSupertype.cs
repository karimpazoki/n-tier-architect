namespace FoodParty.DomainLayer.Entities
{
    public class VendorSupertype : LongEntity
    {
        public string Title { get; set; }
        public string slug { get; set; }
        public string alias { get; set; }

        public ICollection<DealProject> DealProjects { get; set; }
    }
}