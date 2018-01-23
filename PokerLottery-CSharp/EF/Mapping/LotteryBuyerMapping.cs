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
            builder.Property(lb=>lb.BuyerChName).IsRequired().HasMaxLength(100);
            builder.Property(lb => lb.ChannelSysId).IsRequired().HasMaxLength(200);
            builder.Property(lb => lb.Weixin).IsRequired(false).HasMaxLength(200);
            builder.Property(lb => lb.CreatedOn).IsRequired();
            //builder.Property(lb=>lb.)
        }
    }
}
