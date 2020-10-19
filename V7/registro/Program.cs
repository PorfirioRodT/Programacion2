using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace registro
{
    class Program
    {
        public static string file;
        static void Main(string[] args)
        {  

           if(args.Length == 1){

               file = $@"{args[0]}";

               if(!File.Exists(file)){

                   File.Create(file).Close();
                   File.WriteAllText(file,"ID,Name,LastName,Savings,Password,Bits");

               }  else
               {
                   
                   var list = GettingData();

                   foreach (var item in list)
                   {

                       if (list.IndexOf(item) > 0)
                       {

                           var people = Datos.FromCsvLine(item);
                           Datos.persons.Add(people);
                           
                       }
                       
                   }

               }

            }

           
           bool next= true;
           string data = "";

           while(next){
               Console.Clear();

               Console.WriteLine("Bienvenido a la V6.0 \n");

               Console.WriteLine("A - Agregar Persona");
               Console.WriteLine("V - Ver Listado de Personas");
               Console.WriteLine("D - Eliminar");
               Console.WriteLine("B - Buscar por Cedula");
               Console.WriteLine("E - Editar por Cedula");
               Console.WriteLine("G - Guardar");
               Console.WriteLine("S - Salir \n");

               Console.Write("Digite una opcion: ");
               
               data = Console.ReadLine().ToLower();

               switch (data)
               {
                   case "a":
                   
                    Console.Clear();
                    
                    var people = Datos.ConsoleData(Information());
                    Console.WriteLine(people.InsertingData());

                    Console.ReadKey();

                   break;

                   case "v":

                    Console.Clear();
                    ShowData();

                   break;

                   case "b":

                    Console.Clear();
                    Console.WriteLine("Buscar por Cedula \n"); 

                    Search();

                            
                   break;

                   case "d":

                    Delete();
                    Console.ReadKey();
 
                   break;

                   case "e":

                    Edit();
                    Console.ReadKey();

                   break;

                   case "g":

                    Datos.SavingData();

                   break;

                   case "s":

                    Console.Clear();
                    next = false;

                   break;

                   default:

                    Console.WriteLine(data + " no es una opcion valida");
                    Console.ReadKey();

                   break; 

                }
               
            }

        }

        public static List<string> GettingData(){

            string[] data = File.ReadAllLines(file);
            List<string> list = new List<string>();

            for (int i = 0; i < data.Length; i++)
            {

                list.Add(data[i]);
                
            }

            return list;

        }

        public static string Information(string id = null){

            Console.Clear();

            bool real = false;
            string ced;

            Console.WriteLine("Capturar Datos \n");

            if (id == null)
            {

                Console.Write("Digite su Cedula: ");
                ced = yearsOldC(32);
                
            }else
                ced = id;

            Console.Write("\nDigite su Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Digite su Apellido: ");
            string lastName = Console.ReadLine();                           
            Console.Write("Ahorros: ");
            decimal savings = decimal.Parse(personSavings());

            string pass, confirmPass;
            do
            {

            Console.Write("\nDigite Password: ");
            pass = personPassword();
            Console.Write("Confirme el Password: ");
            confirmPass = personPassword();                  
                
            } while (string.IsNullOrEmpty(pass) || !(pass.Equals(confirmPass)));
            
            int yearsOld;
            do
            {
                
                Console.Write("Digite su Edad: ");
                yearsOld = int.Parse(yearsOldC(32));

            } while (yearsOld < 7 || yearsOld > 120);

            int sex = 0;
            do
            {

                real = true;
                Console.Write("\nDigite su Sexo (M/F): ");
                switch (Console.ReadLine().ToUpper())
                {
                    case "F":

                        sex = 8;

                    break;

                    case "M":

                        sex = 0;

                    break;

                    default:

                        real = false;

                    break;

                }
                
            } while (!real);

            int degree = 0;
            do
            {

                real = true;
                Console.Write("Digite su Grado Academico (I|M|G|P): ");
                switch (Console.ReadLine().ToUpper())
                {
                    case "I":

                        degree = 0;

                    break;

                    case "M":

                        degree = 1;

                    break;

                    case "G":

                        degree = 2;

                    break;

                    case "P":

                        degree = 3;

                    break;

                    default:

                        real = false;

                    break;

                }
                
            } while (!real);

            int civilStatus = 0;
            do
            {

                real = true;
                Console.Write("Digite su Estado Civil (S - Soltero / C - Casado): ");
                switch (Console.ReadLine().ToUpper())
                {
                    case "C":

                        sex = 4;

                    break;

                    case "S":

                        sex = 0;

                    break;

                    default:

                        real = false;

                    break;

                }
                
            } while (!real);
            Console.WriteLine();

            return $"{ced},{name},{lastName},{savings},{pass},{yearsOld},{sex},{degree},{civilStatus}";

        }

        public static void Search(){

            Console.Clear();

            Console.Write("Enter the id: ");
            string id = yearsOldC(32);

            Console.WriteLine("\n");
            
            var per = Datos.GetAPerson(id)?.ToString();
            if (per == null)
            {

                Console.WriteLine("No se ha encontrado esta persona!!");
                
            }else{

                Console.WriteLine(per.ToString());
                
            }

            Console.ReadKey();  

        }
        public static void Edit(){

            Console.Clear();
            Console.WriteLine("Editar por Cedula\n");

            Console.Write("Digite una Cedula: ");
            string id = yearsOldC(32);
            Console.WriteLine();

            var per = Datos.GetAPerson(id);

            if (per == null)
            {

                Console.WriteLine("No se ha encontrado este ID!!");
                
            } else {

                Console.WriteLine(per.ToString());
                per = Datos.FromCsvLine(Information(id));
                Console.WriteLine(per.UpdatingPerson());

            }

        }

        public static void ShowData(){

            Console.WriteLine("Listado de Personas \n");

                foreach (var item in Datos.persons)
                {

                     Console.WriteLine(item.ToString());
                        
                }

            Console.ReadKey();

        }

        public static void Delete(){

            Console.Clear();
            Console.WriteLine("Eliminar por Cedula\n");

            Console.Write("Digite una Cedula: ");
            string id = yearsOldC(32);
            Console.WriteLine();
            
            var per = Datos.GetAPerson(id);

            if (per == null)
            {

                Console.WriteLine("No se ha encontrado este ID!!");
                
            } else {

                Console.WriteLine(per.ToString());
                Console.WriteLine(per.DeleteFromCsv(id));

            }
            

        }

        static string yearsOldC(int quantity){

            string numbers = "";

            ConsoleKeyInfo keyInfo;

            do
            {

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Backspace && numbers.Length < quantity)
                {

                    double value = 0;
                    bool keyValue = double.TryParse(keyInfo.KeyChar.ToString(), out value);

                    if (keyValue)
                    {

                        numbers += keyInfo.KeyChar;
                        Console.Write(keyInfo.KeyChar);
                        
                    }
                    
                } else{

                    if (keyInfo.Key ==  ConsoleKey.Backspace && numbers.Length > 0)
                    {

                        numbers = numbers.Substring(0, (numbers.Length - 1));
                        Console.Write("\b \b");
                        
                    }
                    
                }
                
            } while (keyInfo.Key != ConsoleKey.Enter);

            return numbers;

        }

        static string personPassword(){

            string password = "";
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            while (pressedKey.Key != ConsoleKey.Enter){

                if (pressedKey.Key != ConsoleKey.Backspace){

                    Console.Write("*");
                    password += pressedKey.KeyChar;

                }else{

                    if (password.Length > 0){

                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");

                    }

                }

                pressedKey = Console.ReadKey(true);
               
            }

            Console.WriteLine();
            return password;

        }

        static string personSavings(){

                char[] quantity = new char[32];

                char q;

                for (int i = 0;;)
                {
                    
                    q = Console.ReadKey(true).KeyChar;

                    if (q >= 48  && q <= 57 || q == 46){
                        
                        quantity[i] = q;
                        ++i;
                        Console.Write(q);
                        
                    }
                    if (q == 13){

                        quantity[i] = '\0';
                        break;
                        
                    }
                    if (q == 8 && i >= 1){
                        
                        Console.Write("\b \b");
                        --i;

                    }

                }

            return new string (quantity);

        }


    }
    
}
