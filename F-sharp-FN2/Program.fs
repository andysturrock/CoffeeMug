open System

type Coffee     = HasCoffee | NoCoffee
let ready ()    = Random().Next(0,2) = 1
let refill      = HasCoffee
let getCup      = if ready() then HasCoffee else NoCoffee
let workDone () = ready()
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