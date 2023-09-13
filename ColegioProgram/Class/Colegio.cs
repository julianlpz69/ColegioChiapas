using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ColegioProgram.Class
{
    public class Colegio
    {
        
        public async void AgregarColegio(){
            using(var client = new HttpClient())
            {

                try
            {
               string urls = "http://localhost:5145/api/colegio";
                // Datos que deseas enviar en el cuerpo de la solicitud (en formato JSON, por ejemplo)
                string jsonContent = "{\"nombreColegio\": \"Rafael Pombo\", \"dirreccionColegio\": \"calle 12 #23-11\"}";

                // Crear un objeto HttpContent para el cuerpo de la solicitud
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realizar la solicitud POST
                HttpResponseMessage response = await client.PostAsync(urls, content);

                // Comprobar si la solicitud fue exitosa (código de estado 2xx)
                if (response.IsSuccessStatusCode)
                {
                    
                    Console.WriteLine("El colegio Fue agregado Exitosamente");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("La solicitud POST no fue exitosa. Código de estado: " + (int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al realizar la solicitud POST: " + ex.Message);
            }

            }
        }




        public void MostrarColegios(){
            Console.Clear();

            using(var client = new HttpClient())
            {
                string url = "http://localhost:5145/api/colegio";

                client.DefaultRequestHeaders.Clear();

                var respuesta = client.GetAsync(url).Result;

                var res = respuesta.Content.ReadAsStringAsync().Result;

                dynamic c = JsonConvert.DeserializeObject(res);
        
                Console.WriteLine($"------------------------Colegios-----------------------------");
                Console.WriteLine($"\nID\tNombre\t\t\tDirrecion");
                foreach (var elemens in c){
                    Console.WriteLine($"\n{elemens.id}\t{elemens.nombreColegio}\t{elemens.dirreccionColegio}");
                }
                Console.ReadKey();
                
            }

            
            
        }
    }
}