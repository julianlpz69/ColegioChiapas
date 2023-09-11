using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder){
    
            builder.ToTable("estudiante");
    
            builder.Property(e => e.Nombre)
                .HasMaxLength(50);

            builder.HasOne(p => p.Grupo)
                .WithMany(p => p.Estudiantes)
                .HasForeignKey(p => p.IdGrupoFK);

            builder.HasOne(p => p.Colegio)
                .WithMany(p => p.Estudiantes)
                .HasForeignKey(p => p.IdColegioFK);

            
    
        }
    }
    
}