package main

import (
	"log"
	"math/rand"
	"time"
)

type WorkTask struct {
	tasks uint
}

func NewWorkTask(tasks uint) *WorkTask {
	log.Printf("There are %d bits of work to do - let's get going!\n", tasks)

	return &WorkTask{tasks: tasks}
}

func (wt *WorkTask) Done() bool {
	return wt.tasks == 0
}

func (wt *WorkTask) Execute() {
	log.Println("Working...")

	wt.tasks -= uint(rand.Intn(int(wt.tasks + 1)))
	time.Sleep(time.Second)

	log.Printf("Stopping work for now - %d bits of work left", wt.tasks)
}
