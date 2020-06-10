using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;
using System;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class UzytkownicyConfiguration : IEntityTypeConfiguration<Uzytkownicy>
    {
        public void Configure(EntityTypeBuilder<Uzytkownicy> builder)
        {
            builder.Property(x => x.NazwaUzytkownika).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(c => c.Zablokowany).HasColumnType("tinyint(1)");
            builder.Property(x => x.GrupyId).HasDefaultValue(3); 
            builder.Property(x => x.Zablokowany).HasDefaultValue(0);

            builder.HasOne(x => x.Grupy)
                .WithMany(x => x.Uzytkownicy)
                .HasForeignKey(x => x.GrupyId);
            

            builder.ToTable("Uzytkownicy");
        }
    }
}
