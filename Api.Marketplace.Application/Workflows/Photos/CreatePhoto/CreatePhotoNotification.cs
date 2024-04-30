using MediatR;

namespace Api.Marketplace.Application.Workflows.Photos.CreatePhoto
{
    public class CreatePhotoNotification : INotification
    {
        public CreatePhotoNotification(int listingId, string url, bool isPrimary)
        {
            ListingId = listingId;
            Url = url;
            IsPrimary = isPrimary;
        }

        public int ListingId { get; }
        public string Url { get; }
        public bool IsPrimary { get; }
    }
}
