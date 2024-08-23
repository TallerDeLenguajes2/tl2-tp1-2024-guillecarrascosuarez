public class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private string estado;

    public int Nro { get; private set; }
    public string Obs { get; set; }
    public string Estado { get; set; }
    public Cliente Cliente { get; private set; }

    public Pedido(int nro, string obs, Cliente cliente)
    {
        Nro = nro;
        Obs = obs;
        Cliente = cliente;
        Estado = "Pendiente";
    }

    public void VerDireccionCliente()
    {
        Console.WriteLine($"Dirección del cliente: {cliente.Direccion}");
    }

    public void VerDatosCliente()
    {
        Console.WriteLine($"Nombre: {cliente.Nombre}, Teléfono: {cliente.Telefono}, Dirección: {cliente.Direccion}");
    }
}
