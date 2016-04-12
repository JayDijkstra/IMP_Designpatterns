using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Bullet : GameObject, ICollidable, IDestructable, IRemovable
    {
		public int Damage { get; set; }
		public int Health { get; set; }

		public bool RemoveMe
		{
			get
			{
				return (Position.X > 1000 || Health <= 0);
			}

		}

		public Rectangle BoundingBox
		{
			get
			{
				return new Rectangle(
					(int)Position.X,
					(int)Position.Y,
					(int)(Texture.Width * Scale),
					(int)(Texture.Height * Scale)
				);
			}

		}

		public Bullet(Vector2 position) : base(position)
        {
			Texture = AssetsManager.Textures["bullet"];
			Speed = new Vector2(7, 0);
			Damage = 5;
			Health = 1;
        }

		public void OnRemove(World world)
		{
			world.AddGameObject(new Explosion(Position, 0.01f));
		}

        public void OnCollision(ICollidable gameObject)
        {
            Health -= gameObject.Damage;
        }
    }
}
