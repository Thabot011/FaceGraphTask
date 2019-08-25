using AutoMapper;
using FaceGraphEnities;

namespace FaceGraphProject.DTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Image, ImageDTO>().ReverseMap();
        }

    }
}
