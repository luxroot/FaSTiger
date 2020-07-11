module Tests

open System
open Xunit

open Interpreter

[<Fact>]
let ``My test`` () =
    let expected = "Hello abc"
    let actual = Say.hello "abcd"
    Assert.Equal(expected, actual)
