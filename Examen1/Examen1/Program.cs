// See https://aka.ms/new-console-template for more information

using Examen1;

JuegoDados juego = new JuegoDados(12,300);
MenuJuegoDado menu = new MenuJuegoDado(juego);
juego.ApostarExtremo(10);
juego.ApostarMedio(20);
juego.ApostarNumeroEspecifico(7,10);
juego.ApostarPar(20);
juego.ApostarImpar(20);
juego.ApostarExtremo(20);
juego.ApostarMedio(20);
menu.ManejarMenu1();