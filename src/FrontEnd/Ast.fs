module Ast

open Symbol

type Pos = int * int

type BinOp =
    // Arithmatic Operators
    | PlusOp
    | MinusOp
    | TimesOp
    | DivideOp
    // Comparison Operators
    | EqOp
    | NeOp
    | GtOp
    | GeOp
    | LtOp
    | LeOp

type Var =
    | SimpleVar of Symbol * Pos
    | FieldVar of Var * Symbol * Pos
    | SubscriptVar of Var * Expr * Pos

and Expr =
    | VarExpr of Var
    | NilExpr
    | UnitExpr
    | IntExpr of int
    | StringExpr of string * Pos
    | CallExpr of CallRec
    | OpExpr of OpRec
    | RecordExpr of RecordRec
    | SeqExpr of (Expr * Pos) list
    | AssignExpr of AssignRec
    | IfExpr of IfRec
    | WhileExpr of WhileRec
    | ForExpr of ForRec
    | BreakExpr of Pos
    | LetExpr of LetRec
    | ArrayExpr of ArrayRec

and Dec =
    | FunctionDec of FuncDecRec list
    | VarDec of VarDecRec
    | TypeDec of TypeDecRec

and Type =
    | NameTy of Symbol * Pos
    | RecordTy of FieldRec list
    | ArrayTy of Symbol * Pos

and CallRec = { func: Symbol; args: Expr list; pos: Pos }
and OpRec = { left: Expr; oper: BinOp; right: Expr; pos: Pos }
and RecordRec = { fields: (Symbol * Expr * Pos) list; typ: Symbol; pos: Pos }
and SeqRec = (Expr * Pos) list
and AssignRec = { var: Var; exp: Expr; pos: Pos }
and IfRec = { test: Expr; then': Expr; else': Expr option; pos: Pos }
and WhileRec = { test: Expr; body: Expr; pos: Pos }
and ForRec = { var: Symbol; escape: bool ref; lo: Expr; hi: Expr; body: Expr; pos: Pos }
and LetRec = { decs: Dec list; body: Expr; pos: Pos }
and ArrayRec = { typ: Symbol; size: Expr; init: Expr; pos: Pos }

and FieldRec = { name: Symbol; escape: bool ref; typ: Symbol; pos: Pos }
and FunDecRec = { name: Symbol; params: FieldRec list; result: (Symbol * Pos) option; body: Expr; pos: Pos }
and VarDecRec = { name: Symbol; escape: bool ref; typ: (Symbol * Pos) option; init: Expr; pos: Pos }
and TypeDecRec = { name: Symbol; ty: Type; pos: Pos }
