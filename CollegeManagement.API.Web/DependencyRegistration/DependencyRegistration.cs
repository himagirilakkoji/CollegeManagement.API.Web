using CollegeManagement.API.Data;
using CollegeManagement.API.Data.CommandsHandler;
using CollegeManagement.API.Data.QueriesHandler;
using CollegeManagement.API.Services.AdminRepository;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.API.Web.DependencyRegistration
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Add all service registration here
            services.AddDbContext<CollegeDbCommandContext>(options => options.UseSqlServer(configuration.GetConnectionString("CollegeDatabase"), options => options.EnableRetryOnFailure()));
            services.AddDbContext<CollegeDbQueryContext>(options => options.UseSqlServer(configuration.GetConnectionString("CollegeDatabaseIntentReadOnly"), options => options.EnableRetryOnFailure())
                                                                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<UserLoginValidation>();
            services.AddScoped<GetDepartmentDetails>();
            services.AddScoped<InsertFacultyDetails>();
            services.AddScoped<GetAllFacultyDetails>();
            services.AddScoped<DeleteFacultyById>();
            services.AddScoped<UpdateFacultyById>();
            services.AddScoped<InsertStudentDetails>();
            services.AddScoped<GetAllStudentDetails>();
            services.AddScoped<DeleteStudentById>();
            services.AddScoped<InsertStudentExamMarksDetails>();
            services.AddScoped<GetFacultyCourseLevelReportByGuid>();
            services.AddScoped<GetFacultySubjectLevelReportByGuid>();
            services.AddScoped<GetAllFacultyDetailsWithPagination>();
            return services;
        }
    }
}
