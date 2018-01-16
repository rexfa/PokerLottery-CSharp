using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerLottery.EF.Domain;

namespace PokerLottery.EF.Mapping
{
    public class LotteryHistoryMapping : IEntityTypeConfiguration<LotteryHistory>
    {
        public void Configure(EntityTypeBuilder<LotteryHistory> builder)
        {
            builder.ToTable("LotteryHistory");
            builder.HasKey(lh => lh.Id);
            builder.Property(lh => lh.A).IsRequired();
            builder.Property(lh => lh.B).IsRequired();
            builder.Property(lh => lh.C).IsRequired();
            builder.Property(lh => lh.D).IsRequired();
            builder.Property(lh => lh.BuyerId).IsRequired();
            builder.Property(lh => lh.OrderTime).IsRequired();
            builder.Property(lh => lh.IssueId).IsRequired();
            builder.Property(lh => lh.Type).IsRequired();
        }
    }
}
