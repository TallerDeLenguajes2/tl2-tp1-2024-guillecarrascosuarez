namespace Sistema
{    
    public class Funciones
    {
        public static void MostrarCadetes(List<Cadete> cadetes)
        {
            if (cadetes.Count == 0)
            {
                Console.WriteLine("No hay cadetes disponibles.");
            }
            else
            {
                foreach (var cadete in cadetes)
                {
                    Console.WriteLine($"ID: {cadete.Id}, Nombre: {cadete.Nombre}");
                }
            }
        }
        public static void MostrarEstados()
        {
            Console.WriteLine("Estados disponibles:");
            foreach (var estado in Enum.GetValues(typeof(Estados)))
            {
                Console.WriteLine($"{(int)estado} - {estado}");
            }
        }

        public static Pedido DarDeAltaPedido(int nroPedido)
        {
            string observacionPedido;
            string nombreCliente;
            string direccCliente;
            string telefonoCliente;
            string referenciasCliente;

            do
            {
                Console.WriteLine("Ingrese información del pedido: ");
                observacionPedido = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del cliente:");
                nombreCliente = Console.ReadLine();
                Console.WriteLine("Ingrese la dirección del cliente:");
                direccCliente = Console.ReadLine();
                Console.WriteLine("Ingrese el teléfono del cliente:");
                telefonoCliente = Console.ReadLine();
                Console.WriteLine("Ingrese una referencia de la dirección (Opcional):");
                referenciasCliente = Console.ReadLine();

                if (observacionPedido.Length == 0 || nombreCliente.Length == 0 || direccCliente.Length == 0 || telefonoCliente.Length == 0)
                {
                    Console.WriteLine("Debe rellenar correctamente los campos obligatorios.");
                }
            } while (string.IsNullOrWhiteSpace(observacionPedido) || string.IsNullOrWhiteSpace(nombreCliente) || string.IsNullOrWhiteSpace(direccCliente) || string.IsNullOrWhiteSpace(telefonoCliente));

            // Crear objeto Cliente
            Cliente clienteNuevo = new Cliente(nombreCliente, direccCliente, telefonoCliente, referenciasCliente);

            // Crear objeto Pedido
            Pedido pedidoNuevo = new Pedido(nroPedido, observacionPedido, clienteNuevo);
            
            return pedidoNuevo;
        }


        public static void MostrarPedido(Pedido pedido)
        {
            if (pedido != null)
            {  
                Console.WriteLine($"Pedido Nro: {pedido.Numero}");
                Console.WriteLine($"Observaciones: {pedido.Observacion}");
                Console.WriteLine($"Estado: {pedido.Estado}");
                pedido.VerDatosCliente();
            }else
            {
                Console.WriteLine("El pedido no existe");
            }
        }

    public static void MostrarPedidosSinEntregar(Cadeteria cadeteria)
    {
        var pedidosSinEntregar = cadeteria.ListadoPedidos.Where(p => p.Estado != Estados.Entregado).ToList();

        if (pedidosSinEntregar.Any())
        {
            foreach (var pedido in pedidosSinEntregar)
            {
                Console.WriteLine($"Pedido Nro: {pedido.Numero}");
                Console.WriteLine($"Cadete asignado: {pedido.CadeteAsignado.Nombre}");
                Funciones.MostrarPedido(pedido);
            }
        }
        else
        {
            Console.WriteLine("No hay pedidos sin entregar.");
        }
    }


        
    }
}