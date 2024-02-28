using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Mappers
{
    public class CollegeMapper : Profile
    {
        public CollegeMapper()
        {
                CreateMap<RolesEntity,RoleDetailsVM>().ReverseMap();
                CreateMap<AdminDetailsEntity, AdminDetailsVM>().ReverseMap();
        }
    }
}
