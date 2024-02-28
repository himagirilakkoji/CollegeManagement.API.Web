using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data
{
    public class CollegeDbCommandContext : CollegeDbContext<CollegeDbCommandContext>
    {
        public CollegeDbCommandContext(DbContextOptions<CollegeDbCommandContext> options) : base(options)
        {
                
        }
    }
}
