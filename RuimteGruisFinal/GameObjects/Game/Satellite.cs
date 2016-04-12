using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Satellite : GameObject, ICollidable, IDestructable, IRemovable
    {

		public int Health { get; set; }
		public int Damage { get; set; }
        
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

        public Satellite(Vector2 position) : base(position)
        {
			Texture = AssetsManager.Textures["satellite"];
            Damage = 15;
			Health = 75;
			Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
			Speed = new Vector2(-1.7f, 0);
        }

		public override void Update(GameTime gameTime)
		{
			Rotation += 0.005f;
			base.Update(gameTime);
		}

		public void OnCollision(ICollidable collideTarget)
		{
			Health -= collideTarget.Damage; 
		}

		public void OnRemove(World world)
		{
			world.AddGameObject(new Explosion(new Vector2(Position.X - 23, Position.Y + 37), 0.04f));
			world.AddGameObject(new Explosion(new Vector2(Position.X + 8, Position.Y + 15), 0.05f));
			world.AddGameObject(new Explosion(new Vector2(Position.X - 28, Position.Y - 13), 0.02f));
			world.AddGameObject(new Explosion(new Vector2(Position.X + 23, Position.Y - 17), 0.03f));
			world.AddGameObject(new Explosion(new Vector2(Position.X - 13, Position.Y + 17), 0.04f));
		}


        public override void Draw()
        {
            
            base.Draw();
			Game1.spriteBatch.DrawString(AssetsManager.Verdana, Health.ToString(), Position - new Vector2(-70, 30), Color.LightGray);
        }
    }
}
