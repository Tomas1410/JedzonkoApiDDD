using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class GrupyConfiguration : IEntityTypeConfiguration<Grupy>
    {
        public void Configure(EntityTypeBuilder<Grupy> builder)
        {
            builder.Property(x => x.TypGrupy).IsRequired().HasColumnType("varchar(15)");
            builder.ToTable("Grupa");

        }
    }
}
