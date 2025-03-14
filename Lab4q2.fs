open System

type BinaryTree =
    | Nod of int * BinaryTree * BinaryTree
    | Empty

let rec vyv (tree: BinaryTree) lCur tCur lvl=
    match tree with
    | Nod(inf, left, right) -> 
        Console.SetCursorPosition(lCur, tCur)
        printfn "%d" inf
        if left <> Empty then 
            Console.SetCursorPosition(lCur - (5/lvl), tCur+ 1)
            printf "/"
        if right <> Empty then 
            Console.SetCursorPosition(lCur + (5/lvl), tCur+ 1)
            printf "\\"
        vyv left (lCur - (10/lvl)) (tCur + 2) (lvl+1)
        vyv right (lCur + (10/lvl)) (tCur + 2) (lvl+1)
    | Empty -> ()

let rec depth tree d =
    match tree with 
    | Nod(inf, left, right) ->
        let x1 = depth left (d + 1)
        let x2 = depth right (d + 1)
        if x1 > x2 then
            x1
        else x2
    | Empty -> d

let rec addroot tree x =
    match tree with
    | Nod(inf, left, right) ->
        if inf < x then Nod(inf, left, (addroot (right) x))
        else Nod(inf, addroot (left) x, right)
    | Empty -> 
        Nod(x, Empty, Empty)

let rec InInt () =
    let x = Console.ReadLine()
    match Int32.TryParse x with
    | true, int -> Int32.Parse x
    | _ -> printfn "Вы ввели не целое число, попробуйте снова"
           InInt ()

let rec addfew tree n =
    if n > 0 then
        printf"Введите следующее число для добавления в дерево: "
        addfew (addroot tree (InInt())) (n-1)
    else tree

let rec sumEven tree r = 
    match tree with
    | Nod(inf, left, right) -> 
        if (abs)inf % 2 = 0 then
            inf + (sumEven left (r)) + (sumEven right (r))
        else
            (sumEven left (r)) + (sumEven right (r))
    | Empty -> r

let rec sumNotEven tree r = 
    match tree with
    | Nod(inf, left, right) -> 
        if (abs)inf % 2 = 1 then
            inf + (sumNotEven left (r)) + (sumNotEven right (r))
        else
            (sumNotEven left (r)) + (sumNotEven right (r))
    | Empty -> r

printf"Введите количество корней в дереве: "
let tree1 = addfew Empty (InInt())
if tree1 <> Empty then
    printfn"Ваше дерево"
    let x = Console.GetCursorPosition().ToTuple()
    vyv tree1 (10*depth tree1 0) (snd x) 1
    Console.SetCursorPosition (0, (snd x) + 2 * depth tree1 0)
    printfn "Сумма чётных чисел дерева: %d\nСумма нечётных чисел дерева: %d" (sumEven tree1 0) (sumNotEven tree1 0)
    if sumEven tree1 0 > sumNotEven tree1 0 then printf "Сумма чётных чисел больше"
    else printf "Сумма нечётных чисел больше"
else
    printf"Ваше дерево пусто, так как вы ввели не натуральное число"