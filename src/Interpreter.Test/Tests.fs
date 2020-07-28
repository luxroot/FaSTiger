module Tests

open System
open Xunit

open Interpreter


[<Fact>]
let AddTest () =
    let five = Interpreter.NumExp 5
    let seven = Interpreter.NumExp 7
    let expected = 12
    let actual = Interpreter.Semantics.eval [] (Interpreter.OpExp (five, Interpreter.Plus, seven))
    Assert.Equal(actual, expected)
