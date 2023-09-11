using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class BoletinConfiguration : IEntityTypeConfiguration<Boletin>
    {
        public void Configure(EntityTypeBuilder<Boletin> builder){
    
            builder.ToTable("boletin");
    
            builder.Property(e => e.Corte)
                .HasMaxLength(30);

            builder.HasOne(p => p.Estudiante)
                .WithMany(p => p.Boletines)
                .HasForeignKey(p => p.IdEstudianteFK);
    
        }
    }
    
}