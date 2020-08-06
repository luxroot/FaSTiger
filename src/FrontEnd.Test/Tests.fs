module Tests

open System
open Xunit
open FSharp.Text.Lexing

[<Fact>]
let ``My test`` () =
    let txt = "1 * 3 + 2"
    let buf = LexBuffer<char>.FromString txt
    let ast = Parser.start Lexer.token buf
    printfn "%A" ast
    Assert.True(true)
