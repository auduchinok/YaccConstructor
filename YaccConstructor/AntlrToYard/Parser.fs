// Implementation file for parser generated by fsyacc
module AntlrToYard.Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Yard.Core.IL
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "Parser.fsy"


open Yard.Core.IL.Production

(* Run with fsyacc.exe --module AntlrToYard.Parser --open Yard.Core.IL Parser.fsy *)


(*
Expr: ID { Val($1) }
     | INT {  Int($1)  }
     | FLOAT {  Float($1)  }
     | DECR LPAREN Expr RPAREN {  Decr($3)  }


 Stmt: ID ASSIGN Expr { Assign($1,$3) }
     | WHILE Expr DO Stmt { While($2,$4) }
     | BEGIN StmtList END { Seq(List.rev($2)) }
     | IF Expr THEN Stmt { IfThen($2,$4) }
     | IF Expr THEN Stmt ELSE Stmt { IfThenElse($2,$4,$6) }
     | PRINT Expr { Print($2) }


 StmtList: Stmt { [$1] }
        | StmtList SEMI Stmt { $3 :: $1  } asdfasdf

*)

let makeModifiedRule innerProduction modifier =
    match modifier with
    | "+" -> PSome(innerProduction)
    | "*" -> PMany(innerProduction)
    | "?" -> POpt(innerProduction)
    | "!" -> innerProduction // TODO ???
    | "" -> innerProduction

let makePSeq productionList =
    PSeq( List.map (fun prod -> {omit = false; rule = prod; binding = None; checker = None;}) productionList , None )

# 46 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | DOUBLE_DOT
  | TILDE
  | EXCLAMATION
  | QUESTION
  | SEMICOLON
  | COLON
  | PLUS
  | STAR
  | EQUAL
  | BAR
  | RPAREN
  | LPAREN
  | LITERAL of (Source.t)
  | IDENTIFIER of (Source.t)
  | T_OPTIONS
  | T_GRAMMAR
  | EOF
  | ACTION_CODE of (Source.t)
  | ACTION_NAME of (Source.t)
  | SCOPE_NAME of (Source.t)
  | SINGLELINE_COMMENT of (Source.t)
  | MULTILINE_COMMENT of (Source.t)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_DOUBLE_DOT
    | TOKEN_TILDE
    | TOKEN_EXCLAMATION
    | TOKEN_QUESTION
    | TOKEN_SEMICOLON
    | TOKEN_COLON
    | TOKEN_PLUS
    | TOKEN_STAR
    | TOKEN_EQUAL
    | TOKEN_BAR
    | TOKEN_RPAREN
    | TOKEN_LPAREN
    | TOKEN_LITERAL
    | TOKEN_IDENTIFIER
    | TOKEN_T_OPTIONS
    | TOKEN_T_GRAMMAR
    | TOKEN_EOF
    | TOKEN_ACTION_CODE
    | TOKEN_ACTION_NAME
    | TOKEN_SCOPE_NAME
    | TOKEN_SINGLELINE_COMMENT
    | TOKEN_MULTILINE_COMMENT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startParseAntlr
    | NONTERM_ParseAntlr
    | NONTERM_Rules
    | NONTERM_Rule
    | NONTERM_Options
    | NONTERM_RuleBody
    | NONTERM_Alt
    | NONTERM_Seq
    | NONTERM_Modifier
    | NONTERM_RulePart

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | DOUBLE_DOT  -> 0 
  | TILDE  -> 1 
  | EXCLAMATION  -> 2 
  | QUESTION  -> 3 
  | SEMICOLON  -> 4 
  | COLON  -> 5 
  | PLUS  -> 6 
  | STAR  -> 7 
  | EQUAL  -> 8 
  | BAR  -> 9 
  | RPAREN  -> 10 
  | LPAREN  -> 11 
  | LITERAL _ -> 12 
  | IDENTIFIER _ -> 13 
  | T_OPTIONS  -> 14 
  | T_GRAMMAR  -> 15 
  | EOF  -> 16 
  | ACTION_CODE _ -> 17 
  | ACTION_NAME _ -> 18 
  | SCOPE_NAME _ -> 19 
  | SINGLELINE_COMMENT _ -> 20 
  | MULTILINE_COMMENT _ -> 21 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_DOUBLE_DOT 
  | 1 -> TOKEN_TILDE 
  | 2 -> TOKEN_EXCLAMATION 
  | 3 -> TOKEN_QUESTION 
  | 4 -> TOKEN_SEMICOLON 
  | 5 -> TOKEN_COLON 
  | 6 -> TOKEN_PLUS 
  | 7 -> TOKEN_STAR 
  | 8 -> TOKEN_EQUAL 
  | 9 -> TOKEN_BAR 
  | 10 -> TOKEN_RPAREN 
  | 11 -> TOKEN_LPAREN 
  | 12 -> TOKEN_LITERAL 
  | 13 -> TOKEN_IDENTIFIER 
  | 14 -> TOKEN_T_OPTIONS 
  | 15 -> TOKEN_T_GRAMMAR 
  | 16 -> TOKEN_EOF 
  | 17 -> TOKEN_ACTION_CODE 
  | 18 -> TOKEN_ACTION_NAME 
  | 19 -> TOKEN_SCOPE_NAME 
  | 20 -> TOKEN_SINGLELINE_COMMENT 
  | 21 -> TOKEN_MULTILINE_COMMENT 
  | 24 -> TOKEN_end_of_input
  | 22 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startParseAntlr 
    | 1 -> NONTERM_ParseAntlr 
    | 2 -> NONTERM_Rules 
    | 3 -> NONTERM_Rules 
    | 4 -> NONTERM_Rule 
    | 5 -> NONTERM_Options 
    | 6 -> NONTERM_Options 
    | 7 -> NONTERM_RuleBody 
    | 8 -> NONTERM_RuleBody 
    | 9 -> NONTERM_Alt 
    | 10 -> NONTERM_Alt 
    | 11 -> NONTERM_Seq 
    | 12 -> NONTERM_Seq 
    | 13 -> NONTERM_Modifier 
    | 14 -> NONTERM_Modifier 
    | 15 -> NONTERM_Modifier 
    | 16 -> NONTERM_Modifier 
    | 17 -> NONTERM_Modifier 
    | 18 -> NONTERM_RulePart 
    | 19 -> NONTERM_RulePart 
    | 20 -> NONTERM_RulePart 
    | 21 -> NONTERM_RulePart 
    | 22 -> NONTERM_RulePart 
    | 23 -> NONTERM_RulePart 
    | 24 -> NONTERM_RulePart 
    | 25 -> NONTERM_RulePart 
    | 26 -> NONTERM_RulePart 
    | 27 -> NONTERM_RulePart 
    | 28 -> NONTERM_RulePart 
    | 29 -> NONTERM_RulePart 
    | 30 -> NONTERM_RulePart 
    | 31 -> NONTERM_RulePart 
    | 32 -> NONTERM_RulePart 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 24 
let _fsyacc_tagOfErrorTerminal = 22

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | DOUBLE_DOT  -> "DOUBLE_DOT" 
  | TILDE  -> "TILDE" 
  | EXCLAMATION  -> "EXCLAMATION" 
  | QUESTION  -> "QUESTION" 
  | SEMICOLON  -> "SEMICOLON" 
  | COLON  -> "COLON" 
  | PLUS  -> "PLUS" 
  | STAR  -> "STAR" 
  | EQUAL  -> "EQUAL" 
  | BAR  -> "BAR" 
  | RPAREN  -> "RPAREN" 
  | LPAREN  -> "LPAREN" 
  | LITERAL _ -> "LITERAL" 
  | IDENTIFIER _ -> "IDENTIFIER" 
  | T_OPTIONS  -> "T_OPTIONS" 
  | T_GRAMMAR  -> "T_GRAMMAR" 
  | EOF  -> "EOF" 
  | ACTION_CODE _ -> "ACTION_CODE" 
  | ACTION_NAME _ -> "ACTION_NAME" 
  | SCOPE_NAME _ -> "SCOPE_NAME" 
  | SINGLELINE_COMMENT _ -> "SINGLELINE_COMMENT" 
  | MULTILINE_COMMENT _ -> "MULTILINE_COMMENT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | DOUBLE_DOT  -> (null : System.Object) 
  | TILDE  -> (null : System.Object) 
  | EXCLAMATION  -> (null : System.Object) 
  | QUESTION  -> (null : System.Object) 
  | SEMICOLON  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | STAR  -> (null : System.Object) 
  | EQUAL  -> (null : System.Object) 
  | BAR  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | LITERAL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | IDENTIFIER _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | T_OPTIONS  -> (null : System.Object) 
  | T_GRAMMAR  -> (null : System.Object) 
  | EOF  -> (null : System.Object) 
  | ACTION_CODE _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ACTION_NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | SCOPE_NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | SINGLELINE_COMMENT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | MULTILINE_COMMENT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 1us; 65535us; 0us; 2us; 2us; 65535us; 0us; 4us; 2us; 5us; 1us; 65535us; 6us; 7us; 2us; 65535us; 8us; 9us; 19us; 14us; 3us; 65535us; 8us; 13us; 15us; 16us; 19us; 13us; 5us; 65535us; 8us; 17us; 13us; 18us; 15us; 17us; 16us; 18us; 19us; 17us; 2us; 65535us; 20us; 21us; 22us; 23us; 0us; 65535us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 5us; 8us; 10us; 13us; 17us; 23us; 26us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 2us; 1us; 3us; 1us; 1us; 1us; 2us; 1us; 3us; 1us; 4us; 1us; 4us; 1us; 4us; 2us; 4us; 8us; 1us; 4us; 1us; 6us; 1us; 6us; 2us; 7us; 10us; 2us; 8us; 11us; 1us; 8us; 2us; 8us; 10us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 11us; 1us; 11us; 1us; 12us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 7us; 9us; 11us; 13us; 15us; 17us; 19us; 22us; 24us; 26us; 28us; 31us; 34us; 36us; 39us; 41us; 43us; 45us; 47us; 49us; 51us; 53us; 55us; 57us; 59us; |]
let _fsyacc_action_rows = 28
let _fsyacc_actionTableElements = [|1us; 32768us; 13us; 6us; 0us; 49152us; 2us; 32768us; 13us; 6us; 16us; 3us; 0us; 16385us; 0us; 16386us; 0us; 16387us; 1us; 16389us; 14us; 11us; 1us; 32768us; 5us; 8us; 2us; 32768us; 11us; 19us; 13us; 22us; 2us; 32768us; 4us; 10us; 9us; 15us; 0us; 16388us; 1us; 32768us; 17us; 12us; 0us; 16390us; 2us; 16391us; 11us; 19us; 13us; 22us; 2us; 32768us; 9us; 15us; 10us; 20us; 2us; 32768us; 11us; 19us; 13us; 22us; 2us; 16392us; 11us; 19us; 13us; 22us; 0us; 16393us; 0us; 16394us; 2us; 32768us; 11us; 19us; 13us; 22us; 4us; 16401us; 2us; 27us; 3us; 26us; 6us; 24us; 7us; 25us; 0us; 16395us; 4us; 16401us; 2us; 27us; 3us; 26us; 6us; 24us; 7us; 25us; 0us; 16396us; 0us; 16397us; 0us; 16398us; 0us; 16399us; 0us; 16400us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 2us; 3us; 6us; 7us; 8us; 9us; 11us; 13us; 16us; 19us; 20us; 22us; 23us; 26us; 29us; 32us; 35us; 36us; 37us; 40us; 45us; 46us; 51us; 52us; 53us; 54us; 55us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 2us; 5us; 0us; 2us; 1us; 3us; 1us; 2us; 4us; 2us; 1us; 1us; 1us; 1us; 0us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 4us; 4us; 5us; 5us; 6us; 6us; 7us; 7us; 8us; 8us; 8us; 8us; 8us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; 9us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 16386us; 16387us; 65535us; 65535us; 65535us; 65535us; 16388us; 65535us; 16390us; 65535us; 65535us; 65535us; 65535us; 16393us; 16394us; 65535us; 65535us; 16395us; 65535us; 16396us; 16397us; 16398us; 16399us; 16400us; |]
let _fsyacc_reductions ()  =    [| 
# 268 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : (Source.t, Source.t)Grammar.t)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startParseAntlr));
# 277 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Rules)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "Parser.fsy"
                                             _1 
                   )
# 71 "Parser.fsy"
                 : (Source.t, Source.t)Grammar.t));
# 288 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Rule)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "Parser.fsy"
                                   [_1] 
                   )
# 73 "Parser.fsy"
                 : 'Rules));
# 299 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Rules)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Rule)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 74 "Parser.fsy"
                                        _2 :: _1 
                   )
# 74 "Parser.fsy"
                 : 'Rules));
# 311 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Options)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'RuleBody)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "Parser.fsy"
                                                                         { new Rule.t<Source.t, Source.t> with name = fst(_1) and args = [] and body = _4 and _public = false and metaArgs = [] } 
                   )
# 76 "Parser.fsy"
                 : 'Rule));
# 324 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "Parser.fsy"
                               
                   )
# 78 "Parser.fsy"
                 : 'Options));
# 334 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "Parser.fsy"
                                                          
                   )
# 78 "Parser.fsy"
                 : 'Options));
# 345 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Alt)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 "Parser.fsy"
                                     makePSeq (_1) 
                   )
# 80 "Parser.fsy"
                 : 'RuleBody));
# 356 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'RuleBody)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Alt)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 80 "Parser.fsy"
                                                                          PAlt(_1, makePSeq (_3)) 
                   )
# 80 "Parser.fsy"
                 : 'RuleBody));
# 368 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Seq)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "Parser.fsy"
                                [_1] 
                   )
# 82 "Parser.fsy"
                 : 'Alt));
# 379 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Alt)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Seq)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "Parser.fsy"
                                                   _2 :: _1 
                   )
# 82 "Parser.fsy"
                 : 'Alt));
# 391 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'RuleBody)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'Modifier)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 84 "Parser.fsy"
                                                            makeModifiedRule _2 _4 
                   )
# 84 "Parser.fsy"
                 : 'Seq));
# 403 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Modifier)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 85 "Parser.fsy"
                                                 makeModifiedRule (PToken(_1)) _2 
                   )
# 85 "Parser.fsy"
                 : 'Seq));
# 415 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 87 "Parser.fsy"
                                      "+" 
                   )
# 87 "Parser.fsy"
                 : 'Modifier));
# 425 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 88 "Parser.fsy"
                                  "*" 
                   )
# 88 "Parser.fsy"
                 : 'Modifier));
# 435 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 89 "Parser.fsy"
                                      "?" 
                   )
# 89 "Parser.fsy"
                 : 'Modifier));
# 445 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 90 "Parser.fsy"
                                         "!" 
                   )
# 90 "Parser.fsy"
                 : 'Modifier));
# 455 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 91 "Parser.fsy"
                             "" 
                   )
# 91 "Parser.fsy"
                 : 'Modifier));
# 465 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 94 "Parser.fsy"
                                   
                   )
# 94 "Parser.fsy"
                 : 'RulePart));
# 475 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 95 "Parser.fsy"
                                
                   )
# 95 "Parser.fsy"
                 : 'RulePart));
# 485 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "Parser.fsy"
                                   
                   )
# 96 "Parser.fsy"
                 : 'RulePart));
# 495 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 97 "Parser.fsy"
                                      
                   )
# 97 "Parser.fsy"
                 : 'RulePart));
# 505 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 98 "Parser.fsy"
                               
                   )
# 98 "Parser.fsy"
                 : 'RulePart));
# 515 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 99 "Parser.fsy"
                               
                   )
# 99 "Parser.fsy"
                 : 'RulePart));
# 525 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 100 "Parser.fsy"
                                
                   )
# 100 "Parser.fsy"
                 : 'RulePart));
# 535 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 101 "Parser.fsy"
                              
                   )
# 101 "Parser.fsy"
                 : 'RulePart));
# 545 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 102 "Parser.fsy"
                                 
                   )
# 102 "Parser.fsy"
                 : 'RulePart));
# 555 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 103 "Parser.fsy"
                                 
                   )
# 103 "Parser.fsy"
                 : 'RulePart));
# 565 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 104 "Parser.fsy"
                                  
                   )
# 104 "Parser.fsy"
                 : 'RulePart));
# 576 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 105 "Parser.fsy"
                                     
                   )
# 105 "Parser.fsy"
                 : 'RulePart));
# 587 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 106 "Parser.fsy"
                                      
                   )
# 106 "Parser.fsy"
                 : 'RulePart));
# 598 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 107 "Parser.fsy"
                                      
                   )
# 107 "Parser.fsy"
                 : 'RulePart));
# 609 "Parser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Source.t)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 108 "Parser.fsy"
                                     
                   )
# 108 "Parser.fsy"
                 : 'RulePart));
|]
# 621 "Parser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 25;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let ParseAntlr lexer lexbuf : (Source.t, Source.t)Grammar.t =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
