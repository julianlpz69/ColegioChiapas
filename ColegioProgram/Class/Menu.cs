using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColegioProgram.Class
{
    public class Menu
    {
        public Menu(){

        }

        public void menuPrincipal(){
            Console.Clear();
            Console.WriteLine("\n ---------------------- Menu Principal -----------------");
            Console.WriteLine("\n1. Regitro De Plantel");
            Console.WriteLine("2. Mostrar Plantel");
            Console.WriteLine("5. Salir");
        }

        public void MenuAgregarPlantel(){
            Console.Clear();
            Console.WriteLine("\n ---------------------- Registro Del Plantel -----------------");
            Console.WriteLine("\n1. Registrar Colegio");
            Console.WriteLine("2. Registrar Directivo");
            Console.WriteLine("3. Registrar Profesor");
            Console.WriteLine("4. Registrar Estudiante");
            Console.WriteLine("5. Regresar al Menu Principal");
        }

        public void MenuMostrarPlantel(){
            Console.Clear();
            Console.WriteLine("\n ---------------------- Mostrar Plantel -----------------");
            Console.WriteLine("\n1. Mostrar Colegios");
            Console.WriteLine("2. Mostrar Directivos");
            Console.WriteLine("3. Mostrar Profesores");
            Console.WriteLine("4. Mostrar Estudiantes");
            Console.WriteLine("5. Regresar al Menu Principal");
        }

        

        public int PedirOpcion() {
            Console.Write("\nElige una opción:\t");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}