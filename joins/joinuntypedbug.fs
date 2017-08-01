

//type inference
let ok() = 
    let join a x = a 3
    in  
       a 1 


//types can be inferred 
let test() = 
    let join alta acc f g l  = 
            match l with 
            | [] -> acc
            | h::t -> altb (f(h)::acc) f g t 
        and  altb acc f g l  = 
            match l with 
            | [] -> acc
            | h::t -> alta (g(h)::acc) f g t
    in  
       alta [] (fun x -> -x) (fun x -> x) [1;2;3;4] 

(*
let test() = 
    let join //alta (acc:int list) (f:int->int) (g:int->int) (l:int list) : int list = 
            alta acc f g l  = 
            match l with 
            | [] -> acc
            | h::t -> altb (f(h)::acc) f g t 
        and altb acc f g l = 
            match l with 
            | [] -> acc
            | h::t -> alta (g(h)::acc) f g t
    in  
       alta [] (fun x -> x+1) (fun x -> x-1) [1;2;3;4]              
*)

printfn "%A" (test())