module File1

open System

//zad1
let countWordsAndChars (text: string) =
    let words = text.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries)
    let charCount = text.Replace(" ", "").Length
    (words.Length, charCount)

//zad2
let isPalindrome (text: string) =
    let cleanedText = text.Replace(" ", "").ToLower()
    cleanedText = String(Array.rev (cleanedText.ToCharArray()))

//zad3
let removeDuplicates (words: string list) =
    words |> List.distinct

//zad4
let changeFormat (input: string) =
    let parts = input.Split(';') |> Array.map (fun x -> x.Trim())
    let firstName = parts.[0]
    let lastName = parts.[1]
    let age = parts.[2]
    sprintf "%s, %s (%s lat)" lastName firstName age

//zad5
let findLongestWord (text: string) =
    let words = text.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries)
    let longestWord = words |> Array.maxBy String.length
    (longestWord, longestWord.Length)

//zad6
let replaceWord (text: string) (oldWord: string) (newWord: string) =
    text.Replace(oldWord, newWord)