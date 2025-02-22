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

(*
printf "Введите повторяющееся число: "
let x = (Console.ReadLine())

printf "Введите колличество чисел: "
let n = (Console.ReadLine())

if isF(y(x)) && isNum(y(n)) then
    printfn "Ваш список"
    printf "%A" (F (float x) ((int) n))
else 
    printf "Вы ввели неверные данные"*)


(*let rec Prod x = 
    if x > 0 then
        Prod (x/10) * (x%10)
    else
        1


 printf "Введите натуральное число: "
let n = (Console.ReadLine())

if isNum(y(n)) then
    printf "Произведение цифр числа = %d" (Prod ((int)n))
else 
    printf "Вы ввели неверные данные"*)

let rec getel (L: float list) (n: int) =
    if n > 0 then
        getel (L.Tail) (n-1)
    else
        L.Head

let rec listlength (L: float list) (r: int) = 
    if L <> [] then
        listlength (L.Tail) (r + 1)
    else
        r


let Addone (L:float list) (x: float) = [
    for i in [0..((listlength(L) 0)- 1)] do
        yield getel L i
    yield x
]

let Addtogeth (L1: float list) (L2: float list) =[
    for i in [0 .. (((listlength(L1) 0)- 1))] do
        yield getel L1 i 
    for i in [0 .. (((listlength(L2) 0)- 1))] do
        yield getel L2 i 
]

let rec tryfind (L: float list) (x: float) (n: int)= 
    if L = [] then
        -1
    else
        if L.Head = x then
            n
        else
            (tryfind (L.Tail) (x) (n+1))

let delel (L: float list) (x: float) = [
    for i in [0..(listlength L 0)-1] do 
        if (getel L i) <> x then
            yield (getel L i)
]

let rec getint(): int = 
    let x = Console.ReadLine()
    if isInt(y(x)) then
        (int)x
    else
        printfn "Вы ввели не натуральное число"
        getint()

let rec getfloat() = 
    let x = Console.ReadLine()
    if isFloat(y(x)) then
        (float)x
    else
        printfn "Вы ввели не действительное число"
        getfloat()

let inList (n: int): float list =[
    for i in [1..n] do
        printf "Введите %d-ое число в спике: " i
        yield getfloat()
    ]

let rec glav (L1: float list) (L2: float list) =
    if L1 <> [] then
        printfn "Список 1: %A" L1
    if L2 <> [] then
        printfn "Список 2: %A" L2
    printfn "Введите что хотите сделать с списками:"
    printfn "0 - закончить выполнение программы"
    printfn "1 - Ввести первый список с заданным количеством чисел"
    printfn "2 - Ввести второй список с заданным количеством чисел"
    printfn "3 - Добавить число в первый список"
    printfn "4 - Добавить число во второй список"
    printfn "5 - Удалить число из первого списка"
    printfn "6 - Удалить число из второго списка"
    printfn "7 - Найти индекс элемента в первом списке"
    printfn "8 - Найти индекс элемента в втором списке"
    printfn "9 - Объединить два списка"
    let n = getint()
    if n = 0 then
        0
    elif n = 1 then
        printf "Введите колличество эдементов: "
        (glav (inList(getint())) L2)
    elif n = 2 then
        printf "Введите колличество эдементов: "
        glav L1 (inList (getint()))
    elif n = 3 then
        printf "Введите число, которое хотите добавить: "
        glav (Addone L1 (getfloat())) L2
    elif n = 4 then 
        printf "Введите число, которое хотите добавить: "
        glav L1 (Addone L2 (getfloat()))
    elif n = 5 then
        printf "Введите элемент, который хотите удалить: "
        glav (delel L1 (getfloat())) L2
    elif n = 6 then
        printf "Введите элемент, который хотите удалить: "
        glav L1 (delel L2 (getfloat()))
    elif n = 7 then
        printf "Введите элемент, номер которого вы хотите найти: "
        let x1 = tryfind L1 (getfloat()) 0
        if x1 = -1 then
            printfn "Введённый элеиент не найден в списке"
        else
            printfn "Элемент находиться под номером %d" x1
        glav L1 L2
    elif n = 8 then
        printf "Введите элемент, номер которого вы хотите найти: "
        let x2 = tryfind L2 (getfloat()) 0
        if x2 = -1 then
            printfn "Введённый элеиент не найден в списке"
        else
            printfn "Элемент находиться под номером %d" x2
        glav L1 L2
    elif n = 9 then
        glav (Addtogeth L1 L2) [] 
    else
        printfn "Вы ввели число не из списка, повторите попытку"
        glav L1 L2


(glav [] [])
