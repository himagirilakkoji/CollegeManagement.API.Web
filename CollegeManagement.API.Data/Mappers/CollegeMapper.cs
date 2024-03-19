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

                CreateMap<SPUserLoginValidationsEntity,LoginResponseVM>()
                          .ForMember(dest => dest.ResponseCode, src => src.MapFrom(x => x.ResponseCode))
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.adminDetails, src => src.Ignore());

                CreateMap<SPGetDepartmentdataEntity, DepartmentResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.Ignore());

                CreateMap<SPInsertFacultyDetailsEntity, InsertFacultyResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPGetAllFacultyDataEntity, FacultyListResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.Ignore());

                CreateMap<SPGetAllFacultyDataWithPaginationEntity, FacultyListResponseWithPaginationVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.TotalRecords, src => src.MapFrom(x => x.TotalRecords))
                          .ForMember(dest => dest.Response, src => src.Ignore());

            CreateMap<SPDeleteFacultyByIdEntity, DeleteFacultyResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPUpdateFacultyByIdEntity, UpdateFacultyResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPInsertStudentDetailsEntity, InsertStudentResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPDeleteStudentByIdEntity, DeleteStudentResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPInsertStudentExamMarksDetailsEntity, InsertStudentMarksResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPCourseLevelReportEntity, CourseLevelReportResponseVM>().ReverseMap();
                CreateMap<SPSubjectLevelReportEntity, SubjectLevelReportResponseVM>().ReverseMap();

                CreateMap<SPUpdateStudentByIdEntity, UpdateStudentResponseVM>()
                          .ForMember(dest => dest.ErrorProcedure, src => src.MapFrom(x => x.ErrorProcedure))
                          .ForMember(dest => dest.Response, src => src.MapFrom(x => x.Response));

                CreateMap<SPStudentMarksEntity, StudentMarksResponseVM>().ReverseMap();
        }
    }
}
