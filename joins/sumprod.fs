let test() = 
    let join count (n:int) :int =    
                match n with 
                | 0 -> 0
                | n-> count (n-1)
    count 5

test()