using Microsoft.EntityFrameworkCore;
using ProjetoNoticia.Entidades;
using System.Configuration;

namespace ProjetoNoticia.DAO
{
    public class ProjetoNoticiaContext : DbContext
    {
        
        public ProjetoNoticiaContext(DbContextOptions<ProjetoNoticiaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("db");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario").HasKey(x => x.Id);
            modelBuilder.Entity<Noticia>().ToTable("Noticia").HasKey(x => x.Id);
            modelBuilder.Entity<NoticiaTag>().ToTable("NoticiaTag").HasKey(x => x.Id);
            modelBuilder.Entity<Tag>().ToTable("Tag").HasKey(x => x.Id);
        }

        #region Entites
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<NoticiaTag> NoticiaTag { get; set; }
        public DbSet<Tag> Tag { get; set; }

        #endregion


    }
}
