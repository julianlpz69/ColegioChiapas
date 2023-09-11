using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder){
    
            builder.ToTable("matricula");
    

            builder.HasOne(p => p.Estudiante)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(p => p.IdEstudianteFK);
    
        }
    }
    
}