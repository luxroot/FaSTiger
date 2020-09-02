module Symbol

open System.Collections.Generic

type Symbol = string * int

let private nextSym = ref 0
let private symbolDict = Dictionary<string,int> ()

let name (x:Symbol) = fst x

let symbol name =
    if symbolDict.ContainsKey name then
        Symbol (name, symbolDict.[name])
    else
        symbolDict.Add (name, !nextSym)
        nextSym := !nextSym + 1
        (name, !nextSym - 1)

(* From now is about Symbol Table *)

type Table<'a> = Map<int, 'a>

let empty<'a> = Map.empty<int, 'a>

let lookup (tbl:Table<'a>) sym = tbl.TryFind (snd sym)

let enter (tbl:Table<'a>) sym v = Map.add (snd sym) v tbl


let enterAll (tbl:Table<'a>) entries =
    List.fold (fun t e -> enter t (fst e) (snd e)) tbl entries


