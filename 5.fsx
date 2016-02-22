//Smallest multiple
//Problem 5
//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//
//What is the smallest positive number that is evenly divisible (divisible with no remainder) by all of the numbers from 1 to 20?


let result = [1..10]
                  |>List.map (fun x-> if 2520%x=0 then (true,x) else (false,x))
let result4 = [10;9;8;7]
                  |>List.map (fun x-> if 2520%x=0 then (true,x) else (false,x))
printf "%A" result
printf "%A" result4
//  [(true, 1); (true, 2); (true, 3); (true, 4); (true, 5); (true, 6); (true, 7);
//   (true, 8); (true, 9); (true, 10)]

//let's create a boolean function that gives out true only if all results are true

let check10 n=
        [1..10] |>
            List.fold (fun acc x -> acc&&(n%x=0)) true 

let check10_4 n=
        [10;9;8;7] |>
            List.fold (fun acc x -> acc&&(n%x=0)) true 

printf "%A" (check10_4 2520)

let check20 n=
        [1..20] |>
            List.fold (fun acc x -> acc&&(n%x=0)) true 

printf "%A" (check20 2520)

let check20_4 n=
        [20;19;18;17;16;15;14;13] |>
            List.fold (fun acc x -> acc&&(n%x=0)) true 

let findDaNumber = 
    let mutable counter = 20
    let mutable check = true
    while check do
         counter <- counter + 1
         check <- not (check20_4 counter)
         printfn "%A" (check,counter)
    counter

printf "%A" findDaNumber
//13
//14=7*2
//15=3*5
//16=2*2*2*2
//17
//18=3*3*2
//19
//20=5*2*2

let findDaNumber_II = 
    let mutable counter = [19;17;13;7;5;3;2] |> List.fold (fun acc x -> acc *x) 1 
    let mutable check = true
    while check do
         counter <- counter + 1
         if counter%20=0 then
            if counter%19=0 then
                if counter%18=0 then
                      if counter%17=0 then
                            if counter%16=0 then
                                 if counter%15=0 then
                                      if counter%14=0 then
                                         if counter%13=0 then
                                             check <- false
         printfn "%A" (check,counter)
    counter

printf "%A" findDaNumber_II

// let' see if we can reason a bit on the problem
// instead of "brute force attack" it
// from 1 to 20 I'm going to consider all the prime numbers
// and their biggest multiples
//1
//2
//3
//4=2*2
//5
//6=3*2
//7
//8=2*2*2
//9=3*3
//10=2*5
//11
//12=3*2*2
//13
//14=2*7
//15=3*5
//16=2*2*2*2
//17
//18=2*3*3
//19
//20=2*2*5

//hence our number is 16*5*7*9*11*13*17*19
 
let multiple n =
    let mutable check = true
    let mutable i=1
    let mutable result = (1,n)
    while check do //from 2 to n-1
        i<-i+1
        if n%i = 0 then
           result<-(n/i,i)
           check<-false
        else
           if i=n-1 || n=1 then
             check<-false
    result

let multiples n = 
    let mutable check = true
    let mutable temp = n
    let mutable list = []
    while check do
        let m = multiple temp
        if (fst m)=1 then
           temp<-1
           list <- (snd m)::list
           check<-false
        else
           list <- (snd m)::list
           temp<-fst m

    list |>List.sort

printfn "%A" (multiples 9)

for x in [1..20] do
    printfn "%A" (multiples x)

//[1]
//[2]
//[3]
//[2; 2]
//[5]
//[2; 3]
//[7]
//[2; 2; 2]
//[3; 3]
//[2; 5]
//[11]
//[2; 2; 3]
//[13]
//[2; 7]
//[3; 5]
//[2; 2; 2; 2]
//[17]
//[2; 3; 3]
//[19]
//[2; 2; 5]



//let count pred = List.sumBy (fun x -> if pred x then 1 else 0)
//let HowManySatisfy pred = Seq.filter pred >> Seq.length 
//
//for x in [1..20] do
//    for z in (multiples x) do
//      printfn "%A" (count (fun y -> y = x) (multiples x), x)

//let nums = [1;2;3;4;5]
//let countEvens = nums |> HowManySatisfy (fun n -> n%2=0) 
//printfn "%d" countEvens