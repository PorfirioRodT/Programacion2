using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace programa
{
    class Program
    {
        static void Main(string[] args)
        {
            
           bool next= true, next1 = true;
           string data = "";

           //peopleManagement peoMng = new peopleManagement();

           while(next){
               Console.Clear();

               Console.WriteLine(" Bienvenido a la V1.0 \n");

               Console.WriteLine("A - Agregar Persona");
               Console.WriteLine("V - Ver Listado de Personas");
               Console.WriteLine("S - Salir");

               Console.Write("Digite una opcion: ");
               
               data = Console.ReadLine();

               switch (data)
               {
                   case "a":
                   
                        while (next1)
                        {
                            
                            var csv = new StringBuilder();
                            people peo = new people();
                            Console.Clear();

                            Console.WriteLine(" Capturar Datos ");

                            Console.Write(" Digite su Cedula: ");
                            peo.id = Console.ReadLine();
                            Console.Write(" Digite su Nombre: ");
                            peo.name = Console.ReadLine();
                            Console.Write(" Digite su Apellido: ");
                            peo.lastName = Console.ReadLine();
                            Console.Write(" Digite su Edad: ");
                            peo.yearsOld = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("G - Guardar | S - Salir | C - Continuar");

                            Console.Write("Digite una opcion: ");              
                            data = Console.ReadLine();

                            switch (data)
                            {
                                 
                                case "g":

                                    string filepath = args[0];
                                    var newLine = string.Format("{0},{1},{2},{3}", peo.id, peo.name, peo.lastName, peo.yearsOld);
                                    csv.AppendLine(newLine);
                                    File.AppendAllText(filepath, csv.ToString());

                                break;

                                case "s":

                                next1 = false;

                                break;

                                case "c":

                                break;
                                 
                                default:

                                    Console.WriteLine(data + " no es una opcion valida");
                                    Console.ReadKey();

                                break; 

                            }

                        }

                   break;

                   case "v":

                        /*Console.Clear();

                        Console.WriteLine(" Listado de Personas ");

                        List<people> all = peoMng.getPeople();

                        Console.WriteLine("Cedula \t\t Nombre \t\t Apellido \t\t Edad");

                        foreach (people person in all)
                        {
                            
                            Console.WriteLine("{0} \t\t {1} \t\t {2} \t\t {3}", person.id, person.name, person.lastName, person.yearsOld);

                        }

                        Console.ReadKey();*/

                   break;

                   case "s":

                            Console.WriteLine("Bye");
                            Console.ReadKey();
                            next = false;

                   break;

                   default:

                        Console.WriteLine(data + " no es una opcion valida");
                        Console.ReadKey();
                   break; 

               }
               
           }
           
        }

    }
}
