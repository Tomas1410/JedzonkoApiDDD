using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;
using System;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class ZdjeciaConfiguration : IEntityTypeConfiguration<Zdjecia>
    {
        public void Configure(EntityTypeBuilder<Zdjecia> builder)
        {
            builder.Property(x => x.Imglink).IsRequired();

            builder.HasOne(x => x.Przepisy)
                 .WithMany(x => x.Zdjecia)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasForeignKey(x => x.PrzepisyId);

            builder.ToTable("Zdjecie");

        }
    }
}
