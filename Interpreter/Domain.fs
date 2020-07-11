namespace Interpreter

type idf = string

type binop = Plus | Minus | Times | Div

type stm =
    | CompundStm of stm * stm
    | AssignStm of idf * expr
    | OpExp of expr * binop * expr
    | EseqExp of stm * expr
and expr =
    | IdExp of idf
    | NumExp of int
    | OpExp of expr * binop * expr
    | EseqExp of stm * expr

type env = idf * int list

