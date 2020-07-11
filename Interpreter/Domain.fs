namespace Interpreter

type idf = string

type binop = Plus | Minus | Times | Div

type stm =
    | CompundStm of stm * stm
    | AssignStm of idf * expr
    | PrintStm of expr list
and expr =
    | IdExp of idf
    | NumExp of int
    | OpExp of expr * binop * expr
    | EseqExp of stm * expr

type env = idf * int list

