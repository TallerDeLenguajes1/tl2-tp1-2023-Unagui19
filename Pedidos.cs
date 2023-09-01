using EspacioEntidades;
using System.Linq;

enum Estado
{
    entregado,
    pendiente,
    cancelado
}

namespace EspacioEntidades
{
    class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private Estado estado;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        private Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado Estado { get => estado; set => estado = value; }

        public Pedido(int nro, string obs, string nombre, string direccion, long telefono, string datosReferenciaDireccion)
        {
            this.Nro = nro;
            this.Obs = obs;
            cliente = new Cliente(nombre,direccion, telefono, datosReferenciaDireccion);//esto es porque es composicion
        }

        //metodos

        public Cliente verDatosCliente()
        {
            return cliente;
        }
    

        public string verDireccionCliente()
        {
            return cliente.Direccion;
        }

        public void cambiarEstado()
        {
            if (estado==Estado.entregado)
            {
                estado
            }
        }

        public void aceptarPedido()
        {
            
        }

    }


}