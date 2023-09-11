using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class TipoDirectivoConfiguration : IEntityTypeConfiguration<TipoDirectivo>
    {
        public void Configure(EntityTypeBuilder<TipoDirectivo> builder){
    
            builder.ToTable("tipoDirectivo");
    
        }
    }
    
}