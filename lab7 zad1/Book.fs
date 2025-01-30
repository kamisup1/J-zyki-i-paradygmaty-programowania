module Book

type Book (title: string, author: string, pages: int) =
    member this.Title = title
    member this.Author = author
    member this.Pages = pages

    member this.GetInfo() = 
        sprintf "Tytul: %s, Autor %s, Licba stron %d" this.Title this.Author this.Pages
