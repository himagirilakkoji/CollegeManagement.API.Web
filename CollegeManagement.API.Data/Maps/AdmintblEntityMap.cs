using CollegeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Maps
{
    public class AdmintblEntityMap : IEntityTypeConfiguration<AdminDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<AdminDetailsEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Admin");
            builder.HasKey(x => x.AdminID);
            builder.Property(x => x.AdminID).HasColumnName("AdminID");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.Username).HasColumnName("Username");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(x => x.AdminRoleID).HasColumnName("AdminRoleID");
            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt");
        }
    }
}
