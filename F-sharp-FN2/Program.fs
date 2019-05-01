open System

type Coffee     = HasCoffee | NoCoffee
let isTrue ()   = Random().Next(0,2) = 0
let refill      = HasCoffee
let getCup      = if isTrue() then NoCoffee else HasCoffee
let workDone () = isTrue()
let check cup   =  
    match cup with
     | HasCoffee -> HasCoffee 
     | NoCoffee  -> refill
let drink cup   = printf "Ahh coffee"
let doWork ()   = printf "I'm working on it!"

[<EntryPoint>]
let main args =
    while not <| workDone() do
        getCup |> check |> drink |> doWork
    0