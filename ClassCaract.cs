using System;
namespace Caractcharacter
{
    class Caracteristicas
    {
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;

        private Random rand= new Random();

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public Caracteristicas(){
            this.Velocidad = rand.Next(1,11);
            this.Destreza = rand.Next(1,6);
            this.Fuerza = rand.Next(1,11);
            this.Nivel = rand.Next(1,11);
            this.Armadura = rand.Next(1,11);
        }
    }
}