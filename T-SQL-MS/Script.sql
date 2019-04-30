USE master
GO

IF EXISTS (select * from sys.databases where name = 'CoffeeMug') 
DROP DATABASE CoffeeMug
GO

CREATE DATABASE CoffeeMug
GO 

USE CoffeeMug
GO

CREATE PROCEDURE Drink
	@cupEmpty bit output,  
	@potCoffeeLevel int output	
AS
	print('### Drinking coffee...')
	set @cupEmpty = 'true'
	set @potCoffeeLevel -= 1
	print('### Finished drinking coffee.')	
GO  

CREATE PROCEDURE ExecuteTask
	@workLeft int output,  
	@workDone bit output	
AS
	print('$$$ Working...')
	set @workLeft -= convert(int, rand() * 10)
	if(@workLeft < 0)
		begin
			set @workLeft = 0
			set @workDone = 'true'
		end
	if (@workLeft > 0)
		begin
			set @workDone = 'false'
			print('$$$ Stopping work for now - ' + convert(char(1), @workLeft) +' bits of work left')	
		end
	else
		begin
			print ('$$$ Task done! - 0 bits of work left')
            print ('$$$ Thank you very much!') 
		end
GO  

CREATE PROCEDURE Make
	@potCoffeeLevel int output
AS
	print ('--- Making coffee...') 
	set @potCoffeeLevel = 2
	print ('--- CoffePot is now full') 
GO  

CREATE PROCEDURE Refill
	@cupEmpty bit output
AS
	print ('=== Refilling coffee cup...') 
    set @cupEmpty = 'false'
    print ('=== Coffee cup is full.') 
GO

/****************************/
/* Program                  */
/****************************/
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
