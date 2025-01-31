module Bank
open BankAccount

type Bank() =
    let mutable accounts: BankAccount list = []

    member this.CreateAccount(accountNumber: string, initialBalance: float) =
        match List.tryFind (fun (acc: BankAccount) -> acc.AccountNumber = accountNumber) accounts with
        | Some _ -> printfn "Konto o numerze %s już istnieje!" accountNumber
        | None ->
            let newAccount = BankAccount(accountNumber, initialBalance)
            accounts <- newAccount :: accounts
            printfn "Utworzono konto: %s z saldem %.2f PLN" accountNumber initialBalance

    member this.GetAccount(accountNumber: string) =
        accounts |> List.tryFind (fun acc -> acc.AccountNumber = accountNumber)

    member this.UpdateAccount(updatedAccount: BankAccount) =
        accounts <- accounts |> List.map (fun acc -> if acc.AccountNumber = updatedAccount.AccountNumber then updatedAccount else acc)
        printfn "Zaktualizowano konto: %s" updatedAccount.AccountNumber

    member this.DeleteAccount(accountNumber: string) =
        match this.GetAccount(accountNumber) with
        | Some _ ->
            accounts <- accounts |> List.filter (fun acc -> acc.AccountNumber <> accountNumber)
            printfn "Konto %s zostało usunięte" accountNumber
        | None -> printfn "Nie znaleziono konta o numerze %s" accountNumber

    member this.ListAccounts() =
        if accounts.IsEmpty then
            printfn "Brak kont w banku."
        else
            printfn "Lista kont w banku:"
            accounts |> List.iter (fun acc -> printfn "Konto: %s, Saldo: %.2f PLN" acc.AccountNumber acc.Balance)