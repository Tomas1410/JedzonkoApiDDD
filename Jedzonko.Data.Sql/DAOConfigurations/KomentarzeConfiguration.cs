using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class KomentarzeConfiguration : IEntityTypeConfiguration<Komentarze>
    {
        public void Configure(EntityTypeBuilder<Komentarze> builder)
        {
            builder.Property(c => c.Usuniety).HasColumnType("tinyint(1)").IsRequired();
            builder.Property(c => c.Ukryty).HasColumnType("tinyint(1)").IsRequired();
            builder.Property(c => c.Tresc).IsRequired();


            builder.HasOne(x => x.Przepisy)
                .WithMany(x => x.Komentarze)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PrzepisyId);

            builder.HasOne(x => x.Uzytkownicy)
                .WithMany(x => x.Komentarze)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UzytkownicyId);

            builder.ToTable("Komentarz");
        }
    }
}
