using System;
using DatosCharacter;
using Caractcharacter;
using Personajes;
static string RetornarNombre(string[][] personaje, int i){
  Random Rnd = new Random();
  int cantNom = personaje[i].Length;
  string nom = "";
  if(i == 0){
    nom = personaje[i][Rnd.Next(0,cantNom)];
  }
  if(i == 1){
    nom = personaje[i][Rnd.Next(0,cantNom)];
  }
  if(i == 2){
    nom = personaje[i][Rnd.Next(0,cantNom)];
  }
  return nom;
}
static Personaje retornarDat(string[][]nombres){
  Personaje pj = new Personaje();
  Random r = new Random();
  pj.Dat.Nombre = RetornarNombre(nombres,0);
  pj.Dat.Tipo = RetornarNombre(nombres,1);
  pj.Dat.Apodo = RetornarNombre(nombres,2);
  pj.Dat.Edad = r.Next(1,100);
  return pj;
}
static List<Personaje> retornarLista(string[][] nombres){
  List<Personaje> person = new List<Personaje>();
  for(int i = 0; i < 3; i++){
    person.Add(new Personaje());
    person[i] = retornarDat(nombres);
  }
  return person;
}
var nombres = new string[][]{
  new string[]{"Pibe Libertario","Viejo Inimputable", "Victoria","Jubilado armado","Sindicalista","El Brayan", "Piquetero", "Gordo del mortero","Zurdo","Inflación","Politico", "Javier","Mabel","Isabel","Cristina","Carla",},
  new string[]{"Francotirador","Ladrón","Cazarrecompensas","Embaucador","Salvaje","Ilusionista","Invocador","Sabio","Guerrero","Caballero","Mercenario","Ingeniero","Médium","Pistolero","Bombardero","Francotirador"},
  new string[]{"El Sucio", "Chorro", "Chino", "Forro", "Pubertario","ChocoBoy","El justiciero","el Pepe","eL Chino","Dogor","Falopa","Pibe Cantina", "Cabez de termo","Milipili","Tranza","vieja macrista"}
};
Random r = new Random();

Personaje pj1 = retornarDat(nombres);
List<Personaje> luchadores = retornarLista(nombres);
int caraCruz = r.Next(0,2);
for(int k = 0; k < luchadores.Count; k++){
  System.Console.WriteLine("\t\tPelea {0}\n\t\t{1} VS {2}\n",k+1,pj1.Dat.Nombre,luchadores[k].Dat.Nombre);
  for(int i = 0; i < 7; i++){
    System.Console.WriteLine("\tTurno {0}\n", i+1);
    if(pj1.Dat.Salud < 1){
      break;
    }
    if(luchadores[k].Dat.Salud < 1){
        luchadores.RemoveAt(k);
        break;
    }
    if(caraCruz == 0){
      System.Console.WriteLine("{0} ataca...",pj1.Dat.Nombre);
      pj1.danioProvoado(luchadores[k]);
      caraCruz = 1;
    }else{
      System.Console.WriteLine("{0} ataca...",luchadores[k].Dat.Nombre);
      luchadores[k].danioProvoado(pj1);
      caraCruz = 0;
    }
  }
  if(pj1.Dat.Salud < luchadores[k].Dat.Salud){
    System.Console.WriteLine("{0} derrotado, fin del juego.",pj1.Dat.Nombre);
    break;
  }else if(luchadores[k].Dat.Salud < pj1.Dat.Salud){
    System.Console.WriteLine("{0} derrotado",luchadores[k].Dat.Nombre);
    luchadores.RemoveAt(k);
  }
  System.Console.WriteLine("");
  Console.ReadKey();
  Console.Clear();
}