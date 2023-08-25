using ClienteSpace;

namespace PedidosSpace
{
    class Pedido
    {
        private int nro;
        private string obs;
        private string cliente;
        private bool estado;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        private string Cliente { get => cliente; set => cliente = value; }
        public bool Estado { get => estado; set => estado = value; }

        public Pedido(int nro, string obs, string cliente, bool estado)
        {
            this.Nro = nro;
            this.Obs = obs;
            this.Cliente = cliente;
            this.Estado = estado;
        }

        //metodos

        public string verDatosCliente()
        {
            return 0;
        }
    

    }


}