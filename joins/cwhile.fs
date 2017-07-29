let test0(b:bool) =
    let r = ref b
    let join break(u:int) :int = 
             if (!r) then printfn "break1";u else break(u)
    begin 
        printfn "body1"
        if b then 
            printfn "then" 
            break(1)
        else
            printfn "else" 
            break(2)
    end


let test1() =
    let mutable x = 0
    let join break (u:int) :unit = (printfn "broke")
    while (true) do
      let join continue (u:int) :unit = (printfn "continued") 
      begin x <- x+1;
            if x = 5 then 
              printfn "break"
              break(1)
            else continue(2)
            x <- x+2;
      end
(*
let test2() =
    let mutable x = 0
    let join break (u:unit) :unit = ()
    while (true) do
      let join continue (u:unit) :unit = () 
      x <- x+1
      if x = 5  then 
        printfn "continue"
        continue()     
      if x = 10 then
        printfn "break" 
        break()

let test3() =
    let mutable x = 0
    let join break (u:int) :unit =  printfn "broke3";()
    while (true) do
      let join continue (u:int) :unit = printfn "continues3" ;() 
      begin
      x <- x+1;
      if x = 5  then 
        printfn "continue3"
        continue(1)     
      if x = 10 then
        printfn "break3" 
        break(2)
      end

test1()
test2()
*)
      

