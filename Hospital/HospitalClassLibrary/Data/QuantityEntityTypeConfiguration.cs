using HospitalClassLibrary.RoomEquipment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalClassLibrary.Data
{
    public class QuantityEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentTransfer>
    {
        public void Configure(EntityTypeBuilder<EquipmentTransfer> builder)
        {
            builder.ToTable("EquipmentTransfer", AppDbContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.OwnsOne(o => o.Quantity);
        }
    }
}
