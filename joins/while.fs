


let inline While b__Inline e__Inline = 
    let rec loop () = 
        if b__Inline() then e__Inline(); loop()
    loop()

let inline WhileRec b__Inline e__Inline = 
    let rec loop () = test(b__Inline())
        and test(v) = 
            if v then e__Inline(); loop()
    loop()


let inline WhileBreakCont b__Inline e__Inline = 
    let rec loop () = test(b__Inline())
        and test(v) = 
            if v then e__Inline(loop,fun() -> ())
    loop()



let f (i) = 
    let mutable x = 10
    While (fun () -> printfn "";x>i) (fun () -> printfn "";x <- x-i) 

let fRec(i) = 
    let mutable x = 10
    WhileRec (fun () -> printfn "";x>i) (fun () -> printfn "";x <- x-i) 

let fBreakContinue(i) = 
    let mutable x = 10
    WhileBreakCont  
             (fun () -> printfn "";x>i) 
             (fun (continue__Inline,break__Inline) -> 
                if x<0 
                then break__Inline() 
                else
                 printfn "";x <- x-i;
                 continue__Inline()) 


let f2 (i,j,k,l,m,n,o,p,q,r,s) = 
    let mutable x = 10
    While (fun () ->x>i+j+k+l+m+n+o+p+q+r+s) (fun () -> printfn "";x <- x-(i+j+k+l+m+n+o+p+q+r+s)) 

let inline map (f__Inline: 'T -> 'U) (array:'T[]) =           
    let res : 'U[] = Array.zeroCreate (Array.length array)
    for i = 0 to res.Length-1 do 
        res.[i] <- f__Inline array.[i]
    res

let g() =
    map (fun x -> printfn "%A" x;x+1) [| for i in 1 .. 1000 -> i |]

let rec inline alta (acc:int list) f__Inline g l = 
        match l with 
        | [] -> acc
        | h::t -> altb (f__Inline(h)::acc) f__Inline g t
    and altb acc f g l = 
        match l with 
        | [] -> acc
        | h::t ->alta (g(h)::acc) f g t

let  h() = alta [] (fun x -> x+1) (fun x -> x-1) [1;2;3;4]
             


g()
f(1)