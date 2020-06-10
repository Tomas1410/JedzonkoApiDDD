using Jedzonko.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.Data.Sql.DAOConfigurations
{
    class PrzepisyConfiguration : IEntityTypeConfiguration<Przepisy>
    {
        public void Configure(EntityTypeBuilder<Przepisy> builder)
        {

           
            builder.Property(x => x.Tytul).IsRequired();
            builder.Property(x => x.SposobWykonania).IsRequired();


            builder.HasOne(x => x.Uzytkownicy)
                 .WithMany(x => x.Przepisy)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasForeignKey(x => x.UzytkownicyId);

            builder.HasOne(x => x.Stan)
                .WithMany(x => x.Przepisy)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.StanId);

            builder.ToTable("Przepis");

        }
    }
}
