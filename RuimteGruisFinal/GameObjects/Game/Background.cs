using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;

namespace RuimteGruisFinal
{
    public class Background
	{
		private Texture2D Texture;
		public Vector2 Position { get; set; }
		public Vector2 Speed { get; set; }

        public Background()
        {
			Texture = AssetsManager.Textures["background"];
			Position = Vector2.Zero;
			Speed = new Vector2(-0.5f, 0);
        }
        public void Update()
        {
			Position += Speed;
			if(Position.X + Texture.Width < 0)	Position = Vector2.Zero;
        }

		public void Draw(){
			Game1.spriteBatch.Draw(Texture, Position, Color.White);
			Game1.spriteBatch.Draw(Texture, Position + new Vector2(Texture.Width,0), Color.White);
		}
    }
}
