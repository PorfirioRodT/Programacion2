using System;
using System.Globalization;

class Program{

    public static void Main(string[] args){

        Console.Clear();

        Console.Write("Nombre: ");
        string name = personName();
        Console.WriteLine("\nEl nombre digitado fue: "+name);

        Console.Write("\nApellido: ");
        string apellido = personName();
        Console.WriteLine("\nEl apellido digitado fue: "+apellido);

        Console.Write("\nEdad: ");
        string edad = yearsOld();
        Console.WriteLine("\nLa edad digitada fue: "+edad);

        try{
            
            NumberFormatInfo justTwo = new NumberFormatInfo();
            justTwo.NumberDecimalDigits = 2;

            Console.Write("\nAhorros: ");
            decimal ahorros = decimal.Parse(personSavings());
            Console.WriteLine("");
            Console.WriteLine(ahorros.ToString("N",justTwo));

        }
        catch (Exception e)
        {
            
            Console.WriteLine(e.Message);
            
        }
        

        Console.Write("\nPassword: ");
        string password = personPassword();

        Console.Write("\nPassword Confirm: ");
        string passwordConfirm = personPassword();

        if(password == passwordConfirm){

            Console.WriteLine("\nLas contraseñas son iguales");

        }else{

            Console.WriteLine("\nLas contraseñas no son iguales");

        }



    }

    static string personName(){

        char[] quantity = new char[48];
        char q;

        for (int i = 0;;){

            q = Console.ReadKey(true).KeyChar;

            if (q >= 65 && q <= 90 || q >= 97 && q <= 122 || q >= 48 && q <= 57){

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

    static string yearsOld(){

        char[] quantity = new char[48];

        char q;

        for (int i = 0;;){

            q = Console.ReadKey(true).KeyChar;

            if (q >= 48 && q <= 57)
            {
                quantity[i] = q;
                ++i;
                Console.Write(q);
                
            }
            if (q == 13){

                quantity[i] ='\0';
                break;
                
            }
            if (q == 8 && i >= 1){

                Console.Write("\b \b");
                --i;

                
            }
            
        }

        return new string (quantity);

    }

        static string personSavings(){

        char[] quantity = new char[48];

        char q;

        for (int i = 0;;){

            q = Console.ReadKey(true).KeyChar;

            if (q >= 48 && q <= 57 || q == 46)
            {
                quantity[i] = q;
                ++i;
                Console.Write(q);
                
            }
            if (q == 13){

                quantity[i] ='\0';
                break;
                
            }
            if (q == 8 && i >= 1){

                Console.Write("\b \b");
                --i;

                
            }
            
        }

        return new string (quantity);

    }

        //Password
        static string personPassword(){

        char[] quantity = new char[48];
        char q;

        for (int i = 0;;){

            q = Console.ReadKey(true).KeyChar;

            if (q >= 65 && q <= 90 || q >= 97 && q <= 122 || q >= 48 && q <= 57 || q >= 42 && q <= 46){

                quantity[i] = q;
                ++i;
                Console.Write("*");
                
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