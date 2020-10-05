using System;
public class Datos{

    public int Id { get; }
    public string Name { get; }
    public string LastName { get; }
    public int YearsOld => DataSaved >> 1;
    public Gender Gender => (Gender)(DataSaved & 0b1);
    public Degree Degree => (Degree)(DataSaved & 0b11);
    public CivilStatus CivilStatus => (CivilStatus)(DataSaved & 0b10);
    public decimal Savings { get; }
    public string Password { get; }
    public string PasswordConfirm { get; }
    public int DataSaved = 0;

    /*internal static Datos FromCsvLine(string line){

        string[] tokens = line.Split(',');
        (int id, string name, string lastName, decimal savings, int packedData, string password) 
            = (int.Parse(tokens[0]), tokens[1], tokens[2], decimal.Parse(tokens[3]), int.Parse(tokens[4]), tokens[5]);
             
        int yearsOld = (packedData >> 1);
        Gender gender = (Gender)(packedData & 0b1);
        Degree degree = (Degree)(packedData & 0b11);
        CivilStatus civilStatus = (CivilStatus)(packedData & 0b10);

        return new Datos(id, name, lastName, savings,  gender, packedData, password);

    }*/

    public Datos(in int id, in string name, in string lastName, in decimal savings, in int dataSaved, in string password){

        Id = id;
        Name = name;
        LastName = lastName;
        Savings = savings;
        Password = password;
        DataSaved = dataSaved;
        //DataSaved = (yearsOld << 1) | (int)gender & (int)degree | (int)civilStatus;

    }
    

}

public enum Gender{

    Male = 0,
    Female = 1
        
}

public enum Degree{

    Basic = 0,
    Media = 1,
    Grade = 2,
    Post_Grade = 3
      
}

public enum CivilStatus{

    Single = 0,
    Married = 1
      
}