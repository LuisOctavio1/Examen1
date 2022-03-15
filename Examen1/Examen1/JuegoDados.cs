using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class JuegoDados
    {
        private Dado dado;
        private int[] cantidadTocada;
        private int[] extremo = {2, 3, 4, 10, 11, 12};
        private int[] medio = {5, 6, 7, 8, 9};
        private Jugardor jugador;
        private int ultimo;

        public JuegoDados(int cantidadMaxima, int dineroInicial)
        {
            dado = new Dado(cantidadMaxima);
            cantidadTocada = new int[cantidadMaxima-1];
            jugador = new Jugardor(dineroInicial);
            for (int i = 0; i < cantidadTocada.Length; i++)
            {
                cantidadTocada[i] =0;
            }
        }

        public bool ApostarNumeroEspecifico(int numero,int dineroApostado)
        {
            jugador.DineroActual = jugador.DineroActual - dineroApostado;
            ultimo = dado.LanzarDado();
            cantidadTocada[ultimo - 2]++;
            if (numero == ultimo)
            {
                jugador.DineroActual = jugador.DineroActual + dineroApostado*10;
                return true;
            }
            return false;
        }

        public bool ApostarExtremo(int dineroApostado)
        {
            jugador.DineroActual = jugador.DineroActual - dineroApostado;
            ultimo = dado.LanzarDado();
            cantidadTocada[ultimo - 2]++;
            for (int i = 0; i < extremo.Length; i++)
            {
                if (i == ultimo)
                {
                    jugador.DineroActual = jugador.DineroActual + dineroApostado * 8;
                    return true;
                }
            }

            return false;
        }

        public bool ApostarMedio(int dineroApostado)
        {
            jugador.DineroActual = jugador.DineroActual - dineroApostado;
            ultimo = dado.LanzarDado();
            cantidadTocada[ultimo - 2]++;
            for (int i = 0; i < medio.Length; i++)
            {
                if (i == ultimo)
                {
                    jugador.DineroActual = jugador.DineroActual + dineroApostado * 4;
                    return true;
                }
            }

            return false;
        }

        public bool ApostarPar(int dineroApostado)
        {
            jugador.DineroActual = jugador.DineroActual - dineroApostado;
            ultimo = dado.LanzarDado();
            cantidadTocada[ultimo - 2]++;
            if (ultimo % 2 == 0)
            {
                jugador.DineroActual = jugador.DineroActual + dineroApostado * 2;
                return true;
            }

            return false;
        }

        public bool ApostarImpar(int dineroApostado)
        {
            jugador.DineroActual = jugador.DineroActual - dineroApostado;
            ultimo = dado.LanzarDado();
            cantidadTocada[ultimo - 2]++;
            if (ultimo % 2 != 0)
            {
                jugador.DineroActual = jugador.DineroActual + dineroApostado * 2;
                return true;
            }

            return false;
        }

        public int Balance()
        {
            return jugador.DineroActual;
        }

        public int DineroInicial()
        {
            return jugador.DineroInicial;
        }

        public int NumeroMasTirado()
        {
            int mayor = 0;
            for (int i = 1; i < cantidadTocada.Length; i++)
            {
                if (cantidadTocada[mayor] < cantidadTocada[i])
                {
                    mayor = i;
                }
            }
            return mayor;
        }

        public int NumeroMenosTirado()
        {
            int menor = 0;
            for (int i = 1; i < cantidadTocada.Length; i++)
            {
                if (cantidadTocada[menor] > cantidadTocada[i])
                {
                    menor = i;
                }
            }
            return menor;
        }

        public int CantidadDeExtremos()
        {
            return cantidadTocada[0] + cantidadTocada[1] + cantidadTocada[2] + cantidadTocada[8] + cantidadTocada[9] +
                   cantidadTocada[10];

        }
        public int CantidadDeMedios()
        {
            return cantidadTocada[3] + cantidadTocada[4] + cantidadTocada[5] + cantidadTocada[6] + cantidadTocada[7];

        }

        public int CantidadDePares()
        {
            return cantidadTocada[0] + cantidadTocada[2] + cantidadTocada[4] + cantidadTocada[6] + cantidadTocada[8] + cantidadTocada[10];

        }

        public int CantidadDeImpares()
        {
            return cantidadTocada[1] + cantidadTocada[3] + cantidadTocada[5] + cantidadTocada[7] + cantidadTocada[9];

        }

        public int CantidadDeTiradas()
        {
            int cantidad = 0;
            foreach (int numero in cantidadTocada)
            {
                cantidad = numero + cantidad;
            }

            return cantidad;
        }

        public int Ultimo
        {
            get => ultimo;
        }


    }
}
