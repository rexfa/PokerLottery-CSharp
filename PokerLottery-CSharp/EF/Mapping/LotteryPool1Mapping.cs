using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerLottery.EF.Domain;

namespace PokerLottery.EF.Mapping
{
    public class LotteryPool1Mapping : IEntityTypeConfiguration<LotteryPool1>
    {
        public void Configure(EntityTypeBuilder<LotteryPool1> builder)
        {
            builder.ToTable("LotteryPool1");
            builder.HasKey(lp => lp.Id);
            builder.Property(lp => lp.A).IsRequired();
            builder.Property(lp => lp.B).IsRequired();
            builder.Property(lp => lp.C).IsRequired();
            builder.Property(lp => lp.D).IsRequired();
            builder.Property(lp => lp.BuyerId).IsRequired();
            builder.Property(lp => lp.OrderTime).IsRequired(false);
            builder.Property(lh => lh.Stat).IsRequired();
            builder.Property(lp => lp.Type).IsRequired();
        }
    }
}
