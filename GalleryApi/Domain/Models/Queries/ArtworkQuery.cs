using System;
namespace GalleryApi.Domain.Models.Queries
{
    public class ArtworkQuery : Query
    {
        public ArtworkQuery(int page, int itemsPerPage) : base(page, itemsPerPage)
        {
        }
    }
}
