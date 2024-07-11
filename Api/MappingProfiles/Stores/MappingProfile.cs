using AutoMapper;

namespace Api.MappingProfiles.Stores
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreAddOrUpdateDTO>().ReverseMap();
        }
    }
}