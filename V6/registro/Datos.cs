using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace registro
{
    public class Datos{

        public int DataSaved = 0;
        public string Id { get;}
        public string Name {get;}
        public string LastName {get;}
        public string FullName => $"{Name} {LastName}";
        public decimal Savings {get;}
        public string Password {get;}
        public string ConfirmPassword {get;}
        public int YearsOld => (DataSaved >> 4);
        public Gender Gender => (Gender)(DataSaved & 0b1000);
        public Degree Degree => (Degree)(DataSaved & 0b11);
        public CivilStatus CivilStatus => (CivilStatus)(DataSaved & 0b100);
        public static List<Datos> persons = new List<Datos>();
        public Datos(in string id){

            Id = id;

        }

        public Datos(in string id, in string name, in string lastName, in decimal savings, in string password, in int yearsOld,
                     in Gender gender, in Degree degree, in CivilStatus civilStatus){

            Id = id;
            Name = name;
            LastName = lastName;
            Savings = savings;
            Password = password;
            DataSaved = (yearsOld << 4) | (int)gender | (int)degree | (int)civilStatus;

        }

        public override string ToString()
            => $"{GetType().Name}({nameof(Id)}: {Id}; {nameof(FullName)}: {FullName}; {nameof(Savings)}: {Savings}; {nameof(Password)}: {Password}; {nameof(YearsOld)}: {YearsOld}; {nameof(Gender)}: {Gender}; {nameof(Degree)}: {Degree}; {nameof(CivilStatus)}: {CivilStatus}; )";

        public bool Equals(object obj){

            if (obj is Datos same)
            {

                return Id.Equals(same.Id);
                
            }

            return false;

        }
        internal static Datos FromCsvLine(string line){
            
            string[] tokens = line.Split(',');
                (string id, string name, string lastName, decimal savings, string password, int packedData)
                = (tokens[0], tokens[1], tokens[2], decimal.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]));

                int yearsOld = (packedData >> 4);
                Gender gender = (Gender)(packedData & 0b1000);
                Degree degree = (Degree)(packedData & 0b11);
                CivilStatus civilStatus = (CivilStatus)(packedData & 0b100);

            return new Datos(id, name, lastName, savings, password, yearsOld, gender, degree, civilStatus);

        }

        internal static Datos ConsoleData(string save){

            string[] tokens = save.Split(',');
                (string id, string name, string lastName, decimal savings, string password, int yearsOld, Gender gender, 
                Degree degree, CivilStatus civil) = (tokens[0], tokens[1], tokens[2], decimal.Parse(tokens[3]), 
                tokens[4], int.Parse(tokens[5]), (Gender)int.Parse(tokens[6]), (Degree)int.Parse(tokens[7]), 
                (CivilStatus)int.Parse(tokens[8]));

            return new Datos(id, name, lastName, savings, password, yearsOld, gender, degree, civil);

        }

        internal static Datos GetAPerson(string id){

            Datos searchFor = new Datos(id);
            return persons?.Where(ia => searchFor.Equals(ia)).SingleOrDefault();

        }

        internal string InsertingData(){

            try
            {
                
                if(persons.Contains(this)){

                    return "Este ID ya Existe!!";

                }else{

                    persons.Add(this);
                    return "Persona agregada";
                    
                }

            }
            catch (System.Exception)
            {
                
                throw;
            }

        }

        internal string UpdatingPerson(){

            try
            {
                
                var per = persons.FindIndex(x => x.Equals(this));
                persons[per] = this;
                return "Persona Editada Exitosamente";

            }
            catch (System.Exception)
            {
                
                throw;
            }

        }

        internal string DeleteFromCsv(string id){

            try
            {
                
                Datos searchFor = new Datos(id);
                persons.RemoveAll(x => x.Equals(x));
                return "Persona Eliminada";

            }
            catch (System.Exception)
            {
                
                throw;
            }

        }

        internal static void SavingData(){

            if(persons.Count() > 0){

                File.WriteAllText(Program.file, "ID,Name,LastName,Savings,Password,Bits");
                foreach (var item in Datos.persons)
                {

                    File.AppendAllText(Program.file, $"{Environment.NewLine}{item.Id},{item.Name},{item.LastName},{item.Savings},{item.Password},{item.DataSaved}");
                    
                }
            }

        }

    }

    public enum Gender
    {

        Male = 0,
        Female = 8
        
    }
    public enum Degree
    {

        Initial = 0,
        Media = 1,
        Grade = 2,
        PostGrade = 3
        
    }
    public enum CivilStatus
    {

        Single = 0,
        Married = 4
        
    }

}