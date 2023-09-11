using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder){
    
            builder.ToTable("grupo");
    
            builder.Property(e => e.NombreGrupo)
                .HasMaxLength(50);

    


        }
    }
    
}