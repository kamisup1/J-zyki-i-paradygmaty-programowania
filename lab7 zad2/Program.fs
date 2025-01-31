open System
open Bank
open BankAccount

[<EntryPoint>]
let main argv =

    let bank = Bank()


    bank.CreateAccount("12345", 1000.0)
    bank.CreateAccount("67890", 500.0)
    
    //wyplata i wyplata
    match bank.GetAccount("12345") with
    | Some acc -> 
        acc.Deposit(200.0)
        acc.Withdraw(50.0)
    | None -> printfn "Konto nie istnieje"


    bank.ListAccounts()

    bank.DeleteAccount("67890")

    bank.ListAccounts()

    0 