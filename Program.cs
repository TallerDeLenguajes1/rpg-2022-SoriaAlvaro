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
                    }
                
                    if(op == 2){
                        var mostrarGanadores = Functions_Datos.DeserializarDatos(ganaodoresJSON);
                        if(mostrarGanadores.Count <= 0){
                            System.Console.WriteLine("Aun no hay ganadores");
                        }else{
                            foreach(var pj in mostrarGanadores){
                                Functions_Datos.MostarDatos(pj);
                            }
                        }
                    }
                    Functions_Datos.EscribirEnJSON(listaGanadores,ganaodoresJSON);
                    System.Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }while((op == 1 || op == 2));
            /* cki = Console.ReadKey();
        }while(cki.Key != ConsoleKey.Escape); */
    }
}