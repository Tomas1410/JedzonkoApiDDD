using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;
using System;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class RodzajePrzepisowConfiguration : IEntityTypeConfiguration<RodzajePrzepisow>
    {
        public void Configure(EntityTypeBuilder<RodzajePrzepisow> builder)
        {
            builder.HasOne(x => x.Przepisy)
                 .WithMany(x => x.RodzajePrzepisow)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasForeignKey(x => x.PrzepisyId);

            builder.HasOne(x => x.Rodzaje)
                .WithMany(x => x.RodzajePrzepisow)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.RodzajeId);

            builder.ToTable("RodzajPrzepisu");
        }
    }
}
