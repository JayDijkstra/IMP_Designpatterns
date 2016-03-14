using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RuimteGruis
{
    class Ship : GameObject
    {
        public Ship(Vector2 position) : base(position)
        {
            Texture = Game1.instance.Content.Load<Texture2D>("ship");
            Position = position;
            Speed = 1.5f;
            Health = 100;
        }

      
        public override void Update()
        {
            //Ship Controls
            int controlSpeed = 2;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Position = new Vector2(Position.X, Position.Y  - controlSpeed * Speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Position = new Vector2(Position.X, Position.Y  + controlSpeed * Speed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Position = new Vector2(Position.X - controlSpeed * Speed, Position.Y );
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Position = new Vector2(Position.X + controlSpeed * Speed, Position.Y );
            }
         
            base.Update();
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw();
        }

    }
}
