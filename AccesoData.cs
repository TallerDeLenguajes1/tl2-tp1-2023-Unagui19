using EspacioEntidades;
namespace EspacioAccesoData
{
    public class accesoData
    {
        public List<Cadeteria> LeerCadeterias()
        {
            List<Cadeteria> cadeterias = new List<Cadeteria>();
            var csv = new FileStream("Cadeteria.CSV", FileMode.Open);//abrir el archivo
            var sr = new StreamReader(csv);// para leer
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                string[] fields = linea.Split(',');//para leer cada uno de los elementos hasta el ,
                // documento.Add(fields);            // string agregar = string.Join(";","cebolla");
                cadeterias.Add(new Cadeteria(fields[0],fields[1]));
                //creo una lista de strings
                // foreach (string item in cadetes)//para mostrar cada uno de los elementos
                // {
                //     Console.WriteLine(item + "\t");
                // }
                // Console.WriteLine("");
                // string aux = string.Join(",", modified.ToArray()) ara agregar algo
                // Console.WriteLine("" + aux);
                // modificar.Add(aux);
            }
            // csv.Close();
            return cadeterias;
        }
    }



}
