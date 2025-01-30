open System
open File1

[<EntryPoint>]
let main argv =

    printfn "Zadanie 1: Liczba słów i znaków"
    printfn "Podaj tekst:"
    let inputText = Console.ReadLine()
    let (wordCount, charCount) = countWordsAndChars inputText
    printfn "Liczba słów: %d" wordCount
    printfn "Liczba znaków (bez spacji): %d" charCount


    printfn "\nZadanie 2: Sprawdzenie palindromu"
    printfn "Podaj tekst do sprawdzenia:"
    let inputText2 = Console.ReadLine()
    if isPalindrome inputText2 then
        printfn "Tekst jest palindromem."
    else
        printfn "Tekst nie jest palindromem."


    printfn "\nZadanie 3: Usuwanie duplikatów"
    printfn "Podaj słowa oddzielone spacjami:"
    let inputText3 = Console.ReadLine()
    let words = inputText3.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) |> List.ofArray
    let uniqueWords = removeDuplicates words
    printfn "Unikalne słowa: %A" uniqueWords

    printfn "\nZadanie 4: Zmiana formatu tekstu"
    printfn "Podaj dane w formacie 'imię; nazwisko; wiek':"
    let inputText4 = Console.ReadLine()
    let formattedText = changeFormat inputText4
    printfn "Zmodyfikowany format: %s" formattedText


    printfn "\nZadanie 5: Znajdowanie najdłuższego słowa"
    printfn "Podaj tekst:"
    let inputText5 = Console.ReadLine()
    let (longestWord, length) = findLongestWord inputText5
    printfn "Najdłuższe słowo to: '%s' o długości: %d" longestWord length

    printfn "\nZadanie 6: Wyszukiwanie i zamiana"
    printfn "Podaj tekst:"
    let inputText6 = Console.ReadLine()
    printfn "Podaj słowo do wyszukania:"
    let oldWord = Console.ReadLine()
    printfn "Podaj słowo do zamiany:"
    let newWord = Console.ReadLine()
    let modifiedText = replaceWord inputText6 oldWord newWord
    printfn "Zmodyfikowany tekst: %s" modifiedText

    0 