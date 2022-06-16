using System;
namespace Caractcharacter
{
    class Caracteristicas
    {
        private double velocidad;
        private double destreza;
        private double fuerza;
        private double nivel;
        private double armadura;

        private Random rand= new Random();

        public double Velocidad { get => velocidad; set => velocidad = value; }
        public double Destreza { get => destreza; set => destreza = value; }
        public double Fuerza { get => fuerza; set => fuerza = value; }
        public double Nivel { get => nivel; set => nivel = value; }
        public double Armadura { get => armadura; set => armadura = value; }
        public Caracteristicas(){
            this.velocidad = rand.Next(1,11);
            this.destreza = rand.Next(1,6);
            this.fuerza = rand.Next(1,11);
            this.nivel = rand.Next(1,11);
            this.armadura = rand.Next(1,11);
        }
    }
}