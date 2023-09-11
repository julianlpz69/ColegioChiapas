using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class GrupoProfesorConfiguration : IEntityTypeConfiguration<GrupoProfesor>
    {
        public void Configure(EntityTypeBuilder<GrupoProfesor> builder){
    
            builder.ToTable("grupoProfesor");
    
           

             builder.HasOne(p => p.Grupo)
                .WithMany(p => p.GruposProfesores)
                .HasForeignKey(p => p.IdGrupoFK);
            
            builder.HasOne(p => p.Profesor)
                .WithMany(p => p.GruposProfesores)
                .HasForeignKey(p => p.IdProfesorFK);

            
    
        }
    }
    
}