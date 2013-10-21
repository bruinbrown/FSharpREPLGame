module REPLGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open REPLActor

type Game1 () as this = 
    inherit Game ()

    do this.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(this)
    let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>

    let mutable (actors:Actor list) = []

    let DrawActor (sb:SpriteBatch) actor =
        do sb.Draw(actor.Texture, actor.Position, Color.White)

    member this.Actors
        with get() = actors
        and set(v) = actors <- v

    override this.Initialize() =
        do spriteBatch <- new SpriteBatch(this.GraphicsDevice)
        do base.Initialize ()
        ()

    override this.Draw gameTime = 
        do this.GraphicsDevice.Clear Color.CornflowerBlue
        let DrawActor' = DrawActor spriteBatch
        do spriteBatch.Begin()
        actors
        |> List.iter DrawActor'
        do spriteBatch.End()
        ()

