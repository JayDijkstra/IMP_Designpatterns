using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuimteGruis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruis.Obstacles
{
    class Rock : GameObject, ICollidable
    {
        public Rectangle BoundingBox
        {
            get
            {
                return Bounds;
            }
        }

        public int Damage
        {
            get
            {
                return 10;
            }
        }

        public Rock(Vector2 position):base(position)
        {
            Texture = Game1.instance.Content.Load<Texture2D>("block2");
            Position = position;
            Speed = 5f;
        }

        public override void Update()
        {
            Position = new Vector2(Position.X - 1 * Speed, Position.Y );
            base.Update();
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw();
        }

        public void onCollision()
        {
            
        }
    }
}
