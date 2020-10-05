using System;

namespace registro
{
    class Program
    {
        static void Main(string[] args)
        {       
            
           bool next= true, next1 = true;
           string data = "";
           CSV csv = new CSV(args[0]);

           while(next){
               Console.Clear();

               Console.WriteLine("Bienvenido a la V6.0 \n");

               Console.WriteLine("A - Agregar Persona");
               Console.WriteLine("V - Ver Listado de Personas");
               Console.WriteLine("D - Eliminar");
               Console.WriteLine("B - Buscar por Cedula");
               Console.WriteLine("E - Editar por Cedula");
               Console.WriteLine("S - Salir \n");

               Console.Write("Digite una opcion: ");
               
               data = Console.ReadLine().ToLower();

               switch (data)
               {
                   case "a":
                   
                        while (next1)
                        {
                            
                            Console.Clear();

                            Console.WriteLine("Capturar Datos \n");

                            Console.Write("Digite su Cedula: ");
                            var ced = yearsOld();
                            Console.Write("\nDigite su Nombre: ");
                            var name = Console.ReadLine();
                            Console.Write("Digite su Apellido: ");
                            var lastName = Console.ReadLine();
                            
                            Console.Write("Ahorros: ");
                            decimal savings = decimal.Parse(personSavings());

                            Console.WriteLine();
                            int coding = code();

                            passwords:
                            Console.Write("Digite Password: ");
                            var pass = personPassword();
                            Console.Write("Confirme el Password: ");
                            var confirmPass = personPassword();

                            if(pass == confirmPass){

                                csv.addPerson(Convert.ToInt32(ced), name, lastName, savings, coding, pass);
                                csv.Save();
                                
                            }else{

                                Console.WriteLine("\nLas contraseñas no son iguales");
                                goto passwords;
                                
                            }

                        }

                   break;

                   case "v":

                    Console.Clear();
                    Console.WriteLine("Listado de Personas \n");

                    csv.See();
                    Console.ReadKey();

                   break;

                   case "b":

                    Console.Clear();
                    Console.WriteLine("Buscar por Cedula \n"); 

                    System.Console.Write("Digite una Cedula: ");
                    csv.searchById(Console.ReadLine());                                      
                            
                   break;

                   case "d":

                    Console.Clear();       
                    Console.WriteLine("Eliminar por posicion \n");

                    Console.Write("Digite una posicion: ");
                    csv.Delete(Int32.Parse(Console.ReadLine()));
 
                   break;

                   case "e":

                    Console.Clear();
                    Console.WriteLine("Editar por Cedula\n");

                    Console.Write("Digite una Cedula: ");
                    csv.Edit(Console.ReadLine());

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

    }
    
}
