namespace Api.Marketplace.Application.DTOs
{
    public class PhotoDto
    {
        public PhotoDto(int listingId, string url, bool isPrimary)
        {
            ListingId = listingId;
            Url = url;
            IsPrimary = isPrimary;
        }

        public int PhotoId { get; }
        public int ListingId { get; }
        public string Url { get; }
        public bool IsPrimary { get; }
    }
}
