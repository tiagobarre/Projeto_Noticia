using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetoNoticia.Domain.Entidades;
using System.IO;

namespace ProjetoNoticia.Infra.DAO
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
                var connectionString = "Server=localhost;Database=Projeto_Noticia;Trusted_Connection=true;TrustServerCertificate=True;";
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
