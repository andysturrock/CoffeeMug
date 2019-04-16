# CoffeeMug problem verification using Python

An implementation (verification) of ['Coffee Mug problem'](https://github.com/andysturrock/CoffeeMug) written in Python.

## Conclusion

The code on the mug can't be valid Python, as the syntax is completely different. So this was just for fun!

Some Python best practices also conflict with the syntax on the mug:

- A common design pattern is the concept of `EAFP` - meaning 'Easier to ask for forgiveness than permission'. This means that rather than checking a value before an action, just try doing the action and catch and do something with the possible error.
    - Example 1 (LBYL 'look before you leap'):
    ```
    #check whether int conversion will raise an error
    if not isinstance(s, str) or not s.isdigit:
        return None
    elif len(s) > 10:    #too many digits for int conversion
        return None
    else:
        return int(str)
    ```
    - Example 2 (EAFP: Easier to ask for forgiveness than permission):
    ```
    try:
        return int(str)
    except (TypeError, ValueError, OverflowError): #int conversion failed
        return None
    ```
