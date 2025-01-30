module User

open Book

type User(name: string) =
    let mutable borrowedBooks: Book list = []  

    member this.Name = name
    
    member this.BorrowBook(book: Book) =
        borrowedBooks <- book :: borrowedBooks
        printfn "%s wypożyczył książkę: %s" this.Name book.Title

    member this.ReturnBook(book: Book) =
        borrowedBooks <- List.filter (fun b -> b.Title <> book.Title) borrowedBooks
        printfn "%s zwrócił książkę: %s" this.Name book.Title

    member this.ListBorrowedBooks() =
        if borrowedBooks.IsEmpty then
            printfn "%s nie wypożyczył żadnych książek." this.Name
        else
            printfn "Wypożyczone książki przez %s:" this.Name
            borrowedBooks |> List.iter (fun book -> printfn "%s" (book.GetInfo()))


