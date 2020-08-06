module Ast

type Id = string

type TypeId = string

type BinOp =
    // Arithmatic Operators
    | Plus
    | Minus
    | Times
    | Divide
    // Comparison Operators
    | Eq
    | Ne
    | Gt
    | Ge
    | Lt
    | Le
    // Logical Operators
    | And
    | Or

type LValue =
    | LIdent of Id
    | LRecField of LValue * Id
    | LArrSubscript of LValue * Expr

and Expr =
    | StrLitExpr of string
    | IntLitExpr of int
    | NilExpr
    | UnitExpr
    | LValueExpr of LValue
    | NegExpr of Expr
    | BinExpr of Expr * BinOp * Expr
    | AssignExpr of LValue * Expr
    | CallExpr of Id * Expr list
    | SeqExpr of Expr list
    | RecExpr of TypeId * (Id * Expr) list
    | ArrExpr of TypeId * Expr * Expr
    | CondExpr of Expr * Expr * Expr option
    | WhileExpr of Expr * Expr
    | ForExpr of Id * Expr * Expr * Expr
    | BreakExpr
    | LetExpr of Dec list * Expr

and VarDec =
    | VariableDec of Id * Expr
    | VarWithTypeDec of Id * TypeId * Expr

and TypeDef =
    | TypeAliasDec of TypeId
    | RecordDec of (Id * TypeId) list
    | ArrayDec of TypeId

and TypeDec = TypeDec of TypeId * TypeDef

and FuncDec =
    | FunctionDec of Id * (Id * TypeId) list * Expr
    | FuncWithTypeDec of Id * (Id * TypeId) list * TypeId * Expr

and Dec =
    | TDec of TypeDec
    | VDec of VarDec
    | FDec of FuncDec
