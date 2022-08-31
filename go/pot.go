package main

import (
	"log"
	"time"
)

type CoffeePot struct {
	maxCups  uint
	cupsLeft uint
}

func NewCoffeePot(maxCups uint) *CoffeePot {
	return &CoffeePot{
		maxCups:  maxCups,
		cupsLeft: maxCups,
	}
}

func (cp *CoffeePot) Empty() bool {
	return cp.cupsLeft == 0
}

func (cp *CoffeePot) Make() {
	log.Println("Making coffee...")

	time.Sleep(time.Second)
	cp.cupsLeft = cp.maxCups

	log.Println("Coffee pot is now full!")
}

func (cp *CoffeePot) PourCup() {
	cp.cupsLeft -= 1
}
