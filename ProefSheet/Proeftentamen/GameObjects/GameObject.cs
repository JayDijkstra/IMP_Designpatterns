using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proeftentamen
{
	public class GameObject
	{
		public Texture2D       Texture		{ get; set; }
		public Vector2         Position    { get; set; }
		protected Vector2      Centerpoint { get; set; }
		protected Color        Color       { get; set; }
		protected float        Speed       { get; set; }
		protected float        Scale       { get; set; }
		protected float        Rotation 	{ get; set; }

		public GameObject(Vector2 position)
		{
			Position = position;
			Centerpoint = Vector2.Zero;
			Scale = 1;

		}

		public Rectangle Bounds
		{
			get
			{
				return new Rectangle(
					(int)Position.X,
					(int)Position.Y,
					(int)(Texture.Width * Scale),
					(int)(Texture.Height * Scale));
			}
		}

		public virtual void Update(GameTime gameTime){
			
		}

		public virtual void Draw(SpriteBatch spriteBatch){
			spriteBatch.Draw(
				Texture,
				Position,
				null,
				Color.White,
				Rotation,
				Centerpoint,
				1,
				SpriteEffects.None,
				0);
		}
	}
}

