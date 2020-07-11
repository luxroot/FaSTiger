namespace Interpreter


module Semantics =
    let extend_env env idf value =
        (idf, value) :: env

    let rec apply_env env idf =
        match env with
        | (x,v) :: tl ->
            if x = idf then v else apply_env tl idf
        | _ -> failwith "Undefined idf of " + idf

    let rec eval env expr =
        match expr with
        | IdExp idf -> apply_env env idf
        | NumExp x -> x
        | OpExp e1, binop, e2 ->
            let v1 = eval env e1
            let v2 = eval env e2
            ( match binop with
            | Plus -> v1 + v2
            | Minus -> v1 - v2
            | Times -> v1 * v2
            | Div -> v1 / v2 )
    //    | EseqExp stm, expr ->
     //       let new_env = run_statement env stm
       //     eval new_env expr

