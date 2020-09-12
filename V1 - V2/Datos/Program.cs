using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool next = true;
            bool next1 = true;
            string data = "";
            var csv = new StringBuilder();
            people peo = new people();

            while (next1)
            {
              
              Console.Clear();
              Console.WriteLine("Digite A Para agregar datos");
              Console.WriteLine("Digite B Buscar Datos");
              Console.WriteLine("Digite V Para Ver Datos");
              Console.WriteLine("Digite S Para Salir del Programa \n");
              
              Console.Write("Digite una opcion: ");
              data = Console.ReadLine();
              switch (data)
              {
                  
                  case "a":

                  while (next){

                        Console.Clear();

                        Console.WriteLine(" Guardar Datos V1.0.0  \n");

                        Console.Write("Digite una cedula: ");
                        peo.id = Console.ReadLine();
                        Console.Write("Digite un nombre: ");
                        peo.name = Console.ReadLine();
                        Console.Write("Digite un o los apellidos: ");
                        peo.lastName = Console.ReadLine();
                        Console.Write("Digite una edad: ");
                        peo.yearsOld = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        Console.WriteLine("Digite una opcion: G - Guardar | C - Continuar | S - Salir del Programa");
                        data = Console.ReadLine();

                        switch (data)
                        {
                            case "g":

                                string filePath = args[0];
                                var newLine = string.Format("{0}, {1}, {2}, {3}", peo.id, peo.name, peo.lastName, peo.yearsOld);
                                csv.AppendLine(newLine);
                                File.AppendAllText(filePath, csv.ToString());

                            break;

                            case "c":

                            break;

                            case "s":

                                next = false;                       

                            break;

                            default:

                            Console.WriteLine("\n Se ha digitado una opcion no valida, favor digitar algo valido");
                            Console.ReadKey();

                            break;
                        }

                
                    }

                  break;

                  case "b":

                    Console.Clear();

                    var filePathSearch = File.ReadAllLines(args[0]);
                    string idSearch = "";

                    Console.WriteLine("Listado de Personas \n");

                    var searchingID = from dataShow in filePathSearch
                                let datos = dataShow.Split(',')
                                select new{

                                    id = datos[0],
                                    Name = datos[1],
                                    lastName = datos[2],
                                    yearsO = datos[3]
                                };
                    
                    Console.Write("Digite una cedula: ");
                    idSearch = Console.ReadLine();

                    foreach (var item in searchingID)
                    {

                        if(idSearch == item.id){

                        Console.WriteLine("{0} \t\t {1} \t\t {2} \t\t {3}", item.id, item.Name, item.lastName, item.yearsO);
                        
                        } 
                        
                    }

                    Console.ReadKey();

                  break;

                  case "v":

                    Console.Clear();

                    var filePathSee = File.ReadAllLines(args[0]);

                    Console.WriteLine("Listado de Personas \n");

                    var showPeople = from dataShow in filePathSee
                                let datos = dataShow.Split(',')
                                select new{

                                    id = datos[0],
                                    Name = datos[1],
                                    lastName = datos[2],
                                    yearsO = datos[3]
                                };
                    
                    Console.WriteLine("Cedula \t\t Nombre \t\t Apellido \t\t Edad");

                    foreach (var per in showPeople)
                    {

                        Console.WriteLine("{0} \t\t {1} \t\t {2} \t\t {3}", per.id, per.Name, per.lastName, per.yearsO);
                        
                    }

                    Console.ReadKey();

                  break;

                  case "s":

                    next1 = false;

                  break;

                  default:

                  Console.WriteLine("\n Se ha digitado una opcion no valida, favor digitar algo valido");
                  Console.ReadKey();

                  break;
              }  

            }


        }
    }
}
