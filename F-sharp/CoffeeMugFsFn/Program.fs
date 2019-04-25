open System.Threading
open System

type Cup = { EmptyCup : bool }  
type Pot = { EmptyPot : bool }  
type Work = { Work : int; Done : bool }

let drink (cup, pot, work) =
    Console.ForegroundColor <- ConsoleColor.Green
    printfn "Drinking coffee..." 
    Thread.Sleep 1000
    printfn "Finished drinking coffee."  
    { EmptyCup = true }, pot, work 

let execute (cup, pot, work) =
    Console.ForegroundColor <- ConsoleColor.Blue
    printfn "Working..."
    Thread.Sleep 1000
    let random : Random = new Random()
    let workLeft = work.Work - random.Next (1, 5)
    match workLeft with
    | w when w > 0 -> 
        printfn "Stopping work for now - %d bits of work left" w
        cup, pot, { Work = w; Done = false }
    | _ ->   
        printfn "Task done! - 0 bits of work left"
        Console.ForegroundColor <- ConsoleColor.Red
        printfn "Thank you very much!" 
        cup, pot, { Work = 0; Done = true}
        
let make (cup, pot, work) =
    if not work.Done && pot.EmptyPot then
        Console.ForegroundColor <- ConsoleColor.DarkRed
        printfn "Making coffee..." 
        Thread.Sleep 1000
        printfn "CoffePot is now full" 
        cup, { EmptyPot = false }, work
    else
        cup, pot, work
 
let refill (cup, pot, work) =
    if not work.Done && cup.EmptyCup then
       Console.ForegroundColor <- ConsoleColor.DarkGray
       printfn "Refilling coffee cup..." 
       Thread.Sleep 1000
       printfn "Coffee cup is full." 
       { EmptyCup = false }, pot, work
    else
        cup, pot, work  

[<EntryPoint>]
let main argv = 

    let rec workUntilDone (cup, pot, work) = 
        if not work.Done then
            (cup, pot, work) 
            |> drink 
            |> execute
            |> make
            |> refill
            |> workUntilDone 
   
    ({EmptyCup = false }, { EmptyPot = false }, { Work = 10; Done = false })
    |> workUntilDone 
    
    Console.ReadLine() |> ignore
    0 // return an integer exit code
