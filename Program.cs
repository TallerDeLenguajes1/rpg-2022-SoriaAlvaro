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
        string personajesJSON = @"/home/alvaro/Documentos/Taller/Pruebas/newClass/personajes/personaje.json";
        string ganaodoresJSON = @"/home/alvaro/Documentos/Taller/Pruebas/newClass/ganadores/ganadores.json";
        ConsoleKeyInfo cki;
        do{
            int op = 0;
            do{
                System.Console.WriteLine("1) Luchar!\n2) Mostrar Ganadores");
                op = Convert.ToInt32(Console.ReadLine());
                cki = Console.ReadKey();
                if(!(op == 1 || op == 2 )){
                    System.Console.WriteLine("Opción incorrecta, vuelve a escribir una opción correcta!");
                }
                else{
                    if(op == 1){
                        Functions_Datos.CrearEnemigos();
                        var listaGanadores = new List<DatosPJ>();
                        if(File.Exists(ganaodoresJSON)){
                            listaGanadores = Functions_Datos.DeserializarDatos(ganaodoresJSON);
                            listaGanadores.Add(Functions_Fight.LuchaYCargarGanadores(Functions_Datos.CargarPJ(),Functions_Datos.DeserializarDatos(personajesJSON)));
                        }else{
                            listaGanadores.Add(Functions_Fight.LuchaYCargarGanadores(Functions_Datos.CargarPJ(),Functions_Datos.DeserializarDatos(personajesJSON)));
                        }
                        if(listaGanadores != null){
                            Functions_Datos.EscribirEnJSON(listaGanadores,ganaodoresJSON);
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
                    System.Console.WriteLine("Presione ENTER para continuar...");
                }
            }while(!(op == 1 || op == 2));
            cki = Console.ReadKey();
        }while(cki.Key != ConsoleKey.Escape);
    }
}