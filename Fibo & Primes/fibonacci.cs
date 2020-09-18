using System;
   
   class Fibo {
      
      static void Main() {
         
         var fbonacciCounter = BuildFibonacciCounter();
            
	     for (int i = 0; i < 25; i++)
	        {

	            Console.WriteLine(fbonacciCounter());
	            
	        }
         
         
      }
      
      static Func<int> BuildFibonacciCounter() {
        
        int first = 0;
        int second = 1;
        
        return() =>{
            
        int temp = first;
        first = second;
        second = temp + second;
            
        
        return first;
            
        };
          
      }  
   
}
