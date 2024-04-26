namespace Api.Marketplace.Domain.Entities
{
    public class Review : AuditableEntity
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int ListingId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public virtual User User { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
