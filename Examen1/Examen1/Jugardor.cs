using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Jugardor
    {
        private int dineroInicial;
        private int dineroActual;

        public Jugardor(int dineroInicial)
        {
            this.dineroInicial = dineroInicial;
            dineroActual = dineroInicial;
        }

        public int DineroInicial
        {
            get => dineroInicial;
            set => dineroInicial = value;
        }

        public int DineroActual
        {
            get => dineroActual;
            set => dineroActual = value;
        }


    }
}
