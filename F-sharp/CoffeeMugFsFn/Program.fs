open Types
open Functions
open System

[<EntryPoint>]
let main argv = 

    let rec workUntilDone (cup, pot, task) = 
        if not task.Done then
            (cup, pot, task) 
            |> drink 
            |> execute
            |> make
            |> refill
            |> workUntilDone 
   
    workUntilDone ({EmptyCup = false }, { EmptyPot = false }, { Work = 10; Done = false })
    
    Console.ReadLine() |> ignore
    0 // return an integer exit code
