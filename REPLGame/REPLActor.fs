module REPLActor

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics

type Actor =
    {
        Texture : Texture2D;
        Position : Vector2
    }

let CreateActor (content:ContentManager) fileName position =
    let t = content.Load<Texture2D> fileName
    { Texture = t; Position = position }