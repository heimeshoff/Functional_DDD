[<AutoOpen>]
module Modell

(*#################

    Strukturelle Beschreibung des Domänenmodells

#################*)

type Warenkorb = Warenkorb of int



type Command =
    | Lege_Warenkorb_an of Lege_Warenkorb_an
    | Bestelle_Warenkorb of Bestelle_Warenkorb 

and Lege_Warenkorb_an = {
    Warenkorb: Warenkorb
    Kunde: string }

and Bestelle_Warenkorb = {
    Warenkorb: Warenkorb }



// Events
type Event =
    | Warenkorb_wurde_angelegt of Warenkorb_wurde_angelegt
    | Warenkorb_wurde_bestellt of Warenkorb_wurde_bestellt
    | Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt of Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt
    | Vergiss_es__Warenkorb_ist_leer of Vergiss_es__Warenkorb_ist_leer
    | Produkt_wurde_in_Warenkorb_gelegt of Produkt_wurde_in_Warenkorb_gelegt

and Warenkorb_wurde_angelegt = {
    Warenkorb: Warenkorb
    Kunde: string }

and Warenkorb_wurde_bestellt = {
    Warenkorb: Warenkorb }

and Vergiss_es__Warenkorb_wurde_noch_nicht_angelegt = {
    Warenkorb: Warenkorb }

and Vergiss_es__Warenkorb_ist_leer = {
    Warenkorb: Warenkorb }

and Produkt_wurde_in_Warenkorb_gelegt = {
    Warenkorb: Warenkorb 
    Produkt: string }
