using System;
using GalleryApi.Domain.Models;

namespace GalleryApi.Domain.Services.Communication
{
    public class ArtworkResponse : BaseResponse<Artwork>
    {
        public ArtworkResponse(Artwork artwork) : base(artwork)
        {
        }

        public ArtworkResponse(string message) : base(message)
        {

        }
    }
}
