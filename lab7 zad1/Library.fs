module Library
open Book
open User

type Library() = 
    
    let mutable books = [] //lista ksiazek w bobliotece

    //metoda dodajaca ksiazke do biblioteki 
    member this.AddBook(book:Book) = 
        books <- book :: books
        printfn "Dodano ksiazke do biblioteki: %s" book.Title


    //metoda usuwajaca ksiazke
    member this.RemoveBook(book:Book) = 
        books <- List.filter (fun b -> b <> book) books
        printfn "Usunieto ksiazke z biblioteki: %s" book.Title

    

    //metoda wypisujaca wszytkie ksiazki 
    member this.ListBooks() = 
        printfn "Książki w bibliotece:"
        books |> List.iter (fun book -> printfn "%s" (book.GetInfo()))
        


