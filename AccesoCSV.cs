using EspacioEntidades;
namespace EspacioAccesoData
{
    public class AccesoCSV:AccesoDato
    {
        public override List<Cadeteria> LeerCadeterias()
        {
            List<Cadeteria> cadeterias = new List<Cadeteria>();
            var csv = new FileStream("Cadeteria.CSV", FileMode.Open);//abrir el archivo
            var sr = new StreamReader(csv);// para leer
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                string[] fields = linea.Split(',');//para leer cada uno de los elementos hasta la ","
                cadeterias.Add(new Cadeteria(fields[0], fields[1]));

            }
            csv.Close();
            return cadeterias;
        }

        public override List<Cadete> LeerCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();
            var csv = new FileStream("Cadetes.CSV", FileMode.Open);//abrir el archivo
            var sr = new StreamReader(csv);// para leer
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                string[] fields = linea.Split(',');//para leer cada uno de los elementos hasta el ,
                // documento.Add(fields);            // string agregar = string.Join(";","cebolla");
                cadetes.Add(new Cadete(int.Parse(fields[0]), fields[1], fields[2], double.Parse(fields[3])));
            }
            csv.Close();
            return cadetes;
        }
        public void GenerarInforme(Cadeteria cadeteria)//genera un archivo .csv
        {
            FileStream fs = new FileStream("Informe.csv", FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                int i = 0, cantPedidosTotal = 0;
                double sumador = 0;
                // writer.WriteLine("Indice"+" "+"Nombre"+" "+"Extension");

                writer.WriteLine($"Cadeteria {cadeteria.Nombre} || telefono: {cadeteria.Telefono}\n");
                foreach (var cadete in cadeteria.ListadoCadetes)
                {

                    writer.WriteLine($"{cadete.Id}; Nombre: {cadete.Nombre}; monto:{cadeteria.jornalACobrar(cadete.Id)}; Cantidad de pedidos: {cadete.CantPedidos}");
                    i++;
                    sumador += cadeteria.jornalACobrar(cadete.Id);
                    cantPedidosTotal += cadete.CantPedidos;
                }

                writer.WriteLine("");
                writer.WriteLine("Monto total: " + sumador);
                writer.WriteLine("Cantidad total de pedidos: " + cantPedidosTotal);

                writer.WriteLine("Promedio de pedidos por cadete: " + (cantPedidosTotal / cadeteria.ListadoCadetes.Count()));
            }
        }
    }
}


// public string GenerarInforme()
// {
//     string cuerpo = "";

//     cuerpo = cadete.Nombre + "; " + cadete.jornalACobrar() + "; " + cadete.ListadoPedidos.Count();

//     return cuerpo;
// }



