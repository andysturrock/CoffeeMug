# Go Coffee Mug
Go has no do while loop, so we must run a for loop as so which will run one iteration before checking if the
`workTask.Done()`:
```go
for done := false; !done; done = workTask.Done()
```

## Example Output
```text
┌me@my-machine ~/c/C/go
└> go run .
2022/08/17 07:31:17 There are 10 bits of work to do - let's get going!
2022/08/17 07:31:17 Drinking coffee...
2022/08/17 07:31:18 Finished drinking coffee!
2022/08/17 07:31:18 Working...
2022/08/17 07:31:19 Stopping work for now - 6 bits of work left
2022/08/17 07:31:19 Refilling coffee cup...
2022/08/17 07:31:20 Coffee cup is full!
2022/08/17 07:31:20 Drinking coffee...
2022/08/17 07:31:21 Finished drinking coffee!
2022/08/17 07:31:21 Working...
2022/08/17 07:31:22 Stopping work for now - 2 bits of work left
2022/08/17 07:31:22 Refilling coffee cup...
2022/08/17 07:31:23 Coffee cup is full!
2022/08/17 07:31:23 Drinking coffee...
2022/08/17 07:31:24 Finished drinking coffee!
2022/08/17 07:31:24 Working...
2022/08/17 07:31:25 Stopping work for now - 0 bits of work left
2022/08/17 07:31:25 Refilling coffee cup...
2022/08/17 07:31:26 Coffee cup is full!

```