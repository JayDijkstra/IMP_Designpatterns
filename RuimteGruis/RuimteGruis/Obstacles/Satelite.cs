using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruis.Obstacles
{
    class Satelite : Obstacle
    {
        public Satelite(Vector2 position) : base(position)
        {
            Texture = Game1.instance.Content.Load<Texture2D>("satellite");
            Position = position;
            Speed = 3f;
        }

        public override void Update()
        {
            Position = new Vector2(Position.X - 1 * Speed, Position.Y);
            base.Update();
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw();
        }
    }
}
