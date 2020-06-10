using Jedzonko.Data.Sql.DAOConfigurations;
using Jedzonko.Data.SQL.DAO;
using Jedzonko.Data.SQL.DAOConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.Data.Sql
{
    public class JedzonkoDbContext : DbContext
    {
        public JedzonkoDbContext(DbContextOptions<JedzonkoDbContext> options) : base(options) { }

        public virtual DbSet<Grupy> Grupy { get; set; }
        public virtual DbSet<Komentarze> Komentarze { get; set; }
        public virtual DbSet<Oceny> Oceny { get; set; }
        public virtual DbSet<Przepisy> Przepisy { get; set; }
        public virtual DbSet<Rodzaje> Rodzaje { get; set; }
        public virtual DbSet<RodzajePrzepisow> RodzajePrzepisow { get; set; }
        public virtual DbSet<Skladniki> Skladniki { get; set; }
        public virtual DbSet<SkladnikiPrzepisow> SkladnikiPrzepisow { get; set; }
        public virtual DbSet<Stan> Stan { get; set; }
        public virtual DbSet<Uzytkownicy> Uzytkownicy { get; set; }
        public virtual DbSet<Zdjecia> Zdjecia { get; set; }


       protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GrupyConfiguration());
            builder.ApplyConfiguration(new KomentarzeConfiguration());
            builder.ApplyConfiguration(new OcenyConfiguration());
            builder.ApplyConfiguration(new PrzepisyConfiguration());
            builder.ApplyConfiguration(new RodzajeConfiguration());
            builder.ApplyConfiguration(new RodzajePrzepisowConfiguration());
            builder.ApplyConfiguration(new SkladnikiConfiguration());
            builder.ApplyConfiguration(new SkladnikiPrzepisowConfiguration());
            builder.ApplyConfiguration(new StanConfiguration());
            builder.ApplyConfiguration(new UzytkownicyConfiguration());
            builder.ApplyConfiguration(new ZdjeciaConfiguration());
            
        }


    }
}
