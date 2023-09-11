using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder){
    
            builder.ToTable("profesor");
    

            builder.HasOne(p => p.Colegio)
                .WithMany(p => p.Profesores)
                .HasForeignKey(p => p.IdColegioFK);

    
        }
    }
    
}