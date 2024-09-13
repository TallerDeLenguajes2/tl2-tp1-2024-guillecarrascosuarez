using System.Text.Json;
using System.Collections.Generic;
using System.IO;
namespace Sistema
{
public class AccesoADatos
{
    private readonly AccesoCSV accesoCSV;
    private readonly AccesoJSON accesoJSON;

    public AccesoADatos()
    {
        accesoCSV = new AccesoCSV();
        accesoJSON = new AccesoJSON();
    }

    public bool ExisteCSV(string nombreArchivo)
    {
        return accesoCSV.Existe(nombreArchivo);
    }

    public List<Cadete> LeerCadetesCSV(string nombreArchivo)
    {
        return accesoCSV.LeerCadetes(nombreArchivo);
    }

    public Cadeteria LeerCadeteriaCSV(string nombreArchivo)
    {
        return accesoCSV.LeerCadeteria(nombreArchivo);
    }

    public bool ExisteJSON(string nombreArchivo)
    {
        return accesoJSON.Existe(nombreArchivo);
    }

    public List<Cadete> LeerCadetesJSON(string nombreArchivo)
    {
        return accesoJSON.LeerCadetes(nombreArchivo);
    }

    public Cadeteria LeerCadeteriaJSON(string nombreArchivo)
    {
        return accesoJSON.LeerCadeteria(nombreArchivo);
    }

public class AccesoCSV
{
    public bool Existe(string nombreArchivo)
    {
        string ruta = "csv/" + nombreArchivo;
        return File.Exists(ruta);
    }

    public List<Cadete> LeerCadetes(string nombreArchivo)
{
    string ruta = "csv/" + nombreArchivo;
    List<Cadete> cadetes = new List<Cadete>();

    if (!File.Exists(ruta))
    {
        Console.WriteLine($"El archivo {nombreArchivo} no existe en la ruta {ruta}");
        return cadetes;
    }

    using (var archivoOpen = new FileStream(ruta, FileMode.Open))
    {
        using (var strReader = new StreamReader(archivoOpen))
        {
            string linea;

            strReader.ReadLine();
            while ((linea = strReader.ReadLine()) != null)
            {
                var datos = linea.Split(';');
                var cadete = new Cadete(int.Parse(datos[0]), datos[1], datos[2], datos[3]);
                cadetes.Add(cadete);
            }
        }
    }
    return cadetes;
}

public Cadeteria LeerCadeteria(string nombreArchivo)
{
    string ruta = "csv/" + nombreArchivo;
    List<Cadete> cadetes = new List<Cadete>(); 
    Cadeteria cadeteria = null;

    if (!File.Exists(ruta))
    {
        Console.WriteLine($"El archivo {nombreArchivo} no existe en la ruta {ruta}");
        return null;
    }

    using (var archivoOpen = new FileStream(ruta, FileMode.Open))
    {
        using (var strReader = new StreamReader(archivoOpen))
        {

            strReader.ReadLine();

            string linea = strReader.ReadLine();
            if (linea != null)
            {
                var datos = linea.Split(';');
                if (datos.Length >= 2)
                {
                    cadeteria = new Cadeteria(datos[0], datos[1], cadetes); 
                }
                else
                {
                    Console.WriteLine("El archivo CSV no contiene la cantidad adecuada de datos.");
                    return null;
                }
            }
            while ((linea = strReader.ReadLine()) != null)
            {
                var datosCadete = linea.Split(';');
                if (datosCadete.Length >= 4)
                {
                    var cadete = new Cadete(int.Parse(datosCadete[0]), datosCadete[1], datosCadete[2], datosCadete[3]);
                    cadetes.Add(cadete);
                }
            }
        }
    }

    return cadeteria;
}


}

public class AccesoJSON
{
    public bool Existe(string nombreArchivo)
    {
        string ruta = "json/" + nombreArchivo;
        return File.Exists(ruta);
    }

    public List<Cadete> LeerCadetes(string nombreArchivo)
    {
        string ruta = "json/" + nombreArchivo;

        if (!File.Exists(ruta))
        {
            Console.WriteLine($"El archivo {nombreArchivo} no existe en la ruta {ruta}");
            return new List<Cadete>();
        }

        string cadetesJson;
        using (var archivoOpen = new FileStream(ruta, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                cadetesJson = strReader.ReadToEnd();
            }
        }


        var cadetes = JsonSerializer.Deserialize<List<Cadete>>(cadetesJson);
        return cadetes ?? new List<Cadete>();
    }

    public Cadeteria LeerCadeteria(string nombreArchivo)
    {
        string ruta = "json/" + nombreArchivo;

        if (!File.Exists(ruta))
        {
            Console.WriteLine($"El archivo {nombreArchivo} no existe en la ruta {ruta}");
            return null;
        }

        string cadeteriaJson;
        using (var archivoOpen = new FileStream(ruta, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                cadeteriaJson = strReader.ReadToEnd();
            }
        }

        var cadeteria = JsonSerializer.Deserialize<Cadeteria>(cadeteriaJson);
        return cadeteria;
    }
}
}}