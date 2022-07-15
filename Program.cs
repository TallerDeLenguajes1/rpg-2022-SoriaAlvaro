using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatosPJApi;
using infoPJ;
using muchasFunciones;

internal class Program
{
    private static void Main(string[] args)
    {
<<<<<<< HEAD
        string personajesJSON = @"/home/alvaro/Documentos/Taller/rpg-2022-SoriaAlvaro/personajes/personaje.json";
        string ganaodoresJSON = Directory.GetCurrentDirectory()+@"/ganadores/ganadores.json";
        /* ConsoleKeyInfo cki; */
       /*  do{ */
            var listaGanadores = new List<DatosPJ>();
            int op = 0;
            do{
                System.Console.WriteLine("Cargando...");
                Functions_Datos.CrearEnemigos();
                DatosPJ pjPrincipal = Functions_Datos.CargarPJ();
                var pjRival = Functions_Datos.DeserializarDatos(personajesJSON);
                Console.Clear();

                System.Console.WriteLine("1) Luchar!\n2) Mostrar Ganadores");
                op = Convert.ToInt32(Console.ReadLine());

                if(!(op == 1 || op == 2 )){
                    System.Console.WriteLine("Opción incorrecta, vuelve a escribir una opción correcta!");
                }
                else{
                    if(op == 1){
                        if(Functions_Fight.Luchar(pjPrincipal,pjRival) == true){
                            System.Console.WriteLine("Ganador! {0}",pjPrincipal.Data.Nombre);
                            listaGanadores.Add(pjPrincipal);
                        }else{
                            System.Console.WriteLine("GAME OVER");
                        }
=======
        string personajesJSON = Directory.GetCurrentDirectory()+@"/personaje.json";
        string ganaodoresJSON = Directory.GetCurrentDirectory()+@"/ganadores.json";
        var listGanadores = new List<DatosPJ>();

        var r = new Random();
        var rr = new Random();
        int op = 0;

        ConsoleKeyInfo cki;
        do{
            System.Console.WriteLine("Cargando...");
            //si el archivo no existe, lo crea y tambien evita que se
            // creen muchos personajes durante el ciclo, asi reduzco el tiempo de carga
            // para las proximas peleas.
            if(File.Exists(personajesJSON) == false){
                Functions_Datos.CrearEnemigos();
            }
            var principal = Functions_Datos.CargarPJ();
            // si la lista de rivales se va agotando, creo nuevos rivales mientras el archivo exista
            var rivales = Functions_Datos.DeserializarDatos(personajesJSON);
            if(File.Exists(personajesJSON) == true && rivales.Count < 6){
                Functions_Datos.CrearEnemigos();
            }
            Console.Clear();
            System.Console.WriteLine("1) LUCHAR!\n2) MOSTRAR GANADORES\n");
            op = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if(!(op == 1 || op == 2)){System.Console.WriteLine("Elija una opción correcta");}
            if(op == 1){
                int ganador = 0;
                for(int i = 0; i < 5; i++){
                    //los rivales son aleatorios, me aseguro de que no se repitan
                    // o que no aparezca un numero de index que no exista
                    int key= 1;
                    while(key == rivales[r.Next(1,rivales.Count)].Id){
                        key = r.Next(1,99);
>>>>>>> prueba1
                    }
                    System.Console.WriteLine("PELEA {0}\n{1} VS {2}\n",i+1,principal.Data.Nombre,rivales[key].Data.Nombre);
                    //si el personaje principal pierde, el juego se detiene
                    if(Functions_Fight.Luchar(principal,rivales[key]) != true){
                        System.Console.WriteLine("GAME OVER");
                        break;
                    }
<<<<<<< HEAD
                    Functions_Datos.EscribirEnJSON(listaGanadores,ganaodoresJSON);
                    System.Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }while((op == 1 || op == 2));
            /* cki = Console.ReadKey();
        }while(cki.Key != ConsoleKey.Escape); */
=======
                    //si no se cumple la condicion anterior, el pj principal ganó y 
                    //remueve el rival que perdió
                    rivales.RemoveAt(key);
                    Functions_Datos.EscribirEnJSON(rivales,personajesJSON);
                    principal.Stats.Salud = 1000;
                    principal.Stats.Fuerza += 1;
                    ganador++;
                }
                //para controlar que el principal haya ganado todas las batallas
                //pongo un contador, que si es mayor que 4, gana y se guarda en la lista de ganadores
                if(ganador > 4){
                    System.Console.WriteLine("{0} Gana!", principal.Data.Nombre);
                    if(File.Exists(ganaodoresJSON) == false){
                        listGanadores.Add(principal);
                        Functions_Datos.EscribirEnJSON(listGanadores,ganaodoresJSON);
                    }
                    //si ya existe una lista, entonces deserialiso los datos en una lista
                    //y agrego los nuevos ganadores
                    listGanadores = Functions_Datos.DeserializarDatos(ganaodoresJSON);
                    listGanadores.Add(principal);
                    Functions_Datos.EscribirEnJSON(listGanadores,ganaodoresJSON);
                }
            }
            if(op == 2){
                if(File.Exists(ganaodoresJSON) == false){
                    System.Console.WriteLine("Aun no hay ganadores...");
                }
                listGanadores = Functions_Datos.DeserializarDatos(ganaodoresJSON);
                foreach(var ganadores in listGanadores){
                    Functions_Datos.MostarDatos(ganadores);
                }
            }
            System.Console.WriteLine("Presione ENTER para continuar...");
            cki = Console.ReadKey();
            /* Console.ReadKey(); */
            Console.Clear();
        }while(op == 2 || op == 1 || cki.Key != ConsoleKey.Escape);
>>>>>>> prueba1
    }
}