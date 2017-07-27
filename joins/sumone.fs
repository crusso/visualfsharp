type mypair = Mypair of int * int list
let test() = 
    let join sum (p:mypair) :int = 
                let (Mypair (acc,xs)) = p
                match xs with 
                | [] -> acc
                | x::xs -> sum (Mypair(x+acc,xs))
    sum (Mypair(0,[1;2;3;4]))

test()