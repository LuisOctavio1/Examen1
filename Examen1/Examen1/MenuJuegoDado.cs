using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class MenuJuegoDado
    {
        private JuegoDados juego;

        public MenuJuegoDado(JuegoDados juego)
        {
            this.juego = juego;
        }

        private void ImprimirMenu()
        {
            Console.WriteLine("1. Balance\n" +
                              "2. Cantidad de tiradas realizadas\n" +
                              "3. Numero que mas veces se ha tirado\n" +
                              "4. Numero que menos veces se ha tirado\n" +
                              "5. Cantidad de resultados extremos\n" +
                              "6. Cantidad de resultados medios\n" +
                              "7. Cantidad de resultados pares\n" +
                              "8. Cantidad de resultados impares\n" +
                              "9. Apostar\n" +
                              "10. Salir");
        }

        private void ImprimirMenuApuestas()
        {
            Console.WriteLine("1. Apostar un numero en especifico (2 - 12)\n" +
                              "2. Apostar a que el nuemro es un extremo (2,3,4,10,11,12)\n" +
                              "3. Apostar a que el numero es un medio(5,6,7,8,9)\n" +
                              "4. Apostar a que el numero sera par\n" +
                              "5. Apostar a que el numero sera impar\n" +
                              "6. Atras");
        }

        public void ManejarMenu1()
        {
            int opcion = 0;
            do
            {
                ImprimirMenu();
            } while (!ValidarMenu(10, ref opcion));

            switch (opcion)
            {
                case 1:
                    ImprimirBalance(false);
                    break;
                case 2:
                    ImprimirCantidadTiradas();
                    break;
                case 3:
                    ImprimirNumeroMasTirado();
                    break;
                case 4:
                    ImprimirNumeroMenosTirado();
                    break;
                case 5:
                    ImprimirResultadosExtremos();
                    break;
                case 6:
                    ImprimirResultadosMedios();
                    break;
                case 7:
                    ImprimirResultadosPares();
                    break;
                case 8:
                    ImprimirResultadosImpares();
                    break;
                case 9:
                    ControlarMenuApuestas();
                    break;
                case 10:
                    ImprimirBalance(true);
                    break;
            }
        }

        private void ControlarMenuApuestas()
        {
            int opcion = 0;
            do
            {
                ImprimirMenuApuestas();
            } while (!ValidarMenu(6, ref opcion));

            switch (opcion)
            {
                case 1:
                   ApostarNumero();
                    break;
                case 2:
                   ApostarExtremo();
                    break;
                case 3:
                   ApostarMedio();
                    break;
                case 4:
                    ApostarPar();
                    break;
                case 5:
                    ApostarImPar();
                    break;
                case 6:
                    Console.Clear();
                    ManejarMenu1();
                    break;
            }
        }

        private bool ValidarMenu(int opciones, ref int opcionSeleccionada)
        {
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                if (n <= opciones && n > 0)
                {
                    opcionSeleccionada = n;
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opcion invalida");
                    return false;
                }

            }
            Console.Clear();
            Console.WriteLine("Opcion invalida");
            return false;
        }

        private void ImprimirBalance(bool salir)
        {
            int balance =  juego.Balance() - juego.DineroInicial();
            Console.WriteLine("Tu dinero actual es: " + juego.Balance());
            if (balance > 0)
            {
                Console.WriteLine("Haz ganado " + balance);
            }
            else
            {
                Console.WriteLine("Haz perdido " + (-1)*balance);
                
            }

            if (salir == true)
            {
                Console.WriteLine("Saliendo del programa");
            }
            else
            {
                IrAMenuPrincipal();
            }
        }

        private void ImprimirCantidadTiradas()
        {
            Console.WriteLine("La cantidad de tiradas actualmente es " + juego.CantidadDeTiradas());
            IrAMenuPrincipal();
        }

        private void ImprimirNumeroMasTirado()
        {
            int tiradas = juego.NumeroMasTirado() + 2;
            Console.WriteLine("El numero que mas a tocado es " + tiradas );
            IrAMenuPrincipal();
        }

        private void ImprimirNumeroMenosTirado()
        {
            int tiradas = juego.NumeroMenosTirado() + 2;
            Console.WriteLine("El numero menos tirado es " + tiradas);
            IrAMenuPrincipal();
        }

        private void ImprimirResultadosExtremos()
        {
            Console.WriteLine("La cantidad de extremos que han tocado es de " + juego.CantidadDeExtremos());
            IrAMenuPrincipal();
        }

        private void ImprimirResultadosMedios()
        {
            Console.WriteLine("La cantidad de medios que han tocado es de " + juego.CantidadDeMedios());
            IrAMenuPrincipal();

        }

        private void ImprimirResultadosPares()
        {
            Console.WriteLine("La cantidad de pares que han tocado es de " + juego.CantidadDePares());
            IrAMenuPrincipal();
        }

        private void ImprimirResultadosImpares()
        {
            Console.WriteLine("La cantidad de impares que han tocado es de " + juego.CantidadDeImpares());
            IrAMenuPrincipal();
        }

        private void ApostarNumero()
        {
            Console.WriteLine("Ingresa el numero por el que quieres apostar(2-12)");
            int numero = 0;
            ValidarNumero(ref numero);
            int dinero = PedirDinero();
            if (juego.ApostarNumeroEspecifico(numero, dinero))
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Felicidades, haz ganado, tu apuesta se multiplica por 10");
                IrAMenuApuestas();
            }
            else
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Mala suerte, toco un numero distinto, haz perdido la apuesta");
                if (juego.Balance() >0)
                {
                    IrAMenuApuestas();
                }
                else
                {
                    Console.WriteLine("Ya no tienes dinero, terminando programa");
                }
                
            }
        }

        private void ApostarExtremo()
        {
            int dinero = PedirDinero();
            if (juego.ApostarExtremo(dinero))
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Felicidades, haz ganado, tu apuesta se multiplica por 8");
                IrAMenuApuestas();
            }
            else
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Mala suerte, toco un numero distinto, perdiste");
                if (juego.Balance() > 0)
                {
                    IrAMenuApuestas();
                }
                else
                {
                    Console.WriteLine("Ya no tienes dinero, terminando programa");
                }
            }

        }

        private void ApostarMedio()
        {
            int dinero = PedirDinero();
            if (juego.ApostarMedio(dinero))
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Felicidades, haz ganado, tu apuesta se multiplica por 4");
                IrAMenuApuestas();
            }
            else
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Mala suerte, toco un numero distinto, perdiste");
                if (juego.Balance() > 0)
                {
                    IrAMenuApuestas();
                }
                else
                {
                    Console.WriteLine("Ya no tienes dinero, terminando programa");
                }
            }
        }

        private void ApostarPar()
        {
            int dinero = PedirDinero();
            if (juego.ApostarPar(dinero))
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Felicidades, haz ganado, tu apuesta se multiplica por 2");
                IrAMenuApuestas();
            }
            else
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Mala suerte, toco un numero distinto, perdiste");
                if (juego.Balance() > 0)
                {
                    IrAMenuApuestas();
                }
                else
                {
                    Console.WriteLine("Ya no tienes dinero, terminando programa");
                }
            }
        }

        private void ApostarImPar()
        {
            int dinero = PedirDinero();
            if (juego.ApostarImpar(dinero))
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Felicidades, haz ganado, tu apuesta se multiplica por 2");
                IrAMenuApuestas();
            }
            else
            {
                Console.WriteLine("El numero que toco es " + juego.Ultimo);
                Console.WriteLine("Mala suerte, toco un numero distinto, perdiste");
                if (juego.Balance() > 0)
                {
                    IrAMenuApuestas();
                }
                else
                {
                    Console.WriteLine("Ya no tienes dinero, terminando programa");
                }
            }
        }

        private void ValidarNumero(ref int numero)
        {
            while (!int.TryParse(Console.ReadLine(), out numero) && numero > 1)
            {
                Console.WriteLine("Elemento invalido");
            }
        }

        private void ValidarDinero(ref int numero)
        {
            while (!int.TryParse(Console.ReadLine(), out numero) && numero % 10 == 0 && numero <= juego.Balance())
            {
                Console.WriteLine("Elemento invalido, no es multiplo de 10 o ingresaste una cantidad mayor a la que tienes");
            }
        }

        private int PedirDinero()
        {
            Console.WriteLine("Ingrea el dinero que quieres apostar(solo multiplos de 10)");
            Console.WriteLine("Actualmente tienes: " + juego.Balance());
            int dinero = 0;
            ValidarDinero(ref dinero);
            return dinero;
        }

        private void IrAMenuApuestas()
        {
            Console.WriteLine("Ingresa enter para continuar");
            Console.ReadLine();
            Console.Clear();
            ControlarMenuApuestas();
        }

        private void IrAMenuPrincipal()
        {
            Console.WriteLine("Ingresa enter para continuar");
            Console.ReadLine();
            Console.Clear();
            ManejarMenu1();
        }

    }
}
