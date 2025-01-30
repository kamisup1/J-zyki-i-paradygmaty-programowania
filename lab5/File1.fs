module File1


// 1 ciag fibonacciego
let rec fibonacci n =
    if n <= 1 then n
    else fibonacci (n - 1) + fibonacci (n - 2)

let fibonacciTail n =
    let rec aux n acc1 acc2 =
        if n = 0 then acc1
        elif n = 1 then acc2
        else aux (n - 1) acc2 (acc1 + acc2)
    aux n 0 1

// 2 drzewo binarne
type Tree<'T> =
    | Empty
    | Node of 'T * Tree<'T> * Tree<'T>

let rec searchElement tree value =
    match tree with
    | Empty -> false
    | Node (x, left, right) when x = value -> true
    | Node (_, left, right) -> 
        searchElement left value || searchElement right value

// 3 permutacja
let rec permute lst =
    match lst with
    | [] -> [[]]
    | head :: tail ->
        let perms = permute tail
        List.collect (fun perm ->
            [for i in 0 .. List.length perm do
                yield List.insertAt i head perm]) perms

// zad4 wieza hanoi
let rec hanoi n from_ to_ aux =
    if n > 0 then
        hanoi (n - 1) from_ aux to_
        printfn "Przenieś dysk %d z %s na %s" n from_ to_
        hanoi (n - 1) aux to_ from_

// 5quick sort
let rec quicksort lst =
    match lst with
    | [] -> []
    | pivot :: tail ->
        let lessThanPivot = List.filter (fun x -> x < pivot) tail
        let greaterThanPivot = List.filter (fun x -> x > pivot) tail
        (quicksort lessThanPivot) @ [pivot] @ (quicksort greaterThanPivot)