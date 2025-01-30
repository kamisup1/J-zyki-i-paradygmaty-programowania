module File1

open System


type UserData = { Weight: float; Height: float }


let calculateBMI (user: UserData) =
    let heightInMeters = user.Height / 100.0
    user.Weight / (heightInMeters ** 2.0)


let categorizeBMI bmi =
    match bmi with
    | x when x < 16.0 -> "Wygłodzenie"
    | x when x >= 16.0 && x < 17.0 -> "Wychudzenie"
    | x when x >= 17.0 && x < 18.5 -> "Niedowaga"
    | x when x >= 18.5 && x < 25.0 -> "Prawidłowa waga"
    | x when x >= 25.0 && x < 30.0 -> "Nadwaga"
    | x when x >= 30.0 && x < 35.0 -> "Otyłość I stopnia"
    | x when x >= 35.0 && x < 40.0 -> "Otyłość II stopnia"
    | _ -> "Otyłość III stopnia"


let getUserData () =
    printf "Podaj swoją wagę (kg): "
    let weight = Console.ReadLine() |> float
    printf "Podaj swój wzrost (cm): "
    let height = Console.ReadLine() |> float
    { Weight = weight; Height = height }