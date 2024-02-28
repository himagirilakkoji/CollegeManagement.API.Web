using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data
{
    public class CollegeDbQueryContext : CollegeDbContext<CollegeDbQueryContext>
    {
        public CollegeDbQueryContext(DbContextOptions<CollegeDbQueryContext> options) : base(options)
        {
                
        }
    }
}
