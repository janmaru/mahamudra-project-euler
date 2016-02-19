//Largest prime factor
//Problem 3
//The prime factors of 13195 are 5, 7, 13 and 29.

//What is the largest prime factor of the number 600851475143 ?


// 1. Definition of prime number
// A prime number can only be divided by 1 or itself, 
// so it cannot be factored any further! 
// Every other whole number can be broken down into prime number factors. 
// It is like the Prime Numbers are the basic building blocks of all numbers (wiki)

//------------ Linear Time Solution: O(n)
// time execution is directly proportional to the input size
// very inefficient

let source2 = 600851475143L //int64 or long

let result2 = seq{for i in 1L .. source2 do
                   if source2%i = 0L then
                            printfn "evaluating: %A" i
                            yield i
                        else
                            printfn "-> %A" i
                            yield 0L
                }
                |>Seq.filter (fun x -> x>0L) 
                |>Seq.last

printfn "solution: %A" result2

//evaluating: 1L
//evaluating: 71L 
//evaluating: 839L
//evaluating: 1471L
//evaluating: 6857L
//evaluating: 59569L
//evaluating: 104441L
//evaluating: 486847L
//evaluating: 1234169L
//evaluating: 5753023L
//evaluating: 10086647L
//evaluating: 87625999L
//evaluating: 408464633L
//evaluating: 716151937L
//...

let mutable source4 = 600851475143L //int64 or long
let mutable continueLooping = true
let mutable i = 1L
let mutable factors = 1L
let mutable lastFactor = 0L
while continueLooping do
    i<-i+1L
    if source4%i = 0L then
        printfn "evaluating: %A" i
        factors <- factors*(i)
        source4<-source4/i
    if factors >= 600851475143L || source4=1L then
      lastFactor <-source4*i
      continueLooping <- false

printfn "solution: %A" lastFactor

