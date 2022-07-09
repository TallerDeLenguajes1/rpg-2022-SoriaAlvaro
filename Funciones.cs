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
            var miJSON = File.ReadAllText(path);
            var listaPJ = JsonSerializer.Deserialize<List<DatosPJ>>(miJSON);
            return listaPJ;
        }
        static public DatosPJ CargarPJ(){
            var pj = new DatosPJ(){
            Data = Functions_Datos.CargarDatosPJ(),
            Stats = Functions_Datos.CargarStatsPJ()
            };
            return pj;
        }
        static public void CrearEnemigos(){
            string personajesJSON = @"/home/alvaro/Documentos/Taller/Pruebas/newClass/personajes/personaje.json";
            var listaPJ = new List<DatosPJ>();
            /* if(File.Exists(personajesJSON) && listaPJ.Count < 5){
                for(int i = 0; i < 5; i++){
                    listaPJ.Add(CargarPJ());
                }
            }else{ */
                for(int i = 0; i < 5; i++){
                    listaPJ.Add(CargarPJ());
                }
/*             } */
            EscribirEnJSON(listaPJ, personajesJSON);
        }
        static public void MostarDatos(DatosPJ pj){
            System.Console.WriteLine("Nombre: {0}\nApodo: {1}\nTipo: {2} \nEdad: {3} \nSalud: {4}\nNivel: {5}\nFuerza: {6}\nVelovidad: {7}\nDestreza: {8}\nArmadura: {9}\n",pj.Data.Nombre,pj.Data.Apodo,pj.Data.Tipo,pj.Data.Edad,pj.Stats.Salud,pj.Stats.Nivel,pj.Stats.Fuerza,pj.Stats.Velocidad,pj.Stats.Destreza,pj.Stats.Armadura);
        }
    }
    class Functions_Fight
    {
        static public void danioProvoado(DatosPJ atacante,DatosPJ defenzor){
            Random r = new Random();
            double PD = atacante.Stats.Destreza * atacante.Stats.Fuerza * atacante.Stats.Nivel,
            ED = r.Next(1,101),
            VA = PD * ED,
            PDEF = atacante.Stats.Armadura * defenzor.Stats.Velocidad,
            MDP = 50000;
            int DP =(int) Math.Truncate((((VA * ED) - PDEF)/MDP)*100);
            System.Console.WriteLine("{0}: {1} Ataca a {2}: {3}!",atacante.Data.Nombre,atacante.Stats.Salud,defenzor.Data.Nombre,defenzor.Stats.Salud);
            System.Console.WriteLine("Poder de ataque de {0}: {1}",atacante.Data.Nombre,DP);
            System.Console.WriteLine("{0} Dañado...\n-{1} de salud...",defenzor.Data.Nombre,DP);
            defenzor.Stats.Salud -= DP;
            System.Console.WriteLine("Salud restante de {0}: {1}\n",defenzor.Data.Nombre,defenzor.Stats.Salud);
        }
        static public int TirarMoneda(){
            Random r = new Random();
            return r.Next(0,2);
        }
        static public DatosPJ LuchaYCargarGanadores(DatosPJ principal, List<DatosPJ> listaPJs){
            int turnos = 0;
            bool ganador = true;
            int moneda = Functions_Fight.TirarMoneda();
            var r = new Random();
            for(int key = 0; key < listaPJs.Count; key++){
                System.Console.WriteLine("\nPelea {0}",key+1);
                while(turnos < 3){
                    System.Console.WriteLine("Turno {0}",turnos+1);
                    if(principal.Stats.Salud < 0){
                        ganador = false;
                        break;
                    }
                    if(listaPJs[key].Stats.Salud < 0){
                        listaPJs.RemoveAt(r.Next(0,listaPJs.Count));
                        break;
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
                    ganador = false;
                    break;
                }else{
                    listaPJs.RemoveAt(r.Next(0,listaPJs.Count));
                    principal.Stats.Salud = 1000;
                }
                System.Console.WriteLine("Fin de la Pelea {0}\n",key+1);
            }
            if(ganador == true){
                System.Console.WriteLine("Ganador! {0}",principal.Data.Nombre);
                return principal;
            }else{
                System.Console.WriteLine("GAME OVER");
            }
            string personajesJSON = @"/home/alvaro/Documentos/Taller/Pruebas/newClass/personajes/personaje.json";
            Functions_Datos.EscribirEnJSON(listaPJs,personajesJSON);
            return null;
        }
    }
}