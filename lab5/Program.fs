
open File1

[<EntryPoint>]
let main argv =


// zad1
    let n = 10
    printfn "Ciąg Fibonacciego dla n = %d (rekurencja): %d" n (fibonacci n)
    printfn "Ciąg Fibonacciego dla n = %d (rekurencja ogonowa): %d" n (fibonacciTail n)

// Zad2
    let tree = Node(10, Node(5, Empty, Empty), Node(15, Empty, Empty))
    let searchResult = searchElement tree 5
    printfn "Czy element 5 istnieje w drzewie? %b" searchResult

// zad3
    let numbers = [1; 2; 3]
    let permutations = permute numbers
    printfn "Permutacje listy [1; 2; 3]:"
    permutations |> List.iter (fun perm -> printfn "%A" perm)

 // zad4
    printfn "Rozwiązywanie problemu Wież Hanoi dla 3 dysków:"
    hanoi 3 "A" "C" "B"

//zad5
    let unsortedList = [5; 3; 8; 1; 2; 7; 6]
    let sortedList = quicksort unsortedList
    printfn "Posortowana lista (QuickSort): %A" sortedList


    0 