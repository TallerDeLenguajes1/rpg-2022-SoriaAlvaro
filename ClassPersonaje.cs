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

        private int PoderDeDisparo(){
            int PD = caract.Destreza * caract.Fuerza * caract.Nivel;
            return PD;
        }
        private int EfectividadDeDisparo(){
            Rand r = new Rand();
            int valAleatorio = r.Next(1,100);
            return valAleatorio;
        }
        private int ValorDeAtaque(){
            int PD = PoderDeDisparo(),
            ED = EfectividadDeDisparo();
            return PD * ED;
        }
        public int PorderDeDefensa(int vel){
            int PDEF = caract.Armadura * vel;
            return PDEF;
        }
 
        public int DanioProvocado(int PDEF){
            int ED = EfectividadDeDisparo(),
            VA = ValorDeAtaque(),
            MDP = 50000;
            return (((VA*ED)-PDEF)/MDP)*100;
        }
    }
}