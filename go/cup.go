package main

import (
	"log"
	"time"
)

type CoffeeCup struct {
	empty bool
	pot   *CoffeePot
}

func NewCoffeeCup(pot *CoffeePot) *CoffeeCup {
	return &CoffeeCup{pot: pot}
}

func (cc *CoffeeCup) Drink() {
	log.Println("Drinking coffee...")

	time.Sleep(time.Second)
	cc.empty = true

	log.Println("Finished drinking coffee!")
}

func (cc *CoffeeCup) Refill() {
	log.Println("Refilling coffee cup...")

	time.Sleep(time.Second)

	cc.pot.PourCup()
	cc.empty = false

	log.Println("Coffee cup is full!")
}

func (cc *CoffeeCup) Empty() bool {
	return cc.empty
}
