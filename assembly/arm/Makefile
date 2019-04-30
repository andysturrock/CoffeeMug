# Makefile
all: coffee

coffee: coffee.o
	gcc -v -o $@ $+
coffee.o: coffee.s
	as -g -o $@ $<
clean:
	rm -vf coffee *.o

