using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Dado
    {
        private Random lanzada = new Random();
        private int numero;
        public Dado(int numero)
        {
            this.numero = numero;
        }

        public int LanzarDado()
        {
            return lanzada.Next(2, numero);
        }
    }
}
