module FDDD.Tests.``Benutzung des Warenkorbs``

(*#################

    Spezifikationen zum Warenkorb

    Aufgaben:
    |_| Die bestehenden Spezifikationen erfüllen
    |_| Weitere notwendige Spezifikationen erarbeiten und Testgetrieben implmentieren
    |_| Lagerverwaltung ebenfalls nach diesen Vorgaben implementieren

#################*)

open Xunit
open System
open Domain


[<Fact>]
let ``Angelegter Warenkorb ist angelegt``() =
    Given []
    |> When ( Lege_Warenkorb_an { Warenkorb = Warenkorb 1; Kunde = "Marco" })
    |> Expect [ 
         Warenkorb_wurde_angelegt { Warenkorb = Warenkorb 1; Kunde = "Marco" } ]

[<Fact>]
let ``Ein nicht angelegter Warenkorb kann nicht bestellt werden``() =
    Given []
    |> When ( Bestelle_Warenkorb { Warenkorb = Warenkorb 1 } )
    |> Expect [ 
         Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt { Warenkorb = Warenkorb 1 } ]

[<Fact>]
let ``Ein leerer Warenkorb kann nicht bestellt werden``() =
    Given [Warenkorb_wurde_angelegt{ Warenkorb = Warenkorb 1; Kunde = "Marco" } ]
    |> When ( Bestelle_Warenkorb { Warenkorb = Warenkorb 1 } )
    |> Expect [ 
         Vergiss_es__Warenkorb_ist_leer { Warenkorb = Warenkorb 1 } ]
