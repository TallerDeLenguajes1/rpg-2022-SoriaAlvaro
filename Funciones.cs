using System.Net;
using System.Text.Json;
using DatosPJApi;
using infoPJ;

namespace muchasFunciones
{
    class Functions_Datos
    {
        static private string Solicitar(string url)
        {
            string result = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (WebResponse respuesta = request.GetResponse())
            {
                using (Stream StreamReader = respuesta.GetResponseStream())
                {
                    if (StreamReader != null)
                    {
                        using (StreamReader objReader = new StreamReader(StreamReader))
                        {
                            result = objReader.ReadToEnd();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Responde");
                    }
                }
            }
            return result;
        }
        static public Data CargarDatosPJ()
        {
            var newData = new Data();
            var r = new Random();
            var url = new string[]{
            "https://fakerapi.it/api/v1/custom?_quantity=20&name=firstName&birthday=date",
            "https://www.dnd5eapi.co/api/classes",
            "https://www.dnd5eapi.co/api/monsters"};
            var datosApi = JsonSerializer.Deserialize<DatosApi>(Solicitar(url[0]));
            var classes = JsonSerializer.Deserialize<Classes_Monsters>(Solicitar(url[1]));
            var apodoMonsters = JsonSerializer.Deserialize<Classes_Monsters>(Solicitar(url[2]));
            DateTime anioAct = DateTime.Now;
            newData.Nombre = datosApi.data[r.Next(0, datosApi.total)].name;
            newData.FechaDeNacimiento = DateTime.Parse(datosApi.data[r.Next(0, datosApi.total)].birthday);
            newData.Tipo = classes.results[r.Next(0, classes.count)].name;
            newData.Apodo = apodoMonsters.results[r.Next(0, apodoMonsters.count)].name;
            newData.Edad = Convert.ToInt32((anioAct.Year - newData.FechaDeNacimiento.Year).ToString());
            return newData;
        }
        static public Stats CargarStatsPJ()
        {
            var newStats = new Stats();
            var r = new Random();
            newStats.Salud = 1000;
            newStats.Velocidad = r.Next(1, 11);
            newStats.Destreza = r.Next(1, 6);
            newStats.Fuerza = r.Next(1, 11);
            newStats.Nivel = r.Next(1, 11);
            newStats.Armadura = r.Next(1, 11);
            return newStats;
        }
        static public void EscribirEnJSON(List<DatosPJ> dataList, string personajesJSON)
        {
            using(StreamWriter sw = new StreamWriter(personajesJSON,false))
            {
                string? jsonString = JsonSerializer.Serialize(dataList);
                sw.Write(jsonString);
                sw.Close();
            }
        }
        static public List<DatosPJ> DeserializarDatos(string path){
            string miJSON = File.ReadAllText(path);
            var listaPJ = JsonSerializer.Deserialize<List<DatosPJ>>(miJSON);
            return listaPJ;
        }
        static public DatosPJ CargarPJ(int i=0){
            var pj = new DatosPJ(){
<<<<<<< HEAD
=======
                Id = i,
>>>>>>> prueba1
                Data = Functions_Datos.CargarDatosPJ(),
                Stats = Functions_Datos.CargarStatsPJ()
            };
            return pj;
        }
        static public void CrearEnemigos(){
<<<<<<< HEAD
            string personajesJSON = @"/home/alvaro/Documentos/Taller/rpg-2022-SoriaAlvaro/personajes/personaje.json";
=======
            string personajesJSON = Directory.GetCurrentDirectory()+@"/personaje.json";
>>>>>>> prueba1
            var listaPJ = new List<DatosPJ>();
            var r = new Random();
            if(File.Exists(personajesJSON) == true){    
                listaPJ = DeserializarDatos(personajesJSON);
                for(int i = 0; i < 6; i++){
                    int newKey = r.Next(1,99);
                    bool distinto = false;
                    while(distinto != false){
                        foreach(var li in listaPJ){
                            if(li.Id == newKey){
                                distinto = false;
                                newKey = r.Next(1,99);
                                break;
                            }
                            distinto = true;
                        }
                    }
                    if(distinto == true){
                        listaPJ.Add(CargarPJ(newKey));
                    }
                }
            }
            for(int i = 0; i < 6; i++){
                listaPJ.Add(CargarPJ(r.Next(1,99)));
            }
            EscribirEnJSON(listaPJ, personajesJSON);
        }
        static public void MostarDatos(DatosPJ pj){
            System.Console.WriteLine("Nombre: {0}\nApodo: {1}\nTipo: {2} \nEdad: {3} \nSalud: {4}\nNivel: {5}\nFuerza: {6}\nVelovidad: {7}\nDestreza: {8}\nArmadura: {9}\n",pj.Data.Nombre,pj.Data.Apodo,pj.Data.Tipo,pj.Data.Edad,pj.Stats.Salud,pj.Stats.Nivel,pj.Stats.Fuerza,pj.Stats.Velocidad,pj.Stats.Destreza,pj.Stats.Armadura);
        }
    }
    class Functions_Fight
    {
        static private int danioProvoado(DatosPJ atacante,DatosPJ defenzor){
            Random r = new Random();
            double PD = atacante.Stats.Destreza * atacante.Stats.Fuerza * atacante.Stats.Nivel,
            ED = r.Next(1,101),
            VA = PD * ED,
            PDEF = atacante.Stats.Armadura * defenzor.Stats.Velocidad,
            MDP = 20000;
            int DP =(int) Math.Truncate((((VA * ED) - PDEF)/MDP)*100);
            System.Console.WriteLine("{0}::: {1} Ataca a {2}::: {3}!",atacante.Data.Nombre,atacante.Stats.Salud,defenzor.Data.Nombre,defenzor.Stats.Salud);
            System.Console.WriteLine("Poder de ataque de {0}: {1}",atacante.Data.Nombre,DP);
            System.Console.WriteLine("{0} Dañado...\n-{1} de salud...",defenzor.Data.Nombre,DP);
            return DP;
        }
        static public int TirarMoneda(){
            Random r = new Random();
            return r.Next(0,2);
        }
<<<<<<< HEAD
        static public bool Luchar(DatosPJ principal, List<DatosPJ> listaPJs){
            int turnos = 0;
            bool ganador = false;
            int moneda = Functions_Fight.TirarMoneda();
            int total = listaPJs.Count;
            int key = 0;
            while(key < total){
                System.Console.WriteLine("Pelea {0}",key+1);
                while(turnos < 3){
                    System.Console.WriteLine("Turno {0}",turnos+1);
                    if(principal.Stats.Salud < 0 || listaPJs[key].Stats.Salud < 0){
                        turnos = 3;
                    }
                    if(moneda == 0){
                        Functions_Fight.danioProvoado(principal, listaPJs[key]);
                        moneda = 1;
                    }else{
                        Functions_Fight.danioProvoado(listaPJs[key], principal);
                        moneda = 0;
                    }
                    turnos++;
                }
                if(principal.Stats.Salud < listaPJs[key].Stats.Salud){
                    key = total;
                }else{
                    ganador = true;
                    key++;
                }
            }
            if(ganador == true){
                return true;
            }
            return false;
=======
        static public bool Luchar(DatosPJ principal, DatosPJ rival){
            int moneda = TirarMoneda();
            bool ganador = false;
            while(principal.Stats.Salud > 0 || rival.Stats.Salud > 0){
                if(principal.Stats.Salud < 0 || rival.Stats.Salud < 0){
                    break;
                } 
                if(moneda == 0){
                    rival.Stats.Salud -= danioProvoado(principal,rival);
                    System.Console.WriteLine("Salud restante de {0}: {1}\n",rival.Data.Nombre,rival.Stats.Salud);
                    moneda = 1;
                }
                if(moneda == 1){
                    principal.Stats.Salud -= danioProvoado(rival,principal);
                    System.Console.WriteLine("Salud restante de {0}: {1}\n",principal.Data.Nombre,principal.Stats.Salud);
                    moneda = 0;
                }
            }
            if(!(rival.Stats.Salud > principal.Stats.Salud)){
                ganador = true;
            }
            return ganador;
>>>>>>> prueba1
        }
    }
}