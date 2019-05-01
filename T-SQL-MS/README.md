# CoffeeMug problem verification using T-SQL (MS SQL)

An implementation (verification) of ['Coffee Mug problem'](https://github.com/andysturrock/CoffeeMug) written in T-SQL (MS SQL).

In order to run the code, copy the content of **Script.sql** to MS SQL Server Management Studio and press F5

## Conclusion

The code on a mug can't be valid T-SQL - this is obvious:

```
declare
   @cupEmpty bit = 'false', 
   @potCoffeeLevel int = 2,
   @workLeft int = 10,
   @workDone bit = 'false'

while(@workDone = 'false')
begin
   exec dbo.Drink @cupEmpty output, @potCoffeeLevel output
   exec dbo.ExecuteTask @workLeft output, @workDone output
   if @workDone = 'false' AND @cupEmpty = 'true'
   begin
      if @workDone = 'false' AND @potCoffeeLevel = 0
         exec dbo.Make @potCoffeeLevel output
      exec dbo.Refill @cupEmpty output
   end
end
```
