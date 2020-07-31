module Token

type token =
    | EOF
    | ARRAY
    | BREAK
    | DO
    | ELSE
    | END
    | FOR
    | FUNCTION
    | IF
    | IN
    | LET
    | NIL
    | OF
    | THEN
    | TO
    | TYPE
    | VAR
    | WHILE
    | INTCONST of System.Int32
    | STRCONST of string
    | ID of string
    | COMMA
    | COLON
    | SEMICOLON
    | LPAREN
    | RPAREN
    | LBRACKET
    | RBRACKET
    | LBRACE
    | RBRACE
    | DOT
    | PLUS
    | MINUS
    | ASTERISK
    | DIV
    | EQ
    | NE
    | LT
    | LE
    | GT
    | GE
    | AND
    | OR
    | ASSIGN
    | INT
    | STRING
