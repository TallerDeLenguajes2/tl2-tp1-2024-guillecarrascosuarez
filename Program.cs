using Sistema;
using System;

string nombreArchivoCadetes = "Cadetes";
string nombreArchivoCadeteria = "Cadeteria";

AccesoADatos accesoADatos = null;
bool existeCSV = false;
bool existeJSON = false;

do
{
    Console.WriteLine("Seleccione el tipo de acceso que desea utilizar:");
    Console.WriteLine("1 - CSV");
    Console.WriteLine("2 - JSON");
    string opcionAcceso = Console.ReadLine();

    if (opcionAcceso == "1")
    {
        accesoADatos = new AccesoADatos(); // Instancia para CSV
        existeCSV = accesoADatos.ExisteCSV($"{nombreArchivoCadetes}.csv") && accesoADatos.ExisteCSV($"{nombreArchivoCadeteria}.csv");

        if (!existeCSV)
        {
            Console.WriteLine("No se encontró la información en formato CSV.");
        }
    }
    else if (opcionAcceso == "2")
    {
        accesoADatos = new AccesoADatos(); // Instancia para JSON
        existeJSON = accesoADatos.ExisteJSON($"{nombreArchivoCadetes}.json") && accesoADatos.ExisteJSON($"{nombreArchivoCadeteria}.json");

        if (!existeJSON)
        {
            Console.WriteLine("No se encontró la información en formato JSON.");
        }
    }
    else
    {
        Console.WriteLine("Opción no válida, por favor elija 1 o 2.");
    }

} while (accesoADatos == null || (!existeCSV && !existeJSON));

if (existeCSV || existeJSON)
{
    int operacion;
    int nroPedido = 0;

    List<Cadete> cadetes;
    Cadeteria cadeteria;

    if (existeCSV)
    {
        cadetes = accesoADatos.LeerCadetesCSV($"{nombreArchivoCadetes}.csv");
        cadeteria = accesoADatos.LeerCadeteriaCSV($"{nombreArchivoCadeteria}.csv");
    }
    else
    {
        cadetes = accesoADatos.LeerCadetesJSON($"{nombreArchivoCadetes}.json");
        cadeteria = accesoADatos.LeerCadeteriaJSON($"{nombreArchivoCadeteria}.json");
    }

    List<Pedido> pedidosSinAsignar = new List<Pedido>();
    do
    {
        Menu menu = new Menu($"Cadeteria {cadeteria.Nombre}-{cadeteria.Telefono}", ["Dar pedido de alta", "Asignar pedido", "Cambiar estado del pedido", "Reasignar pedido", "Cerrar"]);
        operacion = menu.MenuDisplay();
        switch (operacion)
        {
            case 0:
                nroPedido++;
                Pedido pedidoNuevo = Funciones.DarDeAltaPedido(nroPedido);
                pedidosSinAsignar.Add(pedidoNuevo);
                Console.WriteLine("Pedido dado de alta y agregado a la lista de pedidos sin asignar.");
                Console.ReadKey();
                break;

            case 1:
                if (pedidosSinAsignar.Count != 0)
                {
                    Console.WriteLine("El pedido a asignar es el siguiente:");
                    Funciones.MostrarPedido(pedidosSinAsignar[0]);

                    Console.WriteLine("Seleccione el ID del cadete al cual desea asignar el pedido:");
                    Funciones.MostrarCadetes(cadetes);
                    int idCadete = int.Parse(Console.ReadLine());

                    cadeteria.AsignarPedido(pedidosSinAsignar[0], idCadete);
                    pedidosSinAsignar.RemoveAt(0);
                }
                else
                {
                    Console.WriteLine("No hay pedidos para asignar.");
                }
                Console.ReadKey();
                break;

            case 2:
                string num;
                int numIngresado;
                do
                {
                    Console.WriteLine("Ingrese el número de pedido cuyo estado desea modificar:");
                    num = Console.ReadLine();
                } while (!int.TryParse(num, out numIngresado));

                Console.WriteLine("Seleccione el nuevo estado del pedido:");
                Funciones.MostrarEstados();
                Estados nuevoEstado = (Estados)Enum.Parse(typeof(Estados), Console.ReadLine());

                cadeteria.CambiarEstadoDelPedido(numIngresado, nuevoEstado);
                Console.ReadKey();
                break;

            case 3:
                Console.WriteLine("Pedidos disponibles para reasignar:");
                Funciones.MostrarPedidosSinEntregar(cadeteria);

                string ingreso;
                int numPedido;
                do
                {
                    Console.WriteLine("Ingrese el número del pedido que desea reasignar:");
                    ingreso = Console.ReadLine();
                } while (!int.TryParse(ingreso, out numPedido));

                Console.WriteLine("Seleccione el ID del nuevo cadete al cual desea reasignar el pedido:");
                Funciones.MostrarCadetes(cadetes);
                int idNuevoCadete = int.Parse(Console.ReadLine());

                cadeteria.ReasignarPedido(numPedido, idNuevoCadete);
                Console.ReadKey();
                break;

            case 4:
                Console.WriteLine("Final de Jornada - Informe:");
                List<string> informes = cadeteria.ObtenerJornalesYEnvios();
                
                foreach (var informe in informes)
                {
                    Console.WriteLine(informe);
                }
                Console.ReadKey();
                break;
        }

    } while (operacion != 4);
}
else
{
    Console.WriteLine("No se encontró la información de la cadetería en el formato seleccionado.");
}
