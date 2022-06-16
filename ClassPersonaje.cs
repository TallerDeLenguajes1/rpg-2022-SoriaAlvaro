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
        public Caracteristicas Caract { get => caract; set => caract = value; }
        public Datos Dat { get => dat; set => dat = value; }
        public void mostrarDatos(){
            System.Console.WriteLine("Nombre: {0}\tApodo: {1}\tTipo: {2} \n\tEdad: {3} \tSalud: {4}\tNivel: {5}\nFuerza: {6}\tVelovidad: {7}\tDestreza: {8}\tArmadura: {9}\n",this.dat.Nombre,this.dat.Apodo,this.dat.Tipo,this.dat.Edad,this.dat.Salud,this.caract.Nivel,this.caract.Fuerza,this.caract.Velocidad,this.caract.Destreza,this.caract.Armadura);
        }
        public void danioProvoado(Personaje rival){
            Random r = new Random();
            double PD = this.caract.Destreza * this.caract.Fuerza * this.caract.Nivel,
            ED = r.Next(1,101),
            VA = PD * ED,
            PDEF = this.caract.Armadura * rival.caract.Velocidad,
            MDP = 50000;
            int DP =(int) Math.Truncate((((VA * ED) - PDEF)/MDP)*100);
            System.Console.WriteLine("Poder de {6}...\nPD:{0}\t\tED:{1}\t\tVA:{2}\nPDEF:{3}\t\tMDP:{4}\t\tDP:{5}\n-{5}de salud",PD,ED,VA,PDEF,MDP,DP,this.dat.Nombre);
            rival.dat.Salud -= DP;
            System.Console.WriteLine("Salud restante de {0}: {1}\n",rival.dat.Nombre,rival.dat.Salud);
        }
    }
}