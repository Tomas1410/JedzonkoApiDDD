using Jedzonko.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.Data.Sql.DAOConfigurations
{
    class RodzajeConfiguration : IEntityTypeConfiguration<Rodzaje>
    {
        public void Configure(EntityTypeBuilder<Rodzaje> builder)
        {
            
            builder.Property(r => r.Typ).IsRequired();
            builder.ToTable("Rodzaj");
        }
    }
}
