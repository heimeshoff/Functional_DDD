[<AutoOpen>]
module PrettyPrint
open Domain

let print =
    function
    | Warenkorb(i) -> sprintf "%i" i
    
let warenkorb = function Warenkorb id -> id

let printEvent (event: Event) =
    match event with
    | Warenkorb_wurde_angelegt e -> sprintf "Warenkorb %s wurde angelegt für Kunde %s" (print e.Warenkorb) e.Kunde
    | Warenkorb_wurde_bestellt e -> sprintf "Warenkorb %s wurde bestellt" (print e.Warenkorb)
    | Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt e -> sprintf "Vergisse es, ein Warenkorb wurde noch nicht angelegt"
    | Vergiss_es__Warenkorb_ist_leer e -> sprintf "Vergisse es, Warenkorb ist leer"

let printCommand (command: Command) =
    match command with
    | Lege_Warenkorb_an c -> sprintf "Lege Warenkorb %s für Kunden %s an" (print c.Warenkorb) c.Kunde
    | Bestelle_Warenkorb c -> sprintf "Bestelle Warenkorb %s" (print c.Warenkorb)

let printGiven events =
    printfn "Given"
    events
    |> List.map printEvent
    |> List.iter (printfn "\t%s")

let printWhen command =
    printfn "When"
    command |> printCommand  |> printfn "\t%s"

let printExpect events =
    printfn "Expect"
    events
    |> List.map printEvent
    |> List.iter (printfn "\t%s")

let printExpectThrows ex =
    printfn "Expect"
    printfn "\t%A" ex