using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class GrupoMateriaConfiguration : IEntityTypeConfiguration<GrupoMateria>
    {
        public void Configure(EntityTypeBuilder<GrupoMateria> builder){
    
            builder.ToTable("grupoMateria");
    
           

             builder.HasOne(p => p.Grupo)
                .WithMany(p => p.GruposMaterias)
                .HasForeignKey(p => p.IdGrupoFK);
            
            builder.HasOne(p => p.Materia)
                .WithMany(p => p.GruposMaterias)
                .HasForeignKey(p => p.IdMateriaFK);

            
    
        }
    }
    
}