module File3



let countWords (text: string) =
    text.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.length

let countCharsWithoutSpaces (text: string) =
    text.Replace(" ", "")
    |> fun s -> s.Length


let findMostFrequentWord (text: string) =
    text.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun word -> word.ToLower())
    |> Array.groupBy id
    |> Array.maxBy (fun (_, occurrences) -> Array.length occurrences)
    |> fst