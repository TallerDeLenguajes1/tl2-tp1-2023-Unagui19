using System.ComponentModel;
using EspacioEntidades;

namespace EspacioEntidades
{
    class Cadeteria
    {
        private string nombre;
        private int telefono;
        private List<Cadete> listadoCadetes;
        private bool estado;

        public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes, bool estado)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.ListadoCadetes = listadoCadetes;
            this.Estado = estado;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public bool Estado { get => estado; set => estado = value; }
        internal List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        Pedido crearPedido(int numero, string obs,string nombre, string direc, int telefono, string referencias)
        {
            Pedido nuevoPedido = new Pedido(numero,obs, nombre, direc ,telefono, referencias);

            return nuevoPedido;
        }
        public void AsignarPedido(Pedido ) //asigna un pedido a un cadete
        {
            Cadete 
            return 0;
        }
         CambiarEstado(pedido, estado):
        GenerarInforme();
        ReasignarCadete()

    }
}