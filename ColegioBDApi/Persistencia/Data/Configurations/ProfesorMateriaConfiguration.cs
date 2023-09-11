using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class ProfesorMateriaConfiguration : IEntityTypeConfiguration<ProfesorMateria>
    {
        public void Configure(EntityTypeBuilder<ProfesorMateria> builder){
    
            builder.ToTable("profesorMateria");
    

             builder.HasOne(p => p.Profesor)
                .WithMany(p => p.ProfesoresMaterias)
                .HasForeignKey(p => p.IdProfesorFK);
            
            builder.HasOne(p => p.Materia)
                .WithMany(p => p.ProfesoresMaterias)
                .HasForeignKey(p => p.IdMateriaFK);

    
        }
    }
    
}