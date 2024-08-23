public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferenciaDireccion;

    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string DatosReferenciaDireccion { get; set; }

    public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        DatosReferenciaDireccion = datosReferenciaDireccion;
    }

    public void VerTelefonoCliente()
    {
        Console.WriteLine($"Teléfono del cliente: {telefono}");
    }

    public void VerDatosReferenciaDireccion()
    {
        Console.WriteLine($"Referencia de la dirección: {DatosReferenciaDireccion}");
    }
}
