using AutoMapper;
using CollegeManagement.API.Core.Domain;
using CollegeManagement.API.Core.Domain.Procedures;
using CollegeManagement.API.Data.Entities;
using Newtonsoft.Json;
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

                CreateMap<SPUserLoginValidationsEntity,LoginResponceVM>()
                  .ForMember(dest => dest.ResponseCode, src => src.MapFrom(x => x.ResponseCode))
                  .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                  .ForMember(dest => dest.adminDetails, src => src.Ignore());

                CreateMap<SPGetDepartmentdataEntity, DepartmentResponceVM>()
                  .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                  .ForMember(dest => dest.Response, src => src.Ignore());

                CreateMap<SPInsertFacultyDetailsEntity, InsertFacultyResponceVM>()
                      .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                      .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPGetAllFacultyDataEntity, FacultyListResponceVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.Ignore());

                CreateMap<SPDeleteFacultyByIdEntity, DeleteFacultyResponceVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));
        }
    }
}
