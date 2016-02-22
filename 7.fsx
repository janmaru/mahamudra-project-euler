//10001st prime
//Problem 7
//By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
//
//What is the 10 001st prime number?

// You can define infinite sequences by using the Seq.initInfinite function. For such a sequence, you provide a function that generates each element 
// from the index of the element. Infinite sequences are possible because of lazy evaluation; elements are created as needed
// by calling the function that you specify. 

let before n =
     [2.. n-1]

let isPrime n =
    let is = before n
                |>List.map (fun x->if n%x=0 then 0 else 1)
                |>List.filter(fun x-> x=0)
    match is with
    |[]->true
    |_->false        

printfn "%A" (isPrime 104743)

let mutable count  = 0
let seqInfinite = Seq.initInfinite (fun index ->
                      let n =  index + 2
                      if isPrime n then
                         count<-count+1
                         printfn "%A" (count, n)
                      count)

let filteredSeqInfinite = Seq.takeWhile (fun elem -> elem < 10001) seqInfinite   
                           
printfn "%A" (filteredSeqInfinite |> Seq.last)
//(9999, 104723)
//(10000, 104729)
//(10001, 104743)
//10000