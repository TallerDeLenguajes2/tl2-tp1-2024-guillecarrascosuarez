public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;

    public string Nombre { get; private set; }
    public string Telefono { get; set; }
    public List<Cadete> ListadoCadetes { get; set; }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        ListadoCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }

    public void EliminarCadete(Cadete cadete)
    {
        listadoCadetes.Remove(cadete);
    }

    public void GenerarInforme()
    {
        foreach (var cadete in listadoCadetes)
        {
            cadete.GenerarInforme();
        }
    }

    public List<Cadete> ObtenerListadoCadetes()
    {
        return listadoCadetes;
    }
}
