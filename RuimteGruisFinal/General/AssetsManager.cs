using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class AssetsManager
	{
		public static List<Texture2D> Rocks;
		public static List<Texture2D> Planets;
		public static Dictionary<string, Texture2D> Textures;
		public static SpriteFont Verdana;

		public AssetsManager()
		{
			Rocks = new List<Texture2D>();
			Planets = new List<Texture2D>();
			Textures = new Dictionary<string, Texture2D>();

			Textures.Add("powerup", Game1.Instance.Content.Load<Texture2D>("powerup"));
			Textures.Add("bomb", Game1.Instance.Content.Load<Texture2D>("bomb"));
			Textures.Add("background", Game1.Instance.Content.Load<Texture2D>("background"));
			Textures.Add("satellite", Game1.Instance.Content.Load<Texture2D>("satellite"));
			Textures.Add("ship", Game1.Instance.Content.Load<Texture2D>("ship"));
			Textures.Add("star", Game1.Instance.Content.Load<Texture2D>("star"));
			Textures.Add("health", Game1.Instance.Content.Load<Texture2D>("health"));
			Textures.Add("bullet", Game1.Instance.Content.Load<Texture2D>("bullet"));
			Textures.Add("explosion", Game1.Instance.Content.Load<Texture2D>("explosion"));

			Verdana     = Game1.Instance.Content.Load<SpriteFont>("Verdana");

			Rocks.Add(Game1.Instance.Content.Load<Texture2D>("block2"));
			Rocks.Add(Game1.Instance.Content.Load<Texture2D>("block3"));
			Rocks.Add(Game1.Instance.Content.Load<Texture2D>("block4"));

			Planets.Add(Game1.Instance.Content.Load<Texture2D>("earth"));
			Planets.Add(Game1.Instance.Content.Load<Texture2D>("planet"));

		}



	}
}
