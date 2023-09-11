namespace Dominio.Entities
{
    public class TipoDirectivo : BaseEntity
    {
        public string NombreCargo {get; set;}
        public int HorasTrabajo {get; set;}
        public ICollection<Directivo> Directivos {get; set;}
    }
}