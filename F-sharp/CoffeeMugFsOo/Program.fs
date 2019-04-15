open System

[<EntryPoint>]
let main argv =
    
    let coffeeCup = new Types.CoffeeCup()
    let coffeePot = new Types.CoffeePot()
    let workTask = new Types.WorkTask()
    
    while not (workTask.Done()) do
        coffeeCup.Drink()
        workTask.Execute()
        if coffeeCup.Empty() then
            if coffeePot.Empty() then
                coffeePot.Make()
                coffeeCup.Refill()
    
    Console.ReadLine() |> ignore
    
    0
