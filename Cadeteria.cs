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
        if (cadete != null)
        {
            pedido.CadeteAsignado = cadete;  
            listadoPedidos.Add(pedido);
        }
    }

    public void CambiarEstadoDelPedido(int numPedido, Estados nuevoEstado)
    {
        var pedido = listadoPedidos.FirstOrDefault(p => p.Numero == numPedido);
        if (pedido != null)
        {
            pedido.Estado = nuevoEstado;
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
        public void MostrarJornalesYEnvios()
    {
        int totalEnvios = 0;
        foreach (var cadete in cadetes)
        {
            int pedidosCompletados = listadoPedidos.Count(p => p.CadeteAsignado?.Id == cadete.Id && p.Estado == Estados.Entregado);
            float pago = pedidosCompletados * 500;
            Console.WriteLine($"{cadete.Nombre} - ${pago}");
            totalEnvios += pedidosCompletados;
        }
        float promedioEnviosPorCadete = cadetes.Count > 0 ? (float)totalEnvios / cadetes.Count : 0;
        Console.WriteLine($"Total de envíos: {totalEnvios}");
        Console.WriteLine($"Promedio de envíos completado por cadete: {promedioEnviosPorCadete}");
    }
        public Pedido DarDeBajaPedido(int numero)
    {
       var pedidoAQuitar = ListadoPedidos.Where(p => p.Numero == numero).ToList();
       ListadoPedidos.Remove(pedidoAQuitar[0]);
       return pedidoAQuitar[0];
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
