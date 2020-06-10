using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;
using System;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class OcenyConfiguration : IEntityTypeConfiguration<Oceny>
    {
        public void Configure(EntityTypeBuilder<Oceny> builder)
        {

           
            builder.Property(x => x.TypOcen).IsRequired().HasColumnType("varchar(15)");

            builder.HasOne(x => x.Uzytkownicy)
                .WithMany(x => x.Oceny)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UzytkownicyId);

            builder.HasOne(x => x.Przepisy)
                .WithMany(x => x.Oceny)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PrzepisyId);

            builder.ToTable("Ocena");
        }
    }
}
