let test() = 
    let join sum (acc:int) (xs:int list) :int =           
                match xs with 
                | [] -> acc
                | x::xs -> sum (x+acc) xs
    sum 0 [1;2;3;4]

let testrec() = 
    let rec sum (acc:int) (xs:int list) :int =           
                match xs with 
                | [] -> acc
                | x::xs -> sum (x+acc) xs
    sum 0 [1;2;3;4]


printfn "%A" (test())