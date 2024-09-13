using System.Runtime.Intrinsics.X86;

public class Cadeteria
{
    private string nombre;

    private string telefono;
    private List<Cadete> cadetes;
    private List<Pedido> listadoPedidos;

    public string Nombre { get => nombre;}

    public string Telefono {get => telefono;}
    public List<Cadete> Cadetes { get => cadetes;}
     public List<Pedido> ListadoPedidos { get => listadoPedidos; } 

    public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.cadetes = cadetes;
        this.listadoPedidos = new List<Pedido>();
    }

    public void AsignarPedido(Pedido pedido, int idCadete)
    {
        var cadete = cadetes.FirstOrDefault(c => c.Id == idCadete);
        
        if (cadete == null)
        {
            Console.WriteLine("No se encontró un cadete con ese ID.");
        }
        else if (pedido.CadeteAsignado == null)
        {
        
            pedido.CadeteAsignado = cadete;  
            listadoPedidos.Add(pedido);
            Console.WriteLine($"Pedido asignado correctamente al cadete {cadete.Nombre}.");
        }
        else
        {
            Console.WriteLine("El pedido ya está asignado o el cadete no existe.");
        }
    }



    public void CambiarEstadoDelPedido(int numPedido, Estados nuevoEstado)
    {
        var pedido = listadoPedidos.FirstOrDefault(p => p.Numero == numPedido);
        if (pedido != null)
        {
            pedido.Estado = nuevoEstado;
            Console.WriteLine($"Pedido {numPedido} ha sido actualizado a {pedido.Estado}");
        }
        else
        {
            Console.WriteLine($"Pedido {numPedido} no encontrado.");
        }
    }

    public void ReasignarPedido(int numPedido, int idNuevoCadete)
    {
        var pedido = listadoPedidos.FirstOrDefault(p => p.Numero == numPedido);
        if (pedido != null)
        {
            var nuevoCadete = cadetes.FirstOrDefault(c => c.Id == idNuevoCadete);
            if (nuevoCadete != null)
            {
                pedido.CadeteAsignado = nuevoCadete;
            }
        }
    }
    public List<string> ObtenerJornalesYEnvios()
    {
        List<string> informes = new List<string>();
        int totalEnvios = 0;
        foreach (var cadete in cadetes)
        {
            int pedidosCompletados = listadoPedidos.Count(p => p.CadeteAsignado?.Id == cadete.Id && p.Estado == Estados.Entregado);
            float pago = pedidosCompletados * 500;
            informes.Add($"{cadete.Nombre} - ${pago}");
            totalEnvios += pedidosCompletados;
        }
        float promedioEnviosPorCadete = cadetes.Count > 0 ? (float)totalEnvios / cadetes.Count : 0;
        informes.Add($"Total de envíos: {totalEnvios}");
        informes.Add($"Promedio de envíos completados por cadete: {promedioEnviosPorCadete}");
        return informes;
    }
        public Pedido DarDeBajaPedido(int numero)
    {
        var pedidoAQuitar = ListadoPedidos.FirstOrDefault(p => p.Numero == numero);
        if (pedidoAQuitar != null) {
            ListadoPedidos.Remove(pedidoAQuitar);
            return pedidoAQuitar;
        }
        return null;
    }
    public void RetirarPedido(int numero)
    {
        var pedidoAQuitar = ListadoPedidos.Where(p => p.Numero == numero).ToList();
        pedidoAQuitar[0].Estado = Estados.EnCamino;
    }
    public void CompletarPedido(int numero)
    {
        var pedidoAQuitar = ListadoPedidos.Where(p => p.Numero == numero).ToList();
        pedidoAQuitar[0].Estado = Estados.Entregado; 
    }
}
