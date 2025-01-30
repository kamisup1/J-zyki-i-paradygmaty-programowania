
open System
open File1
open File2
open File3
open File4
open File5

[<EntryPoint>]
let main argv =

//zad1
    let user = getUserData()
    let bmi = calculateBMI user
    let category = categorizeBMI bmi

    printfn "\nTwoje BMI wynosi: %.2f" bmi
    printfn "Kategoria BMI: %s" category

//zad2

    try
        printf "Podaj kwotę do przeliczenia: "
        let amount = Console.ReadLine() |> float

        printf "Podaj walutę źródłową (np. USD, EUR, GBP, PLN): "
        let fromCurrency = Console.ReadLine().ToUpper()

        printf "Podaj walutę docelową: "
        let toCurrency = Console.ReadLine().ToUpper()

        match convertCurrency amount fromCurrency toCurrency with
        | Some result ->
            printfn "\n%.2f %s to %.2f %s" amount fromCurrency result toCurrency
        | None ->
            printfn "Niepoprawne waluty! Sprawdź wprowadzone wartości."

    with
    | :? System.FormatException ->
        printfn "Błąd: Niepoprawna kwota. Wprowadź liczbę."


 //zad3


    printf "Wprowadź tekst: "
    let inputText = Console.ReadLine()

    let wordCount = countWords inputText
    printfn "Liczba słów: %d" wordCount

    let charCount = countCharsWithoutSpaces inputText
    printfn "Liczba znaków (bez spacji): %d" charCount

    let mostFrequentWord = findMostFrequentWord inputText
    printfn "Najczęściej występujące słowo: %s" mostFrequentWord




    //zad4

    let mutable bank: BankSystem = Map.empty

    let showMenu () =
        printfn "\nWybierz operację:"
        printfn "1. Tworzenie nowego konta"
        printfn "2. Depozyt"
        printfn "3. Wypłata"
        printfn "4. Sprawdzenie salda"
        printfn "5. Wyjście"

    let processChoice choice =
        match choice with
        | 1 ->
            printf "Podaj numer konta: "
            let accountNumber = Console.ReadLine()
            printf "Podaj początkowy depozyt: "
            let initialDeposit = Convert.ToDouble(Console.ReadLine())
            bank <- createAccount bank accountNumber initialDeposit
            printfn "Konto zostało utworzone. Numer konta: %s" accountNumber
        | 2 ->
            printf "Podaj numer konta: "
            let accountNumber = Console.ReadLine()
            printf "Podaj kwotę do depozytu: "
            let depositAmount = Convert.ToDouble(Console.ReadLine())
            bank <- deposit bank accountNumber depositAmount
        | 3 ->
            printf "Podaj numer konta: "
            let accountNumber = Console.ReadLine()
            printf "Podaj kwotę do wypłaty: "
            let withdrawalAmount = Convert.ToDouble(Console.ReadLine())
            bank <- withdraw bank accountNumber withdrawalAmount
        | 4 ->
            printf "Podaj numer konta: "
            let accountNumber = Console.ReadLine()
            displayBalance bank accountNumber
        | 5 -> printfn "Zakończenie programu."
        | _ -> printfn "Nieprawidłowy wybór."

   
    let rec startBanking () =
        showMenu()
        let choice = Convert.ToInt32(Console.ReadLine())
        if choice <> 5 then
            processChoice choice
            startBanking ()
        else
            printfn "Dziękujemy za skorzystanie z usług banku."

    startBanking ()



    //zad5
    printfn "Witaj w grze Kółko i Krzyżyk!"
    startGame ()

    0 