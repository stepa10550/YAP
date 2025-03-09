open System

let rec InInt () =
    let x = Console.ReadLine()
    match Int32.TryParse x with
    | true, int -> Int32.Parse x
    | _ -> printfn "Вы ввели не целое число, попробуйте снова"
           InInt ()

let F x =
    (abs)x % 10

let f (x: int) (y: int) = 
    if x = F(y) then
        y
    else
        0

let R1 = seq {
    while true do
        printf "Введите следующее число: "
        yield InInt()
}

let n = Lazy<int>.Create(printf "Введите колличество элементов в списке: "; fun() -> InInt())
let L = lazy Seq.take n.Value R1
let x = lazy (printf "Введите цифру: "; InInt())
if n.Value > 0 then if x.Value >= 0 && x.Value <= 9 then printf "Сумма чисел, оканчивающихся на заданную цифру: %d" (Seq.fold (+) 0 (Seq.map (f x.Value) L.Value))
                    else printf "Вы ввели не цифру"
else printf "Последовательность не создалась, так как значение не натуральное"
