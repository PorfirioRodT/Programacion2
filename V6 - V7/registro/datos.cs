using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace registro
{
    public class Datos{
        public string Id { get; }
        public string Name { get; }
        public string LastName { get; }
        public string FullName => $"{Name} {LastName}";
        public int YearsOld => (DataSaved >> 4);
        public Gender Gender => (Gender)(DataSaved & 0b1000);
        public Degree Degree => (Degree)(DataSaved & 0b11);
        public CivilStatus CivilStatus => (CivilStatus)(DataSaved & 0b100);
        public decimal Savings { get; }
        public string Password { get; set;}
        public string PasswordConfirm { get; }
        public int DataSaved = 0;
        public static List<Datos> persons = new List<Datos>();
        private Datos(in string id){

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
            => $"{GetType().Name}({nameof(Id)}: {Id}; {nameof(FullName)}: {FullName}; {nameof(Savings)}: {Savings}; {nameof(Password)}: {Password}; {nameof(YearsOld)}: {YearsOld}; {nameof(Gender)}: {Gender}; {nameof(Degree)}: {Degree}; {nameof(CivilStatus)}: {CivilStatus})";

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

        public override bool Equals(object obj)
        {
            
            if (obj is Datos same)
            {
                
                return Id.Equals(same.Id);

            }

            return false;
            
        }

        internal static Datos GetAPerson(string id){

            Datos searchFor = new Datos(id);
            return persons?.Where(a => searchFor.Equals(a)).SingleOrDefault();

        }

        internal static Datos ConsoleData(string save){

            var tokens = save.Split(',');
            (string id, string name, string lastName, decimal savings, string password, int yearsOld, Gender gender, 
                Degree degree, CivilStatus civilStatus) = (tokens[0], tokens[1], tokens[2], 
                decimal.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]), (Gender)int.Parse(tokens[6]), 
                (Degree)int.Parse(tokens[7]), (CivilStatus)int.Parse(tokens[8]));

            return new Datos(id, name, lastName, savings, password, yearsOld, gender, degree, civilStatus);     

        }

        internal string InsertingData(){

            try
            {

                if (persons.Contains(this))
                {
                    
                    return "Este ID ya existe";

                } else {

                    persons.Add(this);
                    return "Datos Guardados";

                }
                
            }
            catch (Exception e)
            {
                
                throw new ApplicationException("Error", e);
            }

        }

        internal string UpdatingPerson(){

            try
            {
                
                var per = persons.FindIndex(x => x.Equals(this));
                persons[per] = this;
                return "Persona Editada Correctamente";
                
            }
            catch (Exception e)
            {
                
                throw new ApplicationException("Error", e);
            }

        }

        internal string DeleteFromCsv(string id){

            try
            {
                
                Datos searchFor = new Datos(id);
                persons.RemoveAll(x => searchFor.Equals(x));
                return "Persona Eliminada";
                
            }
            catch (Exception e)
            {
                
                throw new ApplicationException("Error", e);
            }

        }

        internal static void SavingData(){

            if(persons.Count() > 0){

                File.WriteAllText(Program.file, "ID,Name,LastName,Savings,Password,PackedData");
                foreach (var item in Datos.persons)
                {

                    File.AppendAllText(Program.file, $"{Environment.NewLine}{item.Id},{item.Name},{item.LastName},{item.Savings},{item.Password},{item.DataSaved}");
                    
                }

            }

        }

    }

}

public enum Gender{

    Male = 0,
    Female = 8
        
}

public enum Degree{

    Basic = 0,
    Media = 1,
    Grade = 2,
    Post_Grade = 3
      
}

public enum CivilStatus{

    Single = 0,
    Married = 4
      
}

/*namespace registro
{

    public interface IDatosSet<D>{

        public bool Add (D persons);
        public bool Contains (D persons);
        public bool Remove (D persons);
        //public bool Replace => Remove
        

    }

    public class DatosSet : IDatosSet<D>{

        public DatosSet(in int buckets) {
            
            buckets = IDatosSet<D>.Add(D persons)

        }

        public enum sortById{

            Id

        }

        public sortById CompareByFields = sortById.Id;

        public string Compare(Datos x, Datos y)  
            {  
                switch (CompareByFields)  
                {  

                    case sortById.Id:  
                        return x.Id().CompareTo(y.Id());  
                    default:break;  
    
                }  
                return x.ConsoleData().CompareTo(y.Id());  
    
            } 

    }

}*/