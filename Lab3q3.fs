open System
open System.IO

let F dir = Array.toList (Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))

let F1 (x: string) = 
    if x[(x.Length-4) .. (x.Length)] = ".txt" then false
    else true

let f x = List.filter (F1) x

let a = f (F "C:\Users\stepa\OneDrive\Desktop\яп")
if a = [] then printf "Файлов отличных от txt в папке нет"
else printf "Пути к файлам в папке, которые не имеют расширение txt:\n %A" a

