using System.IO;
using System;

class Program
{
    public static void Main()
    {
        
        var counter = BuildCounter();
        
        for(int x = 0; x <= 25; x++){
            
            Console.WriteLine(counter());
            
        }
        
    }
    
    static Func<int> BuildCounter(){
        
        int i = 0;
        
        return() => i++;
        
    }
    
}
