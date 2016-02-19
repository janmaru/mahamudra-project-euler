//Problem 4
//
//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//
//Find the largest palindrome made from the product of two 3-digit numbers.

//1 = 1*10^-1
//11 = 1*10^1 + 1
//22 = 2*10^1 + 2
//99 = 9*10^1 + 9
//101 = 1*10^2 + 1
//111 = 1*10^2 + 1*10^1 + 1
//...
//909 = 9*10^2 + 9
//999 = 9*10^2 + 9*10^1 + 9
//1001 = 1*10^3 + 1
//1111 = 1*10^3 + 1*10^2 + 1*10^1 + 1

//9009 = 9*10^3 + 9
//9999 = 9*10^3 + 9*10^2 + 9*10^1 + 9
//10001  = 1*10^4 + 1 
//11011 = 1*10^4 + 1*10^3 + 1*10^2 + 1
//11111 =  1*10^4 + 1*10^3 + 1*10^2 + 1*10^1 + 1

//so what's a palindromic number? How we define it? 
//Is it a mathemathical definition or an aestethical one?
//If the second answer is true then we're going to use strings and list of chars

//check if a number is palindromic
let isPalindromic number=
    let snumber = number.ToString()
    let cnumber = [for x in snumber do yield x]
    //The rev function reverses the elements in a list or array . 
    let rnumber =  List.rev cnumber
    if cnumber = rnumber then
       true
    else
       false

let mutable numbe2r = 9009
printfn "the number %A %O palindromic" numbe2r (isPalindromic numbe2r|>(fun x-> if x = true then "is" else "is not"))

// Now we start from 9009 and we go ahead counting adding one
// in order to find other palindromic numbers and we stop 
// when k*z = p, where p is the biggest palindromic number with k and z with 3 digits
 
let findBiggestPalindromic3 n =
    let mutable number = n
    let mutable check = true
    let mutable counter = 0
    let mutable isTheNumber = 0

    while check do
        number<-number+1

        if isPalindromic number then
           //check the digits
           for x in 100 .. 999 do
              if number%x = 0 then
                 let leny = (number/x).ToString().Length
                 let lenx = x.ToString().Length
                 if leny = 3 && lenx = 3 then
                    isTheNumber <- number
                 else
                     if lenx = 3 && leny = 5 then
                        check<-false
    
    isTheNumber
    
printfn "the number is: %A" (findBiggestPalindromic3 numbe2r)

//> 
//10201 101 101
//11211 101 111
//11211 111 101
//12221 101 121
//...
//886688 968 916
//888888 924 962
//888888 962 924
//906609 913 993
//906609 993 913
