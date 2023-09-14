using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data.Configurations
{
    public class ColegioDBContext : DbContext
    {
        public ColegioDBContext(DbContextOptions<ColegioDBContext> options) : base(options)
        {
    
        }  

        public DbSet<Boletin> Boletines { get; set; }
        public DbSet<Colegio> Colegios { get; set; }
        public DbSet<Directivo> Directivos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<GrupoMateria> GruposMaterias { get; set; }
        public DbSet<GrupoProfesor> GruposProfesores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<ProfesorMateria> ProfesoresMaterias { get; set; }
        public DbSet<TipoDirectivo> TiposDirectivos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<UserRol> UsersRols { get; set; }
         public DbSet<RefreshToken> RefreshTokens { get; set; }

         
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<GrupoMateria>().HasKey(ps => new { ps.IdGrupoFK, ps.IdMateriaFK });

            modelBuilder.Entity<GrupoProfesor>().HasKey(ps => new { ps.IdGrupoFK, ps.IdProfesorFK });

            modelBuilder.Entity<ProfesorMateria>().HasKey(ps => new { ps.IdMateriaFK, ps.IdProfesorFK });
    
        }
    }
}