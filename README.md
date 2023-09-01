# PUNTO2
 a) COMPOSICION cliente-pedidos 
    AGREGACION: Cadeteria-Cadete, Cadete-cliente
 b) Metodos extra:

    •Cadeteria: Crear pedido()
                AsignarPedido(): asigna un pedido a un cadete
                CambiarEstado(pedido, estado):
                GenerarInforme();
                ReasignarCadete()

    •Cadete: 
            MostrarDatos(),
            EliminarPedido()
            AgregarPedido(Pedido)


    •Pedido: CambiarEstado()

c) Los atributos que deberían ser públicos son:
    •Cliente: todos los atributos deben ser públicos
    •Pedido: los atributos deben ser privados pero sus propiedades publicas, excepto Cliente que debe ser privado. Sus metodos 
    •Cadete: los atributos deben ser privados pero sus propiedades publicas, excepto ListadoPedidos que debe ser privado
    Cadeteria: todo privado

d) Para la clase Cliente: Se inicializan todos sus atributos

Para la clase Pedidos: Se inicializan todos sus atributos junto con el Cliente

Para la clase Cadete: Se inicializan todos sus atributos, tal que el ListadoDePedidos sea una lista vacia inicialmente

Para la clase Cadeteria: Se inicializan todos sus atributos

e) Otra forma en la que se me ocurre plantear el problema es relacionando a la clase pedidos con cadeteria y esta con cadetes.