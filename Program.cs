using System;
using DatosCharacter;
using Caractcharacter;
using Personajes;

namespace RPGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
          List<Personaje>Luchadores = new List<Personaje>();
          Rand r = new Rand();
          int cantLuchadores = r.Next(2,5), j = 0;
          //carga de luchadores
          while(j < cantLuchadores){
            List.Add(new Personajes());
            j++;
          }
          //ataques por turnos
          int turnos = 6;
          for(int k = 0; k < cantLuchadores; k++){
              for(int i = 1; i <= 6; i++){
                if(i % 2 == 0){
                  System.Console.WriteLine($"{Luchadores[0].dat.Nombre} ataca a {Luchadores[k+1].dat.Nombre}");
                  int vel = Luchadores[k+1].caract.Velocidad,
                  PDEF = Luchadores[0].PorderDeDefensa(vel),
                  DP = Luchadores[0].DanioProvocado(PDEF),
                  danio = Luchadores[k+1].dat.Salud - DP;
                  System.Console.WriteLine($"Salud de {Luchadores[k+1].dat.Nombre} = {danio}");
                  Luchadores[k+1].dat.Salud -= DP;
                  if(Luchadores[k+1].dat.Salud < 1){
                    Luchadores.RemoveAt(k+1);
                    continue;
                  }
                }
                if( i % 2 != 0){
                  System.Console.WriteLine($"{Luchadores[k+1].dat.Nombre} ataca a {Luchadores[0].dat.Nombre}");
                  int vel = Luchadores[0].caract.Velocidad,
                  PDEF = Luchadores[k+1].PorderDeDefensa(vel),
                  DP = Luchadores[k+1].DanioProvocado(PDEF),
                  danio = Luchadores[0].dat.Salud - DP;
                  System.Console.WriteLine($"Salud de {Luchadores[k+1].dat.Nombre} = {danio}");
                  Luchadores[0].dat.Salud -= DP;
                  if(Luchadores[0].dat.Salud < 1){
                    Luchadores.RemoveAt(0);
                    System.Console.WriteLine("Perdiste, fin del juego");
                    break;
                  }
                }
            }
          }
          
        }
    }
}