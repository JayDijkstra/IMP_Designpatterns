using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RuimteGruis.Obstacles
{
    class Earth : Obstacle
    {
        public Earth(Vector2 position) : base(position)
        {
            Texture = Game1.instance.Content.Load<Texture2D>("earth");
            Speed = 1f;
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
