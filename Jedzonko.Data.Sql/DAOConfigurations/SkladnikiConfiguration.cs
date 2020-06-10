using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jedzonko.Data.SQL.DAO;
using System;

namespace Jedzonko.Data.SQL.DAOConfiguration
{
    class SkladnikiConfiguration : IEntityTypeConfiguration<Skladniki>
    {
        public void Configure(EntityTypeBuilder<Skladniki> builder)
        {

            builder.Property(x => x.Nazwa).IsRequired();
            builder.ToTable("Skladnik");



        }
    }
}
