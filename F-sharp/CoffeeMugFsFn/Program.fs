open System
open Types
open Functions

[<EntryPoint>]
let main argv = 

    let rec workUntilDone (cup, pot, task) = 
        if not task.Done then
            (cup, pot, task) |> (drink >> execute >> make >> refill)
            |> workUntilDone 
   
    ({EmptyCup = false}, {CoffeeLevel = 2}, {Work = 10; Done = false}) |> workUntilDone
    
    Console.ReadLine() |> ignore

    0 // return an integer exit code
