module Functions 

    open System
    open System.Threading
    open Types
     
    let print color message = 
        Console.ForegroundColor <- color
        printfn message 

    let printInt color message number = 
        Console.ForegroundColor <- color
        printfn message number 

    let drink (cup, pot, task) =
        print ConsoleColor.Green "Drinking coffee..." 
        Thread.Sleep 1000
        print ConsoleColor.Green "Finished drinking coffee."
        let coffeeLeft = pot.CoffeeLevel - 1
        { EmptyCup = true }, {CoffeeLevel = coffeeLeft}, task 
   
    let execute (cup, pot, task) =
        print ConsoleColor.Blue "Working..."
        Thread.Sleep 1000
        let random : Random = new Random()
        let workLeft = task.Work - random.Next (1, 5)
        match workLeft with
        | w when w > 0 -> 
            printInt ConsoleColor.Blue "Stopping work for now - %d bits of work left" w
            cup, pot, { Work = w; Done = false }
        | _ ->   
            print ConsoleColor.Blue  "Task done! - 0 bits of work left"
            print ConsoleColor.Red "Thank you very much!" 
            cup, pot, { Work = 0; Done = true}

    let make (cup, pot, task) =
        if not task.Done && pot.CoffeeLevel = 0 then
            print ConsoleColor.Yellow "Making coffee..." 
            Thread.Sleep 1000
            print ConsoleColor.Yellow "CoffePot is now full" 
            cup, { CoffeeLevel = 2 }, task
        else
            cup, pot, task
               
    let refill (cup, pot, task) =
        if not task.Done && cup.EmptyCup then
            print ConsoleColor.DarkGray "Refilling coffee cup..." 
            Thread.Sleep 1000
            print ConsoleColor.DarkGray "Coffee cup is full." 
            { EmptyCup = false }, pot, task
        else
            cup, pot, task 