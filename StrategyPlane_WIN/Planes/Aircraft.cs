using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StrategyPlane
{
    public class Aircraft
    {
        public Vector2 Direction;
        public Vector2 Velocity;
        public Vector2 Position;
        public float Rotation;
        public Texture2D Texture { get; set; }
        public Boolean FacedRight { get; set; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width,
                    Texture.Height);
            }
        }

        public Aircraft(Vector2 position, Texture2D text)
        {
            Position = position;
            Texture = text;
            Direction = new Vector2(1, 0);
            Velocity = new Vector2(5, 0);
            FacedRight = true;
        }

        public void Move()
        {
            Position += Velocity * Direction;
            if (!Game1.Instance.GraphicsDevice.Viewport.Bounds.Contains(Bounds))
            {
                Turn();
            }
        }

        public void Turn()
        {
            Direction.X *= -1;
            FacedRight = !FacedRight;
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color.White,
                Rotation,
                Vector2.Zero,
                1,
                FacedRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally,
                0);
        }
        
    }
}
