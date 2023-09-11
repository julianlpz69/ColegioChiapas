using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class ColegioConfiguration : IEntityTypeConfiguration<Colegio>
    {
        public void Configure(EntityTypeBuilder<Colegio> builder){
    
            builder.ToTable("colegio");
    
            builder.Property(e => e.NombreColegio)
                .HasMaxLength(30);
    
        }
    }
    
}