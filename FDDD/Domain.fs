module Domain

open Modell

(*#################

    Das fachliche Verhalten der Domäne
    
    Aufgaben: 
    |_| Unvollständige Pattern Matches beseitigen

    Viel Spaß und Erfolg, und nicht vergessen die Spezifikationen zu testen

#################*)

// State
type State = {
    Warenkorb: Warenkorb option 
    Warenkorb_offen: bool
    Kunde: string option 
    Errored: bool }
    with
    static member initial = {
        Warenkorb = None
        Warenkorb_offen = false
        Kunde = None
        Errored = false }


// Verhalten
let warenkorb_anlegen (command: Lege_Warenkorb_an) state =
    [ Warenkorb_wurde_angelegt { 
        Warenkorb = command.Warenkorb
        Kunde = command.Kunde }; ]

let warenkorb_bestellen (command: Bestelle_Warenkorb) state =
    match state.Warenkorb with
    | Some w -> [ Warenkorb_wurde_bestellt { Warenkorb = command.Warenkorb } ]
    | _ -> [ Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt { Warenkorb = command.Warenkorb }]

// Mapping von Commands auf Verhalten
let handle =
    function
    | Lege_Warenkorb_an command -> warenkorb_anlegen command
    | Bestelle_Warenkorb command -> warenkorb_bestellen command
    
    
// Projesziert den State aus der Historie
let evolve state =
    function
    | Warenkorb_wurde_angelegt e ->
        { Warenkorb = Some e.Warenkorb
          Warenkorb_offen = true
          Kunde = Some e.Kunde 
          Errored = false }

    | Warenkorb_wurde_bestellt e ->
        { state with
            Warenkorb_offen = false }
    
    | Vergiss_es__Warenkorb_ist_leer e -> 
        { state with 
            Errored = true }
    
    | Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt e ->  
        { state with 
            Errored = true }