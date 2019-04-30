module Types 

    open System
    open System.Threading

    type CoffeeCup () =
        let mutable empty = true         
        member this.Empty() = empty          
        member this.Drink() =
            printfn "Drinking coffee..." 
            Thread.Sleep 1000
            empty <- true
            printfn "Finished drinking coffee."           
        member this.Refill() =
            printfn "Refilling coffee cup..." 
            Thread.Sleep 1000
            empty <- false    
            printfn "Coffee cup is full." 
    
    type CoffeePot () =
        let mutable empty = true 
        member this.Empty() = empty
        member this.Make() = 
            printfn "Making coffee..." 
            Thread.Sleep 1000
            empty <- false
            printfn "CoffePot is now full" 

    type WorkTask () = 
        let mutable work : int = 10
        let random : Random = new Random()
        member this.WorkTask() = 
            printfn "There are %d bits of work to do - let's get going!" work        
        member this.Done() = work <= 0;
        member this.Execute() = 
            printfn "Working..."
            work <- work - random.Next (1, 5)
            Thread.Sleep 1000
            printfn "Stopping work for now - %d bits of work left" work