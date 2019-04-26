# CoffeeMug problem verification using F#

An implementation (verification) of ['Coffee Mug problem'](https://github.com/andysturrock/CoffeeMug) written in F# (object oriented way).

## Conclusion
The code on a mug can't be valid F# (even if written in object oriented way) because of at least 5 reasons:
* F# has no `do ... while ... ` (only `while ... do ...`)
* F# uses  `then` keyword in `if ... then ...` block
* F# uses  `not` keyword instead of `!` 
* F# does not use semicolons `...;` on the end of the line
* F# does not use curly brackets `{...}` to separate blocks of code