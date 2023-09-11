
using ColegioProgram.Class;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu inicio = new Menu();
        int opcion;

        do {
            inicio.menuPrincipal();
            opcion = inicio.PedirOpcion();

            Colegio colegio = new Colegio();

            switch(opcion)
            {
                case 1 :
                    inicio.MenuAgregarPlantel();
                    int opcionAgregar= inicio.PedirOpcion();

                    switch(opcionAgregar)
                    {
                        case 1 :
                        colegio.AgregarColegio();
                            break;
                    }
                    break;


                case 2 :
                    inicio.MenuMostrarPlantel();
                    int opcionMostrar= inicio.PedirOpcion();
                    switch(opcionMostrar)
                    {
                        case 1 :
                            colegio.MostrarColegios();
                            break;
                    }
                    break;
            }
                    
            
        }while (opcion != 5);
    }
}