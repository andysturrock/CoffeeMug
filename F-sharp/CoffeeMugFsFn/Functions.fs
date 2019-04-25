module Functions 

    open System
    open System.Threading
    open Types
     
    let drink (cup, pot, task) =
        Console.ForegroundColor <- ConsoleColor.Green
        printfn "Drinking coffee..." 
        Thread.Sleep 1000
        printfn "Finished drinking coffee."  
        { EmptyCup = true }, pot, task 
   
    let execute (cup, pot, task) =
        Console.ForegroundColor <- ConsoleColor.Blue
        printfn "Working..."
        Thread.Sleep 1000
        let random : Random = new Random()
        let workLeft = task.Work - random.Next (1, 5)
        match workLeft with
        | w when w > 0 -> 
            printfn "Stopping work for now - %d bits of work left" w
            if w < 5 then
                cup, { EmptyPot = true }, { Work = w; Done = false }
            else
                cup, pot, { Work = w; Done = false }
        | _ ->   
            printfn "Task done! - 0 bits of work left"
            Console.ForegroundColor <- ConsoleColor.Red
            printfn "Thank you very much!" 
            cup, pot, { Work = 0; Done = true}

    let make (cup, pot, task) =
        if not task.Done && pot.EmptyPot then
            Console.ForegroundColor <- ConsoleColor.Yellow
            printfn "Making coffee..." 
            Thread.Sleep 1000
            printfn "CoffePot is now full" 
            cup, { EmptyPot = false }, task
        else
            cup, pot, task
               
    let refill (cup, pot, task) =
        if not task.Done && cup.EmptyCup then
            Console.ForegroundColor <- ConsoleColor.DarkGray
            printfn "Refilling coffee cup..." 
            Thread.Sleep 1000
            printfn "Coffee cup is full." 
            { EmptyCup = false }, pot, task
        else
            cup, pot, task 