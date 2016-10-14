namespace FDDD

open System
open Domain

(*#################

    Auf Ereignisse reagieren mittels Verhalten oder Projektion von Zuständen

    Aufgaben:
    |_| Verschiedene Readmodels für die unterschiedlichen Belange auslagern
    |_| Automatisiertes Verhalten (Prozessschritte) abbilden

#################*)

type EventHandler() =
    let mutable kunde = ""
    let mutable eintraege = List.empty;

    let warenkorb = function Warenkorb id -> id

    member this.Kunde = kunde

    member this.Eintraege = eintraege

    member this.Handle = 
        function
        | Warenkorb_wurde_angelegt e -> 
            kunde <- e.Kunde
            printfn "Warenkorb %i wurde angelegt für Kunde %s" (warenkorb e.Warenkorb) e.Kunde 
        | Produkt_wurde_in_Warenkorb_gelegt e -> 
            eintraege <- e.Produkt :: eintraege
            printfn "Produkt %s wurde in Warenkorb %i gelegt" e.Produkt (warenkorb e.Warenkorb) 
        | Warenkorb_wurde_bestellt e -> printfn "Warenkorb %i wurde bestellt" (warenkorb e.Warenkorb) 
        | Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt e -> printfn "Vergisse es, ein Warenkorb wurde noch nicht angelegt"
        | Vergiss_es__Warenkorb_ist_leer e -> printfn  "Vergisse es, Warenkorb ist leer"
        