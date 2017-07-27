

let test0() = 
    let join a x y = 1
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
type tuple = Tuple of (int list) * (int->int) * (int->int)  * (int list)
let test() = 
    let join alta (tuple:tuple) : int list = 
            match tuple with 
            | Tuple(acc,f,g,l) ->
                match l with 
                | [] -> acc
                | h::t -> altb (Tuple((f(h)::acc), f ,g ,t))
        and  altb (tuple:tuple) : int list = 
            match tuple with 
            | Tuple(acc,f,g,l) ->
                match l with 
                | [] -> acc
                | h::t ->  alta (Tuple((g(h)::acc), f ,g ,t))
    in  
       alta (Tuple([], (fun x -> x+1), (fun x -> x-1), [1;2;3;4]))             

test()