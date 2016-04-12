using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Ship : GameObject, ICollidable, IDestructable, IRemovable
    {
		private float _timeSinceHit;
		private World _world;
		private KeyboardState _prevState;

		public int Health { get; set; }
        public int Damage { get; set; }

		public bool RemoveMe
		{
			get
			{
				return (Health < 0);
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

		public Ship(Vector2 position, World w) : base(position)
        {
			Texture = AssetsManager.Textures["ship"];
			Health = 100;
			Damage = 20;
			Speed = Vector2.Zero;
			_timeSinceHit = 5f;
			_world = w;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kbs = Keyboard.GetState();

			// fire bullet
			if(kbs.IsKeyDown(Keys.Space) && _prevState.IsKeyUp(Keys.Space)) {
				_world.AddGameObject(new Bullet(new Vector2(Position.X + Texture.Width, Position.Y + 41)));
			}

			// direction and speed
			float xdirection = 0;
			float ydirection = 0;

            if(kbs.IsKeyDown(Keys.Up))
            {
				ydirection = -1;
            }
            if (kbs.IsKeyDown(Keys.Down))
            {
				ydirection = 1;
            }
            if (kbs.IsKeyDown(Keys.Left))
            {
				xdirection = -1;
            }
            if (kbs.IsKeyDown(Keys.Right))
            {
				xdirection = 1;
            }

			// normalize zodat 1,1 niet sneller is dan 1,0 of 0,1
			Vector2 Direction = new Vector2(xdirection, ydirection);
			if(Direction != Vector2.Zero)
				Direction = Vector2.Normalize(Direction);
			
			// speed is 4 * normalized direction
			Speed = Direction * new Vector2(6, 6);
		
			// binnen scherm blijven met clamp
			Position = Vector2.Clamp(Position + Speed, new Vector2(0, 0), new Vector2(900, 610));

			// elapsed time for blinking effect
			_timeSinceHit += (float)gameTime.ElapsedGameTime.TotalSeconds;

			// record keyboard state
			_prevState = kbs;

        }

		//
		// check waar we door geraakt zijn
		//
		public void OnCollision(ICollidable collideTarget)
		{
			if(collideTarget is ICollectable) {
				// van collectibles krijg je een custom effect
				((ICollectable)collideTarget).OnPickup(this, _world);
			} else {
				// van alle andere collidables krijg je damage
				Health -= collideTarget.Damage;
			}

			// blink effect
			//_timeSinceHit = 0f; 
        }

		public void OnRemove(World world)
		{
			// GAME OVER HUGE EXPLOSIONSSS!!!!
			world.AddGameObject(new Explosion(new Vector2(Position.X - 25, Position.Y - 35), 0.02f));
			world.AddGameObject(new Explosion(new Vector2(Position.X + 3, Position.Y - 3), 0.03f));
			world.AddGameObject(new Explosion(new Vector2(Position.X - 23, Position.Y + 37), 0.04f));
			world.AddGameObject(new Explosion(new Vector2(Position.X + 8, Position.Y + 15), 0.05f));
			world.AddGameObject(new Explosion(new Vector2(Position.X - 28, Position.Y - 13), 0.02f));
			world.AddGameObject(new Explosion(new Vector2(Position.X + 23, Position.Y - 17), 0.03f));
			world.AddGameObject(new Explosion(new Vector2(Position.X - 13, Position.Y + 17), 0.04f));
			world.AddGameObject(new Explosion(new Vector2(Position.X + 25, Position.Y + 25), 0.05f));
		}

        public override void Draw()
		{
			// draw health 
			Game1.spriteBatch.DrawString(AssetsManager.Verdana, Health.ToString(), Position - new Vector2(-30, 30), Color.LightGray);

			// knipper effect... bugje, werkt niet meer --- blinking tijd 1.2 seconden, per blink 0.3 seconden
			// float alpha = _timeSinceHit > 1.2f ? 1 : ((_timeSinceHit % 0.3f) / 0.3f);
			// Color = Color.White * alpha;

			base.Draw();
		}
    }
}
