module BankAccount

type BankAccount(accountNumber: string, initialBalance: float) =
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance
        with get() = balance

    member this.Deposit(amount: float) =
        if amount > 0.0 then
            balance <- balance + amount
            printfn "Wpłacono %.2f PLN na konto %s. Nowe saldo: %.2f PLN" amount accountNumber balance
        else
            printfn "Kwota musi być większa od 0."

    member this.Withdraw(amount: float) =
        if amount > 0.0 && amount <= balance then
            balance <- balance - amount
            printfn "Wypłacono %.2f PLN z konta %s. Nowe saldo: %.2f PLN" amount accountNumber balance
        else
            printfn "Nieprawidłowa kwota wypłaty!"


    

