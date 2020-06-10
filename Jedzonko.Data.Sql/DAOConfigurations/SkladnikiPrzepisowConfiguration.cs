using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;
using System;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class SkladnikiPrzepisowConfiguration : IEntityTypeConfiguration<SkladnikiPrzepisow>
    {
        public void Configure(EntityTypeBuilder<SkladnikiPrzepisow> builder)
        {
            
            builder.Property(x => x.Jednostka).IsRequired().HasColumnType("varchar(40)");
           


            builder.HasOne(x => x.Skladniki)
                 .WithMany(x => x.SkladnikiPrzepisow)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasForeignKey(x => x.SkladnikiId);

            builder.HasOne(x => x.Przepisy)
                .WithMany(x => x.SkladnikiPrzepisow)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PrzepisyId);

            builder.ToTable("SkladnikPrzepisu");
        }
    }
}
