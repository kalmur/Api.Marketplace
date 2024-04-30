using MediatR;

namespace Api.Marketplace.Application.Workflows.Photos.UpdatePhoto
{
    public class UpdatePhotoNotification : INotification
    {
        public UpdatePhotoNotification(int photoId, int listingId, string url, bool isPrimary)
        {
            PhotoId = photoId;
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
