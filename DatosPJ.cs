namespace infoPJ
{
    class Data
    {
        private string? tipo ;
        private string? nombre ;
        private string? apodo ;
        private DateTime fechaDeNacimiento ;
        private int edad ;

        public string? Tipo { get => tipo; set => tipo = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
    }
    class Stats {
        private int salud ;
        private double velocidad;
        private double destreza;
        private double fuerza;
        private double nivel;
        private double armadura;
        public int Salud { get => salud; set => salud = value; }
        public double Velocidad { get => velocidad; set => velocidad = value; }
        public double Destreza { get => destreza; set => destreza = value; }
        public double Fuerza { get => fuerza; set => fuerza = value; }
        public double Nivel { get => nivel; set => nivel = value; }
        public double Armadura { get => armadura; set => armadura = value; }
    }


    class DatosPJ {
        int id = 0;
        private Data? data = new Data();
        private Stats stats = new Stats();

        public Data? Data { get => data; set => data = value; }
        public Stats Stats { get => stats; set => stats = value; }
        public int Id { get => id; set => id = value; }
    }
}