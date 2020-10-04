function recursiveSum(x) {

    if (x === 0) {

        return x;
        
    } else {

        return x + recursiveSum(x - 1);
        
    }
    
}

function tailrecursiveSum(x, total = 0) {

    if (x === 0) {

        return total;
        
    } else {

        return tailrecursiveSum(x - 1, total + x);
        
    }
    
}

//Factorial N

function recursiveFactorial(x) {

    if (x <= 1) {

        return x;
        
    } else {

        return x * recursiveFactorial(x - 1);
        
    }
    
}

function tailrecursiveFactorial(x, total = 1) {

    if (x <= 1) {

        return total;
        
    } else {

        return tailrecursiveFactorial(x - 1, total * x);
        
    }
    
}

//GCD

function maxGCD(x, y) {

    if (y == 0) {

        return x;
        
    } else {

        return maxGCD(y, x % y);
        
    }
    
}

function tailmaxGCD(x, y) {

    if ((y % x) == 0) {

        return x;
        
    } else {

        return tailmaxGCD(y, x % y);
        
    }
    
}


//----------------------------------------------------------------------------------------------------------------------\\

function iterativeSum(x){

    var sum = 1;

    for (let i = 2; i <= x;  i++){

        sum += i;  

    }

    return sum;

}

function iterativeFac(x){

    var factorial = 1;

    for (let i = 2; i <= x;  i++){

        factorial *= i;  

    }

    return factorial;

}

function maxGCD(x, y) {

    if(x == 0) return y;

    while (y!= 0) {

        if (x > y) {

            x = x - y;
            
        } else {

            y = y - x;
            
        }
        
    }

    return x;
    
}