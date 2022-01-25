using System;
using System.Collections.Generic;
using System.Text;
using HospitalClassLibrary.Schedule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalClassLibrary.Data
{
    public class WorkdayEntityTypeConfiguration : IEntityTypeConfiguration<Workday>
    {
        public void Configure(EntityTypeBuilder<Workday> builder)
        {
            builder.ToTable("Workday", AppDbContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.OwnsMany(o => o.Appointments);
        }
    }
}
