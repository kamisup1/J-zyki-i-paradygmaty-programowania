open System

open Book
open User
open Library

[<EntryPoint>]
let main argv =

    let library = Library()

    let book1 = Book("Wiedźmin", "Andrzej Sapkowski", 500)
    let book2 = Book("Harry Potter", "J.K. Rowling", 400)
    let book3 = Book("Pan Tadeusz", "Adam Mickiewicz", 300)

    library.AddBook(book1)
    library.AddBook(book2)
    library.AddBook(book3)


    let user = User("Jan Kowalski")

    // uzytkownik wypozycza ksiazki 
    user.BorrowBook(book1)
    user.BorrowBook(book2)

    // ksiazki wypozyczone przez jana
    user.ListBorrowedBooks()

    // jan zwraca ksiazke
    user.ReturnBook(book1)

    // ksiazki wypozyczone przez jana poz wroceniu
    user.ListBorrowedBooks()

    // usunecie z biblioteki 
    library.RemoveBook(book3)

    //ksiazki w bibliotece po usunieciu ksiazki 
    library.ListBooks()

    0 