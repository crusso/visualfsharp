

let test0() = 
    let join a (x:int) (y:int) :int = 1
    in  
       a 1 2 

(* can't be inferred 
let test() = 
    let join alta acc f g l : int list = 
            match l with 
            | [] -> acc
            | h::t -> altb (f(h)::acc) f g t 
        and  altb acc f g l : int list = 
            match l with 
            | [] -> acc
            | h::t -> let x = not (alta (g(h)::acc) f g t) in [] 
    in  
       alta [] (fun x -> x+1) (fun x -> x-1) [1;2;3;4] 
*)

let test() = 
    let join alta (acc:int list) (f:int->int) (g:int->int) (l:int list) : int list = 
            match l with 
            | [] -> acc
            | h::t -> altb (f(h)::acc) f g t 
        and  altb (acc:int list) (f:int->int) (g:int->int) (l:int list) : int list = 
            match l with 
            | [] -> acc
            | h::t -> alta (g(h)::acc) f g t
    in  
       alta [] (fun x -> x+1) (fun x -> x-1) [1;2;3;4]              

test()