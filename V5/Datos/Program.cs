using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

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
              Console.WriteLine("Digite a Para agregar datos");
              Console.WriteLine("Digite b Buscar Datos");
              Console.WriteLine("Digite v Para Ver Datos");
              Console.WriteLine("Digite e Editar Datos");
              Console.WriteLine("Digite d Eliminar Datos");
              Console.WriteLine("Digite s Para Salir del Programa \n");
              
              Console.Write("Digite una opcion: ");
              data = Console.ReadLine();
              switch (data)
              {
                  
                  case "a":

                  while (next){

                        Console.Clear();

                        Console.WriteLine(" Guardar Datos V4.0.0  \n");

                        Console.Write("Digite una cedula: ");
                        peo.id = int.Parse(yearsOld());
                        Console.Write("\nDigite un nombre: ");
                        peo.name = Console.ReadLine();
                        Console.Write("Digite un o los apellidos: ");
                        peo.lastName = Console.ReadLine();
                        
                        try
                        {

                            NumberFormatInfo justTwo = new NumberFormatInfo();
                            justTwo.NumberDecimalDigits = 2;

                            Console.Write("\nAhorros: ");
                            peo.savings = decimal.Parse(personSavings());
                            
                        }catch (Exception e){
                            
                            Console.WriteLine(e.Message);
                            
                        }

                        Console.WriteLine();
                        peo.packedData = code();

                        password:
                        Console.Write("\nDigite una contraseña: ");
                        peo.password = personPassword();
                        Console.Write("Confirme la contraseña: ");
                        peo.confirmPassword = personPassword();

                        if(peo.password == peo.confirmPassword){
                            
                            Console.WriteLine("Digite una opcion: G - Guardar | C - Continuar | S - Salir del Programa");
                            data = Console.ReadLine();

                            switch (data)
                            {
                                case "g":

                                    string filePath = args[0];
                                    var newLine = string.Format("{0}, {1}, {2}, {3}, {4}, {5}", peo.id, peo.name, peo.lastName, peo.savings, peo.packedData, peo.password);
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

                        }else
                        {

                            System.Console.WriteLine("Las contraseñas no coinciden!!");
                            goto password;
                            
                        }
                        

                        Console.WriteLine("");

                        

                
                    }

                  break;

                  case "b":

                    Console.Clear();

                    var filePathSearch = File.ReadLines(args[0]);
                    string idSearch = "";

                    Console.WriteLine("Buscar por Cedula \n");

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
                        
                        } else
                        {
                            Console.WriteLine("Esta cedula no esta en el archivo!!");
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

                  case "e":
                    
                    Console.Clear();
                    Console.WriteLine("Editar Datos \n");

                    String pathEdit = args[0];
                    List<String> lines = new List<String>();

                    string read = "";
                    Console.Write("Digite la cedula para editar: ");
                    read = Console.ReadLine();

                    if(File.Exists(pathEdit)){
                        
                        using(StreamReader reader = new StreamReader(pathEdit)){

                            String line;

                            while((line = reader.ReadLine()) != null){

                                if(line.Contains(",")){
                                    
                                    String[] split = line.Split(',');

                                    if(split[0].Contains(read)){

                                        Console.Write("Digite su Nombre: ");
                                        peo.name = Console.ReadLine();
                                        Console.Write("Digite su Apellido: ");
                                        peo.lastName = Console.ReadLine();
                                        Console.Write("Digite su Edad: ");
                                        //peo.yearsOld = Console.ReadLine();

                                        split[1] = peo.name;
                                        split[2] = peo.lastName;
                                        //split[3] = peo.yearsOld;
                                        line = String.Join(",",split);

                                    }

                                }

                                lines.Add(line);

                            }

                        }

                        using (StreamWriter writer = new StreamWriter(pathEdit, false))
                        {
                            
                            foreach (var line in lines)
                            {
                                
                                writer.WriteLine(line);

                            }

                        }

                    }


                  break;

                  case "d":

                    Console.Clear();

                    Console.WriteLine("Eliminar por Cedula \n");

                    String pathDelete = args[0];
                    List<String> linesDelete = new List<String>();

                    int deleteAt = 0;
                    Console.Write("Digite la posicion que desee eliminar: ");
                    deleteAt = Int32.Parse(Console.ReadLine());

                    linesDelete = File.ReadAllLines(pathDelete).ToList();
                    linesDelete.RemoveAt(deleteAt);
                    File.WriteAllLines((pathDelete), linesDelete.ToArray());


                  break;

                  case "s":

                    Console.Clear();
                    next1 = false;

                  break;

                  default:

                  Console.WriteLine("\n Se ha digitado una opcion no valida, favor digitar algo valido");
                  Console.ReadKey();

                  break;
              }  

            }


        }

        static string yearsOld(){

            char[] quantities = new char[32];

            char q;

            for (int i = 0;;)
            {
                q = Console.ReadKey(true).KeyChar;
                
                if (q >= 48 && q <= 57){

                    quantities[i] = q;
                    ++i;
                    Console.Write(q);
                    
                }
                if (q == 13){
                    
                    quantities[i] = '\0';
                    break;

                }
                if (q == 8  && i >= 1){
                    
                    Console.Write("\b \b");
                    --i;

                }

            }

            return new string (quantities);

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

        public static int code(){

            int savedData = 0;

            Console.Write("Digite su edad: ");
            byte age = Convert.ToByte(Console.ReadLine());

            Console.Write("Digite su Sexo (M/F): ");
            string sex = Console.ReadLine();

            Console.Write("Digite su Grado Academico (I|M|G|P): ");
            string degree = Console.ReadLine();

            Console.Write("Digite su Estado Civil (S - Soltero / C - Casado): ");
            string civilStatus = Console.ReadLine();

            savedData = savedData | age;
            savedData = savedData << 4;

            if(sex == "F"){

                savedData = savedData | 8;

            }

            switch (degree)
            {
                
                case "I":

                    savedData = savedData | 0;

                break;

                case "M":

                    savedData = savedData | 1;

                break;

                case "G":

                    savedData = savedData | 2;

                break;

                case "P":

                    savedData = savedData | 3;

                break;
                
            }

            if(civilStatus == "C"){

                savedData = savedData | 4;

            }

            return savedData;

        }

        public static void decode(int savedData){

            string sex, degree, civilStatus;
            int age, decoding = savedData & 3;

            if ((savedData | 8) == savedData)
            {

                sex = "Female";
                
            }else{

                sex = "Male";

            }

            switch (decoding)
            {
                
                case 0:

                    degree = "Inicial";

                break;

                case 1:

                    degree = "Media";

                break;

                case 3:

                    degree = "Grado";

                break;

                default:

                    degree = "Post-Grado";

                break;
                
            }

            if((savedData | 4) == savedData){
                
                civilStatus = "Casado";

            }else
            {
                
                civilStatus = "Soltero";

            }

            age = (int)(savedData >> 4);

            Console.Write($"{age}, {sex}, {degree}, {civilStatus}");

        }

    }
}
