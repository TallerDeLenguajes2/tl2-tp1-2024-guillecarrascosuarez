using Sistema;
string nombreArchivoCadetes = "Cadetes.csv";
string nombreArchivoCadeteria = "Cadeteria.csv";
HelperDeCSV helperCSV = new HelperDeCSV();
if(helperCSV.Existe(nombreArchivoCadetes) && helperCSV.Existe(nombreArchivoCadeteria))
{
    int operacion;
    int nroPedido = 0;
    List<Cadete> cadetes = helperCSV.LeerCadetes(nombreArchivoCadetes);
    List<Pedido> pedidosSinAsignar = new List<Pedido>(); 
    string[] infoCadeteria = helperCSV.LeerCadeteria(nombreArchivoCadeteria).Split(";");
    Cadeteria cadeteria = new Cadeteria(infoCadeteria[0], infoCadeteria[1], cadetes);
    do
    {         
        Menu menu = new Menu($"Cadeteria {cadeteria.Nombre}-{cadeteria.Telefono}", ["Dar pedido de alta", "Asignar pedido", "Cambiar estado del pedido", "Reasignar pedido", "Cerrar"]);
        operacion = menu.MenuDisplay();
        switch (operacion)
        {
            
case 0:
                nroPedido++;
                Pedido pedidoNuevo = Funciones.DarDeAltaPedido(nroPedido);
                pedidosSinAsignar.Add(pedidoNuevo); // Agregar a la lista de pedidos sin asignar
                Console.WriteLine("Pedido dado de alta y agregado a la lista de pedidos sin asignar.");
                Console.ReadKey();
                break;

            case 1:
                if (pedidosSinAsignar.Count != 0)
                {
                    Console.WriteLine("El pedido a asignar es el siguiente:");
                    Funciones.MostrarPedido(pedidosSinAsignar[0]);

                    // Seleccionar cadete para asignar el pedido
                    Console.WriteLine("Seleccione el ID del cadete al cual desea asignar el pedido:");
                    Funciones.MostrarCadetes(cadetes); // Muestra los cadetes disponibles
                    int idCadete = int.Parse(Console.ReadLine());

                    cadeteria.AsignarPedido(pedidosSinAsignar[0], idCadete); // Asignar pedido a un cadete
                    pedidosSinAsignar.RemoveAt(0); // Remover el pedido de la lista de no asignados
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

                // Seleccionar nuevo estado del pedido
                Console.WriteLine("Seleccione el nuevo estado del pedido:");
                Funciones.MostrarEstados(); // Muestra los estados disponibles
                Estados nuevoEstado = (Estados)Enum.Parse(typeof(Estados), Console.ReadLine());

                cadeteria.CambiarEstadoDelPedido(numIngresado, nuevoEstado); // Cambiar estado del pedido
                Console.ReadKey();
                break;

            case 3:
                Console.WriteLine("Pedidos disponibles para reasignar:");
                Funciones.MostrarPedidosSinEntregar(cadeteria); // Mostrar pedidos en estado "En camino"

                string ingreso;
                int numPedido;
                do
                {
                    Console.WriteLine("Ingrese el número del pedido que desea reasignar:");
                    ingreso = Console.ReadLine();
                } while (!int.TryParse(ingreso, out numPedido));

                // Seleccionar nuevo cadete para reasignar el pedido
                Console.WriteLine("Seleccione el ID del nuevo cadete al cual desea reasignar el pedido:");
                Funciones.MostrarCadetes(cadetes); // Muestra los cadetes disponibles
                int idNuevoCadete = int.Parse(Console.ReadLine());

                cadeteria.ReasignarPedido(numPedido, idNuevoCadete); // Reasignar el pedido a otro cadete
                Console.ReadKey();
                break;

            case 4:
                Console.WriteLine("Final de Jornada - Informe:");
                cadeteria.MostrarJornalesYEnvios(); // Mostrar el informe de la jornada
                Console.ReadKey();
                break;
        }

    } while (operacion != 4);
}else
{
    Console.WriteLine("No se encontró la información de la cadetería");
}

