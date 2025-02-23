open System

let isf (x: char) = 
    match x with
    |'1'|'2'|'3'|'4'|'5'|'6'|'7'|'8'|'9'|'0'|'-'|'+'|'.'-> true
    | _ -> false

let isN (x: char) = 
    match x with
    |'1'|'2'|'3'|'4'|'5'|'6'|'7'|'8'|'9'|'0' -> true
    | _ -> false

let isFloat (x: char list) =
    List.fold (fun a b -> a && b) true (List.map isf x)

let isInt (x: char list) = 
    List.fold (fun a b -> a && b) true (List.map isN x)

let F x n = [    
    for i in [1..n] do
        yield x
]

let y (x: string) = [
    for i in [0..x.Length-1] do
        yield x[i]
]


printf "Введите повторяющееся число: "
let x = (Console.ReadLine())

printf "Введите колличество чисел: "
let n = (Console.ReadLine())

if isFloat(y(x)) && isInt(y(n)) then
    printfn "Ваш список"
    printf "%A" (F (float x) ((int) n))
else 
    printf "Вы ввели неверные данные"