open System

type BinaryTree =
    | Nod of string * BinaryTree * BinaryTree
    | Empty

let rec vyv (tree: BinaryTree) lCur tCur lvl=
    match tree with
    | Nod(inf, left, right) -> 
        Console.SetCursorPosition(lCur, tCur)
        printfn "%s" inf
        if left <> Empty then 
            Console.SetCursorPosition(lCur- (5/lvl), tCur+ 1)
            printf "/"
        if right <> Empty then 
            Console.SetCursorPosition(lCur+inf.Length + (5/lvl), tCur+ 1)
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

let rec isInAlf (x: string) (y: string) (n: int) =
    if (x.Length - n) = 0 then true
    elif (y.Length - n)= 0 then false
    elif x[n] < y[n] then true
    elif x[n] > y[n] then false
    else isInAlf x y (n + 1)

let rec addroot tree x =
    match tree with
    | Nod(inf, left, right) ->
        if (isInAlf inf x 0) then Nod(inf, left, (addroot (right) x))
        else Nod(inf, addroot (left) x, right)
    | Empty -> 
        Nod(x, Empty, Empty)

let rec addfew tree n =
    if n > 0 then
        printf"Введите следующую строку для добавления в дерево: "
        let a = addroot tree (Console.ReadLine())
        addfew a (n-1)
    else tree

let rec InInt () =
    let x = Console.ReadLine()
    match Int32.TryParse x with
    | true, int -> Int32.Parse x
    | _ -> printfn "Вы ввели не целое число, попробуйте снова"
           InInt ()

let rec InChar () =
    printf"Введите символ: "
    let x = Console.ReadLine()
    if x.Length > 1 then
        printfn "Вы ввели множество символов"
        InChar ()
    else x

let rec addChar tree x =
    match tree with 
    | Nod(inf, left, right) -> Nod(x + inf, addChar left x, addChar right x)
    | Empty -> Empty


printf"Введите количество корней в дереве: "
let tree1 = addfew Empty (InInt())
let x = Console.GetCursorPosition().ToTuple()
printfn"Ваше дерево"
vyv tree1 (10*depth tree1 0) (snd x) 1
Console.SetCursorPosition (0, (snd x) + 2 * depth tree1 0)
let y = Console.GetCursorPosition().ToTuple()
vyv (addChar tree1 (InChar())) (10*depth tree1 0) (snd y) 1
Console.SetCursorPosition (0, (snd y) + 2 * depth tree1 0)