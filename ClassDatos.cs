using System;

namespace DatosCharacter
{
    class Datos
    {
        private string tipo;
        private string nombre;
        private string apodo;
        private DateTime fechaDeNacimiento;
        private int edad;
        private int salud;
        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }
        private string[] nombres = new string[]{"Pibe Libertario","Viejo Inimputable", "Victoria","Jubilado armado","Sindicalista","El Brayan", "Piquetero", "Gordo del mortero","Zurdo","Inflación","Politico", "Javier","Mabel","Isabel","Cristina","Carla"};
        private string[] tipos = new string[]{"Francotirador","Ladrón","Cazarrecompensas","Embaucador","Salvaje","Ilusionista","Invocador","Sabio","Guerrero","Caballero","Mercenario","Ingeniero","Médium","Pistolero","Bombardero","Francotirador"};
        private string[] apodos = new string[]{"El Sucio", "Chorro", "Chino", "Forro", "Pubertario","ChocoBoy","El justiciero","el Pepe","eL Chino","Dogor","Falopa","Pibe Cantina", "Cabez de termo","Milipili","Tranza","vieja macrista"};
        private Random edR = new Random();
        private string RetornarNombre(string[] personaje){
            Random Rnd = new Random();
            int cantPersonajes = personaje.Length;
            int peronajeRandom = Rnd.Next(0,cantPersonajes);
            string nom = personaje[peronajeRandom];
            return nom;
        }
        public Datos(){
            this.Tipo = RetornarNombre(tipos);
            this.Nombre = RetornarNombre(nombres);
            this.Apodo = RetornarNombre(apodos);
            this.Edad = edR.Next(18,101);
            this.FechaDeNacimiento = new DateTime((2022-this.Edad),edR.Next(1,13),edR.Next(1,28));
            this.Salud = 100;
        }
    }
}