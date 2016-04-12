using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Rock : GameObject, ICollidable, IDestructable, IRemovable
    {

		public int Health { get; set; }
		public int Damage { get; set; }
		public bool Colliding { get; set; }
   
		public bool RemoveMe
		{
			get
			{
				return (Position.X + Texture.Width < 0 || Health <= 0);
			}

		}

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)(Position.X - (Origin.X / 2 * Scale)),
                    (int)(Position.Y - (Origin.Y / 2 * Scale)),
                    (int)(Texture.Width * Scale),
                    (int)(Texture.Height * Scale)
                    );
            }

        }

        public Rock(Vector2 position) : base(position)
        {
			int img = Game1.Instance.Random.Next(0,AssetsManager.Rocks.Count);

            Texture = AssetsManager.Rocks[img];
           	Damage = 5;
			Health = 20;
			float randomSpeed = (float)Game1.Instance.Random.NextDouble() * -3;
			Speed = new Vector2(randomSpeed-1, 0);

        }

		public void OnRemove(World world)
		{
			world.AddGameObject(new Explosion(Position, 0.7f));
		}

		public override void Draw()
		{
			Game1.spriteBatch.DrawString(AssetsManager.Verdana, Health.ToString(), Position + new Vector2(Texture.Width/4, -30), Color.LightGray);
			base.Draw();
		}

        public void OnCollision(ICollidable gameObject)
        {
            Health -= gameObject.Damage;
        }
    }
}
