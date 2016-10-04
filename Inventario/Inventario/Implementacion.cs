using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventario
{
    class Implementacion
    {
        public String cambiaFecha(String date)
        {
            String fecha = date;
            String dia,mes,anio;
            StringBuilder sb = new StringBuilder();
            //Console.WriteLine("Imprimiendo fecha" + date);
            dia = fecha.Substring(0, 2);
            mes = fecha.Substring(3, 2);
            anio = fecha.Substring(6, 4);
            //Console.WriteLine("Imprimiendo dia" + dia);
            //Console.WriteLine("Imprimiendo mes" + mes);
            //Console.WriteLine("Imprimiendo año" + anio);
            sb.Append(anio);
            sb.Append("-");
            sb.Append(mes);
            sb.Append("-");
            sb.Append(dia);

            return sb.ToString();
        }
        
    }
}
