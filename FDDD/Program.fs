module FDDD_APP

(*#################

    Der Webserver, unendliche Weiten.

#################*)

open System
open System.Net
open Suave
open Suave.Web
open Suave.Http
open Suave.Http.Applicatives
open Suave.Http.Writers
open Suave.Http.Files
open Suave.Http.Successful
open Suave.Types
open Suave.Session
open Suave.Log
System.Net.ServicePointManager.DefaultConnectionLimit <- Int32.MaxValue
open Socket

open WebApplication

// MimeTypes
let mime_types =
  Writers.default_mime_types_map
    >=> (function | ".jpg" -> Writers.mk_mime_type "image/jpeg" false | _ -> None)

let ddd_app : WebPart =
  choose WebApplication.routes

ddd_app
|> web_server
          { bindings =
            [ HttpBinding.Create(HTTP, "127.0.0.1", 8082) ]
          ; error_handler    = default_error_handler
          ; listen_timeout   = TimeSpan.FromMilliseconds 2000.
          ; ct               = Async.DefaultCancellationToken
          ; buffer_size      = 2048
          ; max_ops          = 100
          ; mime_types_map   = mime_types
          ; home_folder      = None
          ; compressed_files_folder = None
          ; logger           = logger
          ; session_provider = new DefaultSessionProvider() }

