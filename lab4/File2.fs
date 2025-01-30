module File2

open System

let exchangeRates =
    Map.ofList [
        ("PLN", 1.0)
        ("USD", 0.25)
        ("EUR", 0.22)
        ("GBP", 0.19)
    ]

let convertCurrency (amount: float) (fromCurrency: string) (toCurrency: string) =
    let fromRate = Map.tryFind fromCurrency exchangeRates
    let toRate = Map.tryFind toCurrency exchangeRates

    match fromRate, toRate with
    | Some fRate, Some tRate ->
        let amountInPLN = amount / fRate 
        let convertedAmount = amountInPLN * tRate 
        Some convertedAmount
    | _ -> None 