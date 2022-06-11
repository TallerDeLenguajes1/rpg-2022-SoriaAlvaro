using System;
using Caractcharacter;
using DatosCharacter;
namespace Personajes{
    class Personaje{
        private Caracteristicas caract;
        private Datos dat;

        public Personaje(){
            this.caract = new Caracteristicas();
            this.dat = new Datos();
        }

        public void getDatos(){
            Console.WriteLine($"Tipo: {dat.Tipo}");
            Console.WriteLine($"Nombre: {dat.Nombre}");
            Console.WriteLine($"Apodo: {dat.Apodo}");
            Console.WriteLine($"Edad: {dat.Edad}");
            Console.WriteLine($"Salud: {dat.Salud}");
        }
        public void getCaract(){
            Console.WriteLine($"Velocidad: {caract.Velocidad}");
            Console.WriteLine($"Destreza: {caract.Destreza}");
            Console.WriteLine($"Fuerza: {caract.Fuerza}");
            Console.WriteLine($"Nivel: {caract.Nivel}");
            Console.WriteLine($"Armadura: {caract.Armadura}");
        }
    }
}