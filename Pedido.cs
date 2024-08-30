using System.ComponentModel;

public class Pedido
{
    private int numero;
    private string observacion;
    private Cliente cliente;

    private Estados estado;
    public int Numero { get => numero;}
    public Cadete CadeteAsignado { get; set; }
    public string Observacion { get => observacion;}
    public Estados Estado { get => estado; set => estado = value; }

    public Pedido(int nro, string obs, Cliente cliente)
    {
        numero = nro;
        observacion = obs;
        Estado = Estados.Preparación;
        this.cliente = cliente;
    }


    public void VerDireccionCliente()
    {
        Console.WriteLine($"Dirección de entrega: {cliente.Direccion}");
        if(cliente.DatosReferenciasDireccion != null)
        {
            Console.WriteLine($"Referencias: {cliente.DatosReferenciasDireccion}");
        }

    }
    public void VerDatosCliente()
    {
        Console.WriteLine($"Cliente: {cliente.Nombre}");
        Console.WriteLine($"Direccion: {cliente.Direccion}");
        Console.WriteLine($"Telefono: {cliente.Telefono}");
    }
}

