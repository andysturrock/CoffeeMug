# CoffeeMug problem verification using F#

An implementation (verification) of ['Coffee Mug problem'](https://github.com/andysturrock/CoffeeMug) written in F# (functional way).

## Conclusion
The code on a mug can't be valid F# written in functional way.

The code is obviously shorter, but functional style is completly different compared with what is on a mug:
*  `while ... do ...` loop can't be used
*  `rec` keyword (recursive function) must be used
*  `|>` pipeline operator is used (data first then function - very common in F#)
*  Separate line for calling recursive function for the first time must be used

```
    let rec workUntilDone (cup, pot, task) = 
        if not task.Done then
            (cup, pot, task) 
            |> drink
            |> execute 
            |> make 
            |> refill
            |> workUntilDone 
   
    ({EmptyCup = false}, {CoffeeLevel = 2}, {Work = 10; Done = false}) 
    |> workUntilDone
```