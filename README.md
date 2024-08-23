
# Trabajo práctico N°1: Sistema para una Cadetería

Este proyecto forma parte de la materia Taller de Lenguajes 2 de la carrera Ingeniería en Informática, realizado por la alumna Carrasco Suárez Guillermina. El objetivo es implementar un sistema para gestionar pedidos y asignarlos a cadetes en una empresa de cadetería.

## 1. Relaciones de Composición y Agregación

La relación entre Pedido y Cliente es de composición. La vida del Cliente depende del Pedido, por lo tanto, si se elimina un Pedido, el Cliente también debe eliminarse. La relación entre Cadetería y Cadete es de composición también, siguiendo la misma lógica. Mientras que la relación entre Cadete y Pedido es de agregación. Los Cadetes pueden existir independientemente de los pedidos asignados, y si la los cadetes se eliminan, los pedidos podrían seguir existiendo.

## 2. Métodos sugeridos para las clases

### Clase Cadetería
Se sugiere que la clase cadetería debería tener los métodos  GenerarInforme, que genere un informe que muestre todos los cadetes por cadeteria,  AgregarCadete, para agregar un nuevo cadete a una cadetería, y por último EliminarCadete, que permita eliminar a un cadete determinado de una cadeteria.

### Clase Cadete
Se sugiere que la clase cadete debería tener los métodos AsignarPedido, que permita asignar un pedido a un determinado cadete, ReasignarPedido, para que un pedido ya asignado pase a otro cadete, GenerarInforme, que genere un informe que muestre todos los cadetes, y los pedidos asignados a los mismos,  JornalACobrar, que permita calcula el jornal que debe cobrar el cadete, pedidosEntregados que incluya la lógica para marcar como entregado un pedido.


## 3. Encapsulación: Atributos, Propiedades y Métodos

Siguiendo los principios de abstracción y ocultamiento, los atributos de cada clase deben ser privados, mientras que se deben exponer las propiedades necesarias para el acceso controlado a dichos atributos. Los métodos que realizan las acciones del sistema serán públicos. 

### Clase Pedido
- Atributos privados: nro, obs, cliente, estado.
- Propiedades públicas:
  public int Nro { get; private set; }
  public string Obs { get; set; }
  
- Métodos públicos: VerDireccionCliente() y VerDatosCliente()

### Clase Cadetería
- Atributos privados: nombre, telefono, listadoCadetes.
- Propiedades públicas:
  public string Nombre { get; private set; }
  public string Telefono { get; set; }

- Métodos públicos: AgregarCadete(), EliminarCadete() y GenerarInforme().

### Clase Cadete
- Atributos privados: id, nombre, direccion, telefono, listadoPedidos.
- Propiedades públicas: 
  public int Id { get; private set; }
  public string Nombre { get; set; }
- Métodos públicos: AsignarPedido(), ReasignarPedido(), GenerarInforme(), JornalACobrar() y PedidosEntregados().

### Clase Cliente
- Atributos privados: nombre, direccion, telefono, datosReferenciaDireccion.
- Propiedades públicas**: 
  public string Nombre { get; set; }
  public string Direccion { get; set; }
-Métodos públicos: VerTelefonoCliente() VerDatosReferenciaDireccion() para acceder a la información relacionada con el cliente.

## 4. Constructores sugeridos

### Clase Cadetería

public Cadeteria(string nombre, string telefono)
{
    Nombre = nombre;
    Telefono = telefono;
    ListadoCadetes = new List<Cadete>();
}

### Clase Cadete

public Cadete(int id, string nombre, string direccion, string telefono)
{
    Id = id;
    Nombre = nombre;
    Direccion = direccion;
    Telefono = telefono;
    ListadoPedidos = new List<Pedido>();
    JornalACobrar = 0;
}

### Clase Pedido

public Pedido(int nro, string obs, Cliente cliente)
{
    Nro = nro;
    Obs = obs;
    Cliente = cliente;
    Estado = "Pendiente";
}

### Clase Cliente
public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
{
    Nombre = nombre;
    Direccion = direccion;
    Telefono = telefono;
    DatosReferenciaDireccion = datosReferenciaDireccion;
}


## 5. Alternativa de diseño

Se podría haber utilizado una clase aparte para definir el estado de pedido, o agregado una clase de forma de pago del pedido. O también podría haberse hecho una relación no de composición para pedido y cliente, de manera que se tenga información de clientes potenciales también.
