public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos;
    private double jornalACobrar;

    public int Id { get; private set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public List<Pedido> ListadoPedidos { get; set; }
    public double JornalACobrar { get; set; }

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListadoPedidos = new List<Pedido>();
        JornalACobrar = 0;
    }

    public void AsignarPedido(Pedido pedido)
    {
        ListadoPedidos.Add(pedido);
    }

    public void ReasignarPedido(Cadete nuevoCadete, Pedido pedido)
    {
        ListadoPedidos.Remove(pedido);
        nuevoCadete.AsignarPedido(pedido);
    }

    public void GenerarInforme()
    {
        int pedidosEntregados = ListadoPedidos.Count(p => p.Estado == "Entregado");
        JornalACobrar = pedidosEntregados * 500;
        Console.WriteLine($"Cadete: {nombre}, Jornal a cobrar: ${JornalACobrar}, Pedidos entregados: {pedidosEntregados}");
    }

    public List<Pedido> ObtenerListadoPedidos()
    {
        return ListadoPedidos;
    }
}
