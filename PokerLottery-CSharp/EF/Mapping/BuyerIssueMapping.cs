using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerLottery.EF.Domain;

namespace PokerLottery.EF.Mapping
{
    public class BuyerIssueMapping : IEntityTypeConfiguration<BuyerIssue>
    {
        public void Configure(EntityTypeBuilder<BuyerIssue> builder)
        {
            builder.ToTable("BuyerIssue");
            builder.HasKey(bi => bi.Id);
            builder.Property(bi => bi.IssueId).IsRequired();
            builder.Property(bi => bi.PurchaseQuantity).IsRequired();
        }
    }
}
