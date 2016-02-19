#load @"../packages/FSharp.Formatting.2.14.0/FSharp.Formatting.fsx"
open FSharp.Literate
open System.IO

// FSharp.Formatting.fsx loads all the necessary assemblies.
// open FSharp.Literate references the library with all the important functionality.

 
let source = __SOURCE_DIRECTORY__
let template = Path.Combine(source, "template-file.html")
//Then you can use the two static methods to turn single documents into HTML as follows:

  
//let script = Path.Combine(source, "1.fsx")
//Literate.ProcessScriptFile(script, template)

let doc = Path.Combine(source, "_1.md")
Literate.ProcessMarkdown(doc, template)