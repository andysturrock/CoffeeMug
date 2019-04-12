# CoffeeMug

Someone at work posted this image: ![CoffeeMug](./CoffeeMug.jpg "CoffeeMug")

It led to a discussion of which language it was probably written in.  I thought it was C# because of the UpperCamelCase method names.  So I thought I'd write the code.

It can definitely be sensible C# apart from the ```Empty()``` methods.  That would be better done in C# with a property, which then wouldn't have () after the property name, so:
```if (coffeeCup.Empty())``` would actually be better C# if it was: ```if (coffeeCup.Empty)```.