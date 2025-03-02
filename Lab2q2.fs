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

let rec getint(): int = 
    let x = Console.ReadLine()
    if isInt(y(x)) then
        (int)x
    else
        printfn "Вы ввели не натуральное число"
        getint()

let inList (n: int): int list =[
    for i in [1..n] do
        printf "Введите %d-ое число в спике: " i
        yield getint()
    ]

let F x =
    x % 10

let f (x: int) (y: int) = 
    if x = F(y) then
        y
    else
        0

let R = 
    seq {
        let a = new Random()
        while true do
            yield a.Next() % 101
    }

let rec InL n =
    printfn "Нажимте 1, если вы хотите ввести элементы вручную"
    printfn "Нажмите 2, если вы заполнить элементы случайным образом"
    match Console.ReadLine() with
    | "1" -> printfn "Введите элементы списка: "
             inList(n)
    | "2" -> Seq.toList (Seq.take n R)
    | _ -> printf "Вы ввели не верные значения"
           InL n

printf "Введите колличество элементов в списке: "
let n = getint()
let L = InL n
printfn "Список элементов %A" L
printf "Введите цифру: "
let x = getint()
printfn "Сумма чисел, оканчивающихся на заданное число: %d" (List.fold (+) 0 (List.map (f x) L))
