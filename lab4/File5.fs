module File5
open System

//list 3x3
type Board = char list list

// wyswietla plansze
let printBoard (board: Board) =
    board
    |> List.iter (fun row -> 
        printfn "%s" (String.concat " | " (List.map string row))
        printfn "--------")
    printfn ""


let checkWin (board: Board) (player: char) =
    let rows = board
    let cols = List.transpose board
    let diagonals = [
        [board.[0].[0]; board.[1].[1]; board.[2].[2]];
        [board.[0].[2]; board.[1].[1]; board.[2].[0]]
    ]
    let allLines = rows @ cols @ diagonals
    allLines |> List.exists (fun line -> List.forall (fun x -> x = player) line)


let hasEmptySpaces (board: Board) =
    board |> List.exists (fun row -> row |> List.exists (fun x -> x = ' '))

let checkDraw (board: Board) =
    not (hasEmptySpaces board) && not (checkWin board 'X') && not (checkWin board 'O')



let makeMove (board: Board) (row: int) (col: int) (player: char) =
    if board.[row].[col] = ' ' then
        let newRow = List.mapi (fun i r -> if i = row then List.mapi (fun j c -> if j = col then player else c) r else r) board
        newRow
    else
        printfn "To pole jest już zajęte. Wybierz inne."
        board


let randomMove (board: Board) =
    let emptyCells = 
        [for i in 0..2 do for j in 0..2 do if board.[i].[j] = ' ' then yield (i, j)]
    let rnd = System.Random()
    let randomCell = emptyCells.[rnd.Next(emptyCells.Length)]
    makeMove board (fst randomCell) (snd randomCell) 'O'

// zarzadzanie gra
let rec playGame (board: Board) (player: char) =
    printBoard board

    //czy grasie jzu skonczyla?
    if checkWin board 'X' then
        printfn "Gratulacje! Wygrałeś!"
    elif checkWin board 'O' then
        printfn "Niestety, komputer wygrał."
    elif checkDraw board then
        printfn "Remis!"
    else
        // gracz
        if player = 'X' then
            printfn "Twoja tura (X): Podaj numer wiersza i kolumny (0-2), np. 1 1"
            let input = Console.ReadLine().Split()
            let row, col = int input.[0], int input.[1]
            let newBoard = makeMove board row col player
            playGame newBoard 'O'
        // komputer
        else
            printfn "Tura komputera (O)..."
            let newBoard = randomMove board
            playGame newBoard 'X'

// funkcja uruchamiajaca gre
let startGame () =
    let initialBoard = [
        [' '; ' '; ' '];
        [' '; ' '; ' '];
        [' '; ' '; ' ']
    ]
    playGame initialBoard 'X'

