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
        }
    }
}
