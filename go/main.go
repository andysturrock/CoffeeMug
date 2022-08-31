package main

import (
	"math/rand"
	"time"
)

func main() {
	rand.Seed(time.Now().Unix())

	workTask := NewWorkTask(10)
	coffeePot := NewCoffeePot(3)
	coffeeCup := NewCoffeeCup(coffeePot)

	for done := false; !done; done = workTask.Done() {
		coffeeCup.Drink()
		workTask.Execute()

		if coffeeCup.Empty() {
			if coffeePot.Empty() {
				coffeePot.Make()
			}

			coffeeCup.Refill()
		}
	}
}
