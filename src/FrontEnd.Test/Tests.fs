module Tests

open System
open Xunit
open FSharp.Text.Lexing

[<Fact>]
let ``My test`` () =
    let txt = """
let

/* calculate n! */
function nfactor(n: int): int =
		if  n = 0
			then 1
			else n * nfactor(n-1)

in
	nfactor(10)
end
    """
    let buf = LexBuffer<char>.FromString txt
    let ast = Parser.start Lexer.token buf
    printfn "%A" ast
    Assert.True(true)
