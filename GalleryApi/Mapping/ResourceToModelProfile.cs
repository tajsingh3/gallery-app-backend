using System;
using AutoMapper;
using GalleryApi.Domain.Models;
using GalleryApi.Domain.Models.Queries;
using GalleryApi.Resources;

namespace GalleryApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveArtworkResource, Artwork>();
            CreateMap<UpdateArtworkResource, Artwork>();
            CreateMap<QueryResource, Query>();


        }
    }
}
