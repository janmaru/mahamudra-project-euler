//Multiples of 3 and 5
//Problem 1
//If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.

//Find the sum of all the multiples of 3 or 5 below 1000.

//------------ Linear Time Solution: O(n)
// time execution is directly proportional to the input size

//* get all the multiples
let multiplesOf3And5 n =
    match n with
        |n when n<=0 -> []
        |_-> [for i in 1 .. n-1 do
                if i%3 = 0 || i%5 = 0 then
                    yield i
                else
                    yield 0]
               |>List.filter (fun x -> x<>0) 

//* gets all the multiples or zeros instead
let multiplesOf3And5_II n =
    match n with
        |n when n<=0 -> []
        |_-> [for i in 1 .. n-1 do
                if i%3 = 0 || i%5 = 0 then
                    yield i
                else
                    yield 0]

//*filters with an accumulator for the sum
let sumOfMultiplesOf3And5 n =
    match n with
        |n when n<=0 -> 0
        |_-> [for i in 1 .. n-1 do
                if i%3 = 0 || i%5 = 0 then
                    yield i
                else
                    yield 0]
             |> List.reduce (fun x acc -> x + acc) 

//sums the results, including the zeros
let sumOfMultiplesOf3And5_II n =
    match n with
        |n when n<=0 -> 0
        |_-> [for i in 1 .. n-1 do
                if i%3 = 0 || i%5 = 0 then
                    yield i
                else
                    yield 0]
             |> List.sum

printfn "all the multiples of 3 or 5 below 1000 are %A" (multiplesOf3And5 10)

printfn "(II) all the multiples of 3 or 5 below 1000 are %A" (multiplesOf3And5_II 10)

printfn "the sum of all the multiples of 3 or 5 below 1000 is %A" (sumOfMultiplesOf3And5  1000)

printfn "(II) the sum of all the multiples of 3 or 5 below 1000 is %A" (sumOfMultiplesOf3And5_II  1000)


//------------ <<< O(n)
// time execution is NOT directly proportional to the input size

//* consider n=mq+r or n = m*3 + (n%3) so m = (n - (n%3))/3
//sample for 3
let sumOfmultiplesOf3 n =
    let k = n-1 //below n
    let m = (n - (n%3))/3
    match k with
        |k when k<=0 -> 0
        |_-> [for i in 1 .. m do
                yield i*3]
               |>List.sum

//generic sample for any number
let sumOfmultiplesOfZ n h =
    let k = n-1 //below n
    let m = (n - (n%h))/h
    match k with
        |k when k<=0 -> 0
        |_-> [for i in 1 .. m do
                yield i*h]
               |>List.sum

//we have summed numbers divisible by 15 twice ( so we have to subtract them from the sums of the two multiples) once for 3 and then for 5... ie. 30 =3*5*2 as 3*10 and 5*6
let sumOfMultiplesOf3And5_III n =
      sumOfmultiplesOfZ n 3 + sumOfmultiplesOfZ n 5 - sumOfmultiplesOfZ n 15

printfn "(III) the sum of all the multiples of 3 or 5 below 1000 is %A" (sumOfMultiplesOf3And5_III  1000)
