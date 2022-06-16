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
        public Datos(){
            this.tipo = "";
            this.nombre = "";
            this.apodo = "";
            this.edad = 0;
            this.fechaDeNacimiento = new DateTime(1995,1,1);
            this.salud = 1000;
        }
    }
}