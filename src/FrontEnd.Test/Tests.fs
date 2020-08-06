module Tests

open System
open Xunit
open FSharp.Text.Lexing

[<Fact>]
let ``My test`` () =
    let txt = """
    "\065BC\068\naB\"\""
    """
    let buf = LexBuffer<char>.FromString txt
    let ast = Parser.start Lexer.token buf
    printfn "%A" ast
    Assert.True(true)
