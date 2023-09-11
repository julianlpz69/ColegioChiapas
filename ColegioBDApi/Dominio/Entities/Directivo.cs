namespace Dominio.Entities
{
    public class Directivo : PersonaClass
    {
        public string NivelAcceso = "Directivo";
        public int IdColegioFK {get; set;}
        public Colegio Colegio {get; set;}
        public int IdTipoDirectivoFK {get; set;}
        public TipoDirectivo TipoDirectivo {get; set;}
    }
}