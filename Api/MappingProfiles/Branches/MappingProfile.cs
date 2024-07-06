﻿using App.Shared.Models.Branches;
using App.Shared.Models.Branches.DTO;
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