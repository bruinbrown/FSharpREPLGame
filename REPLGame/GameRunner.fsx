#I @"bin\Debug"
#r @"REPLGame.dll"
#r @"C:\Program Files (x86)\MonoGame\v3.0\Assemblies\WindowsGL\MonoGame.Framework.dll"
#r "WindowsBase"

open REPLActor
open REPLGame
open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open System.Threading

let RunInBackground() =
    let (game:REPLGame.Game1 ref) = ref Unchecked.defaultof<REPLGame.Game1>
    let start() =
        game := new REPLGame.Game1()
        let g = !game
        g.Run()
    let thread = Thread start
    thread.IsBackground <- true
    thread.SetApartmentState ApartmentState.STA
    thread.Start()
    Thread.Sleep(1000)
    !game, thread

let game, thread = RunInBackground()

do game.Content.RootDirectory <- __SOURCE_DIRECTORY__ + @"\bin\Debug\Content"
let Create = CreateActor game.Content
