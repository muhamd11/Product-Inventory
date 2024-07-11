using App.Shared.Models.PlacesModules.Branches;
using App.Shared.Models.PlacesModules.Branches.DTO;
using AutoMapper;

namespace Api.MappingProfiles.Branches
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Branch, BranchAddOrUpdateDTO>().ReverseMap();
        }
    }
}