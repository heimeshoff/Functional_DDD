module Html

(*#################

    Die UI Ihrer App

    Bitte nach belieben optimieren

#################*)

let combine f s = 
    sprintf "%s%s" f s

let Frame (title : string) (content : string ) = 
    sprintf "
        <html>
        <head>
            <title>%s</title>
        </head>
        <body>
            %s
        </body>
        </html>" title content

let Kunde name = 
    sprintf "<div>%s</div>" name

let Produkte produkte =
    produkte
    |> List.map (fun p -> sprintf "<div>%s</div>" p)
    |> String.concat ""

let Warenkorb_formular = "<br />
        <form method=\"post\" action=\"warenkorb_anlegen\">
            Kunde: <input type=\"text\" name=\"kunde\" /><br />
            <input value=\"Anlegen\" type=\"submit\" />
        </form>"

let Link_Warenkorb = "<a href=\"./warenkorb\">Warenkorb</a>"

