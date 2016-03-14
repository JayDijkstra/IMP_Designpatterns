using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruis
{
    public class GameObject
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public Color Color { get; set; }

        public float Scale { get; set; }
        public float Speed { get; set; }
        public float Rotation { get; set; }

        public int Health { get; set; }


        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    (int)(Texture.Width / 2),
                    (int)(Texture.Height / 2));
            }
        }


        public GameObject(Vector2 position)
        
        {
            Position = position;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Game1.spriteBatch.Draw(
                Texture,
                Position,
                null,
                Color,
                Rotation,
                new Vector2(Texture.Width / 2, Texture.Height / 2),
                0,
                SpriteEffects.None,
                1);
        }


    }
}
