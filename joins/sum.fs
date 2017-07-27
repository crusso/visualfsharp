let test() = 
    let join sum p :int = 
                let (acc,xs) = p
                match xs with 
                | [] -> acc
                | x::xs -> sum (x+acc,xs)
    sum (0,[1;2;3;4])

test()