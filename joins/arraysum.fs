
 
// fails to peverify but runs ok
let test(a:int[][]) =
    let join sumouter (acc:int) (i:int) :int =
        if (i<a.Length) 
        then let ai = a.[i]
             let join suminner (acc:int) (j:int) :int =
                if (j<ai.Length) 
                then suminner (acc+ai.[j]) (j+1)
                else sumouter acc (i+1)
             suminner acc 0
        else acc
    sumouter 0 0


(*
Matt's version
// fails to peverify but runs ok
let test(a:int[][]) =
      sumouter 0 0
      when sumouter (acc:int) (i:int) :int =
        if (i<a.Length) 
        then let ai = a.[i]  
             suminner acc 0
             when suminner (acc:int) (j:int) :int =
                if (j<ai.Length) 
                then suminner (acc+ai.[j]) (j+1)
                else sumouter acc (i+1)
               
        else acc
        *)
   


// fails to peverify but runs ok
let test2(a:int[][]) =
    let l = a.Length
    let join sumouter (acc:int) (i:int) :int =
        if (i<l) 
        then let ai = a.[i]
             let li = ai.Length
             let join suminner (acc:int) (j:int) :int =
                if (j<li) 
                then suminner (acc+ai.[j]) (j+1)
                else sumouter acc (i+1)
             suminner acc 0
        else acc
    sumouter 0 0


// same code, using let rec not let join
let testrec(a:int[][]) = 
    let rec sumouter (acc:int) (i:int) :int =
        if (i<a.Length) 
        then let ai = a.[i]
             let rec suminner (acc:int) (j:int) :int =
                if (j<ai.Length) 
                then suminner (acc+ai.[j]) (j+1)
                else sumouter acc (i+1)
             suminner acc 0
        else acc
    sumouter 0 0

(* 
// same code, using let rec not let join
let testrecinline(a:int[][]) = 
    let rec sumouter (acc:int) (i:int) :int =
        if (i<a.Length) 
        then let ai = a.[i]
             let rec inline suminner (acc:int) (j:int) :int =
                if (j<ai.Length) 
                then suminner (acc+ai.[j]) (j+1)
                else sumouter acc (i+1)
             suminner acc 0
        else acc
    sumouter 0 0
    *)

// fastest: builtin for loops du to array bounds checking optimization?
let testfor(a:int[][]) = 
    let mutable acc = 0
    for i in 0..a.Length-1 do
        let ai = a.[i]
        for j in 0..ai.Length-1 do
          acc <- acc+ai.[j]
    acc


// fastest: builtin for loops du to array bounds checking optimization?
let testwhile(a:int[][]) = 
    let mutable acc = 0
    let mutable i = 0
    while (i<a.Length) do
        let ai = a.[i]
        let mutable j = 0
        while (j<ai.Length) do
          acc <- acc+ai.[j]
          j <- j+1
        i <- i+1
    acc

// forces 1m .tail calls for testrec
let a  = Array.create 1000000 (Array.create 1 1)

let timeit(f,a) = 
                let sw = new System.Diagnostics.Stopwatch()
                sw.Start()
                let res = f(a)
                sw.Stop()
                (res,sw.ElapsedTicks)


for i in 1 .. 10 do
    let res1 = timeit(test,a)
    let res2 = timeit(testrec,a)
    let res3 = timeit(testfor,a)
    let res4 = timeit(testwhile,a)
    let res5 = timeit(test2,a)
    printfn "join %A" res1
    printfn "rec %A" res2
    printfn "ratio: %A" ((double) (snd res2) / (double) (snd res1))
    printfn "for %A" res3
    printfn "ratio: %A" ((double) (snd res3) / (double) (snd res1))
    printfn "while %A" res4
    printfn "ratio: %A" ((double) (snd res4) / (double) (snd res1))
    printfn "join2 %A" res5
    printfn "ratio: %A" ((double) (snd res5) / (double) (snd res1))
    printfn "-----------"
