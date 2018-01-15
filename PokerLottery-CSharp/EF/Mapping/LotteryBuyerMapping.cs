using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerLottery.EF.Domain;

namespace PokerLottery.EF.Mapping
{
    public class LotteryBuyerMapping : IEntityTypeConfiguration<LotteryBuyer>
    {
        public void Configure(EntityTypeBuilder<LotteryBuyer> builder)
        {
            builder.ToTable("LotteryBuyer");
            builder.HasKey(lb => lb.Id);
            builder.Property(lb=>lb.ChannelName).IsRequired().HasMaxLength(100);
            //builder.Property(lb=>lb.)
        }
    }
}
