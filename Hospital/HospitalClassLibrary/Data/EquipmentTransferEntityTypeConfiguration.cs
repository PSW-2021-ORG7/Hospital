using HospitalClassLibrary.RoomEquipment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalClassLibrary.Data
{
    public class EquipmentTransferEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentTransfer>
    {
        public void Configure(EntityTypeBuilder<EquipmentTransfer> builder)
        {
            builder.ToTable("EquipmentTransfer", AppDbContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.OwnsOne(p => p.TransferLocationInfo)
                .Property(c => c.DestinationRoomId).HasColumnName("DestinationRoomId");
            builder.OwnsOne(p => p.TransferLocationInfo)
                .Property(c => c.SourceRoomId).HasColumnName("SourceRoomId");

            builder.OwnsOne(p => p.TransferDateInfo)
                .Property(c => c.TransferDate).HasColumnName("TransferDate");
            builder.OwnsOne(p => p.TransferDateInfo)
                .Property(c => c.TransferDuration).HasColumnName("TransferDuration");

            builder.OwnsOne(p => p.TransferEquipmentInfo)
                .Property(c => c.EquipmentId).HasColumnName("EquipmentId");
            builder.OwnsOne(p => p.TransferEquipmentInfo)
                .Property(g => g.Quantity).HasColumnName("Quantity");
        }
    }
}
