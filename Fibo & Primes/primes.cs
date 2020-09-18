using System;

class MainClass {
  
  public static void Main(){
        
        var primeCounter = BuildCounterPrime();
        
        while(true){
            
            int primeNumber = primeCounter();
            
            if(primeNumber == -1){
                
                break;
                
            }
            
            Console.WriteLine(primeNumber);
            
        }
        
    }
    
    static Func<int> BuildCounterPrime(){
        
        int first = 1;
        int print = 1000;
        bool[] not = new bool [print];
        
        return() => {
            
            if(first >= print) return -1;
           
            while(first < print && not[++first]);
                
                int count = 1;
                
                while(first * count < print){
                    
                    not[first * count] = true;
                    count++;
                    
                }
                
           return first;
                
        };
        
    }
  
}