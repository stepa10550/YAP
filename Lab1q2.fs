open System

let isN (x: char) = 
    match x with
    |'1'|'2'|'3'|'4'|'5'|'6'|'7'|'8'|'9'|'0' -> true
    | _ -> false

let isInt (x: char list) = 
    List.fold (fun a b -> a && b) true (List.map isN x)

let y (x: string) = [
    for i in [0..x.Length-1] do
        yield x[i]
]

let rec Prod x = 
    if x > 0 then
        Prod (x/10) * (x%10)
    else
        1


printf "Введите натуральное число: "
let n = (Console.ReadLine())

if isInt(y(n)) then
    printf "Произведение цифр числа = %d" (Prod ((int)n))
else 
    printf "Вы ввели неверные данные"
