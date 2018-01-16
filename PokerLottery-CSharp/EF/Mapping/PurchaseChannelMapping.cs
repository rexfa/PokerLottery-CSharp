using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerLottery.EF.Domain;

namespace PokerLottery.EF.Mapping
{
    public class PurchaseChannelMapping : IEntityTypeConfiguration<PurchaseChannel>
    {
        public void Configure(EntityTypeBuilder<PurchaseChannel> builder)
        {
            builder.ToTable("PurchaseChannel");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.ChannelKey).IsRequired().HasMaxLength(100);
            builder.Property(pc => pc.ChannelName).IsRequired().HasMaxLength(100);
            builder.Property(pc => pc.PushURL).IsRequired().HasMaxLength(500);
            builder.Property(pc => pc.PullURL).IsRequired().HasMaxLength(500);
        }
    }
}
