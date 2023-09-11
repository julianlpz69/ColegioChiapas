using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations
{
    
    public class NotaConfiguration : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder){
    
            builder.ToTable("nota");
    

            builder.HasOne(p => p.Profesor)
                .WithMany(p => p.Notas)
                .HasForeignKey(p => p.IdProfesorFK);


            builder.HasOne(p => p.Estudiante)
                .WithMany(p => p.Notas)
                .HasForeignKey(p => p.IdEstudianteFK);


            builder.HasOne(p => p.Materia)
                .WithMany(p => p.Notas)
                .HasForeignKey(p => p.IdMateriaFK);


            builder.HasOne(p => p.Boletin)
                .WithMany(p => p.Notas)
                .HasForeignKey(p => p.IdBoletinFK);
            
    
        }
    }
    
}