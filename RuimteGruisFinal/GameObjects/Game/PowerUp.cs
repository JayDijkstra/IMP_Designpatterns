using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RuimteGruisFinal
{
	public class PowerUp : GameObject, ICollidable, IRemovable, ICollectable, IDestructable
	{
        public int Damage { get; set;  }
		public bool PickedUp { get; set; }
		public int Health { get; set; }

		public bool RemoveMe
		{
			get
			{
				return (Position.X + Texture.Width < 0 || PickedUp == true || Health <= 0);
			}

		}

		public PowerUp(Vector2 pos) : base(pos) {
			Texture = AssetsManager.Textures["powerup"];
			Speed = new Vector2(-2.3f, 0);
			PickedUp = false;
			Health = 5;
			// de powerup doet wel damage, omdat rotsen en kogels er anders niet door beschadigd raken
			Damage = 5;
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

		public void OnCollision(ICollidable gameObject)
		{
			Health -= gameObject.Damage; 
		}

		public void OnPickup(Ship ship, World world)
		{
			PickedUp = true;
			ship.Health += 100;

			world.AddGameObject(new Healing(ship.Position));
		}

		public void OnRemove(World world)
		{
		}
	}
}
