# CoffeeMug problem verification using F#

An implementation (verification) of ['Coffee Mug problem'](https://github.com/andysturrock/CoffeeMug) written in F# (functional way).

## Conclusion
The code on a mug can't be valid F# written in functional way.

The code is obviously shorter, but functional style is completly different compared with what is on a mug:
*  `while ... do ...` loop can't be used
*  `rec` keyword (recursive function) must be used
*  `>>` operator (function composition) is used (not required but convenient)
*  `|>` pipeline operator is used (data first then function - very common in F#)
*  Separate line for calling recursive function for the first time must be used