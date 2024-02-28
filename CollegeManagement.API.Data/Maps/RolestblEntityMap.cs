using CollegeManagement.API.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagement.API.Data.Maps
{
    public class RolestblEntityMap : IEntityTypeConfiguration<RolesEntity>
    {
        public void Configure(EntityTypeBuilder<RolesEntity> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Roles");
            builder.HasKey(x => x.RoleID);
            builder.Property(x => x.RoleID).HasColumnName("RoleID");
            builder.Property(x => x.RoleName).HasColumnName("RoleName");

            // Many to one relationship between Admin and Role table.
            builder.HasMany(x => x.adminDetailsEntity)
                .WithOne(x => x!.rolesEntities!)
                .HasForeignKey(x => x.AdminRoleID);
        }
    }
}
