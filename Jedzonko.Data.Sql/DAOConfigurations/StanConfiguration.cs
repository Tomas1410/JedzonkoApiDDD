using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;
using System;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class StanConfiguration : IEntityTypeConfiguration<Stan>
    {
        public void Configure(EntityTypeBuilder<Stan> builder)
        {
            builder.Property(x => x.NazwaStanu).IsRequired().HasColumnType("varchar(15)");
      
            builder.ToTable("Stan");

        }
    }
}
