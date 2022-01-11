using HospitalClassLibrary.RoomEquipment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalClassLibrary.Data
{
    public class RoomEntityTypeConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms", AppDbContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.OwnsOne(o => o.RoomDimensions);
        }
    }
}
