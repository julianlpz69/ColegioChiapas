using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class DirectivoConfiguration : IEntityTypeConfiguration<Directivo>
    {
        public void Configure(EntityTypeBuilder<Directivo> builder){
    
            builder.ToTable("directivo");
    
            builder.Property(e => e.Nombre)
                .HasMaxLength(50);

            builder.HasOne(p => p.Colegio)
                .WithMany(p => p.Directivos)
                .HasForeignKey(p => p.IdColegioFK);

            builder.HasOne(p => p.TipoDirectivo)
                .WithMany(p => p.Directivos)
                .HasForeignKey(p => p.IdTipoDirectivoFK);
    
        }
    }
    
}