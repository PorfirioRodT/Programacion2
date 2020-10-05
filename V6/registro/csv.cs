using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class CSV{

    public List<Datos> datos; 
    public string file; 
    public CSV (string file){
        
        datos = new List <Datos>();
        this.file = file;
    
    }
    public void addPerson(int id, string name, string lastName, decimal savings, int dataSaved, string password){

        Datos person = new Datos(id, name, lastName, savings, dataSaved, password);
        datos.Add(person);

    }

    public void Save() {

        using (StreamWriter sw = new StreamWriter(file)){

            sw.WriteLine("ID, Name, Last Name, Ahorros, Bits, Password");
            foreach (Datos data in datos)
            {
                        
                string [] values = {data.Id.ToString(), data.Name, data.LastName, data.Savings.ToString(), data.DataSaved.ToString(), data.Password};
                string line = string.Join(",", values);
                sw.WriteLine(line); 
                    
            }

            sw.Flush();

        }

    }
            
    public void See(){

        var lines = File.ReadLines(file);

        foreach (var line in lines){

            Console.WriteLine(line);

        }
    } 

    public void searchById(string search){

        var lines = File.ReadLines(file);

        foreach(var line in lines){

            if (line.Split(',')[0].Contains(search)) {

                Console.WriteLine(line);
                    
            } else {

                Console.WriteLine("Esta cedula no Existe!!");

            }

        }

    }

    public void Edit(string read){

        List<String> lines = new List<String>();

        if(File.Exists(file)){
                        
            using(StreamReader reader = new StreamReader(file)){

                String line;

                while((line = reader.ReadLine()) != null){

                    if(line.Contains(",")){
                                    
                        String[] split = line.Split(',');

                        if(split[0].Contains(read)){

                            Console.Write("Digite su Nombre: ");
                            var name = Console.ReadLine();
                            Console.Write("Digite su Apellido: ");
                            var lastName = Console.ReadLine();
                            Console.Write("Digite su Ahorros: ");
                            var savings = Console.ReadLine();
                            int bits = code();

                            split[1] = name;
                            split[2] = lastName;
                            split[3] = savings;
                            split[4] = bits.ToString();
                            line = String.Join(",",split);

                        }

                    }

                    lines.Add(line);

                }

            }

            using (StreamWriter writer = new StreamWriter(file, false)){
                            
                foreach (var line in lines){
                                
                    writer.WriteLine(line);

                }

            }

        }

    }

    public void Delete(int deleteAt){

        List<String> linesDelete = new List<String>();
                            
        linesDelete = File.ReadAllLines(file).ToList();
        linesDelete.RemoveAt(deleteAt);
        File.WriteAllLines((file), linesDelete.ToArray());      

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

        switch (degree){
                
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