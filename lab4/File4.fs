module File4

type Account = { accountNumber: string; mutable balance: float }

type BankSystem = Map<string, Account>

let createAccount (bank: BankSystem) accountNumber initialDeposit =
    if bank.ContainsKey(accountNumber) then
        printfn "Konto o tym numerze już istnieje."
        bank
    else
        let newAccount = { accountNumber = accountNumber; balance = initialDeposit }
        bank.Add(accountNumber, newAccount)

let deposit (bank: BankSystem) accountNumber amount =
    match bank.TryFind(accountNumber) with
    | Some account when amount > 0.0 ->
        account.balance <- account.balance + amount
        printfn "Deposited: %.2f. New balance: %.2f" amount account.balance
        bank
    | Some _ when amount <= 0.0 ->
        printfn "Kwota depozytu musi być większa od 0."
        bank
    | None ->
        printfn "Nie znaleziono konta o podanym numerze."
        bank

let withdraw (bank: BankSystem) accountNumber amount =
    match bank.TryFind(accountNumber) with
    | Some account when amount > 0.0 && account.balance >= amount ->
        account.balance <- account.balance - amount
        printfn "Withdrew: %.2f. New balance: %.2f" amount account.balance
        bank
    | Some _ when amount <= 0.0 ->
        printfn "Kwota wypłaty musi być większa od 0."
        bank
    | Some account when account.balance < amount ->
        printfn "Niewystarczające środki na koncie."
        bank
    | None ->
        printfn "Nie znaleziono konta o podanym numerze."
        bank

let displayBalance (bank: BankSystem) accountNumber =
    match bank.TryFind(accountNumber) with
    | Some account -> printfn "Saldo konta %s: %.2f" accountNumber account.balance
    | None -> printfn "Nie znaleziono konta o podanym numerze."