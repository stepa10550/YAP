open System

let rec InInt () =
    let x = Console.ReadLine()
    match Int32.TryParse x with
    | true, int -> Int32.Parse x
    | _ -> printfn "Вы ввели не целое число, попробуйте снова"
           InInt ()

let F x =
    (abs)x % 10

let R1 = seq {
    while true do
        printf "Введите следующее число: "
        yield InInt()
}

let n = Lazy<int>.Create(printf "Введите колличество элементов в списке: "; fun() -> InInt())
let L = lazy Seq.take n.Value R1
if n.Value > 0 then printf "Список последних цифр элементов списка: %A" (Seq.toList (Seq.map (F) L.Value))
else printf "Последовательность не создалась, так как значение не натуральное"