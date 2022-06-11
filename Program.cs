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
          Personaje personaje1 = new Personaje();
          personaje1.getDatos();
          personaje1.getCaract();
        }
    }
}