using CadeteSpace;

namespace CadeteriaSpace
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
    }
}