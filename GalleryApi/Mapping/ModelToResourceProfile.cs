using System;
using System.Collections.Generic;
using AutoMapper;
using GalleryApi.Domain.Models;
using GalleryApi.Resources;

namespace GalleryApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Artwork, ArtworkResource>();
        }
    }
}
