namespace FoodParty.DomainLayer.Entities
{
    public class VendorSupertype : LongEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Alias { get; set; }

        public ICollection<DealProject> DealProjects { get; set; }
    }
}