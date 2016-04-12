using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatClicker
{
	public class Cat : Button
	{
		private SpriteFont  _spVerdana;
		private int _current;
		public string Displaytext { get; set; }

		public Cat(Vector2 position) {
			Position = position;
			Texture = Game1.instance.Content.Load<Texture2D>("cat_idle");
			Displaytext = "Beetje niks doen prima toch";
			_spVerdana  = Game1.instance.Content.Load<SpriteFont>("Verdana");
			_current = 1;
		}

		//
		// the cat is clicked
		//
		public override void OnClick(){
			Console.WriteLine("the cat was clicked...");
		}

		//
		// the change button calls this function 
		//
		public void ChangeBehavior(){
			

		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			spriteBatch.DrawString(_spVerdana, Displaytext, new Vector2(10, 10), Color.Black);
		}
	}
}