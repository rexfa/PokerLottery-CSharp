using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerLottery.EF.Domain;

namespace PokerLottery.EF.Mapping
{
    public class LotteryIssueMapping : IEntityTypeConfiguration<LotteryIssue>
    {
        public void Configure(EntityTypeBuilder<LotteryIssue> builder)
        {
            builder.ToTable("LotteryIssue");
            builder.HasKey(li => li.Id);
            builder.Property(li => li.IssueName).IsRequired().HasMaxLength(100);
            builder.Property(li => li.IssueSetting).IsRequired().HasMaxLength(1000);
            builder.Property(li => li.LotteryParameters).IsRequired().HasMaxLength(1000);
            builder.Property(li => li.Result).IsRequired().HasMaxLength(500);
            builder.Property(li => li.OrderQuantity).IsRequired();
            builder.Property(li => li.StopOn).IsRequired();
            builder.Property(li => li.BeginOn).IsRequired();
            builder.Property(li => li.CreatedOn).IsRequired();
        }
    }
}
