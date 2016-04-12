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
	public class BehaviorButton : Button
	{
		private Cat _cat;

		public BehaviorButton(Vector2 position, Cat cat) {
			_cat = cat;
			Texture = Game1.instance.Content.Load<Texture2D>("catbutton");
			Position = new Vector2(320 - Texture.Width/2, position.Y);
		}

		public override void OnClick(){
			// verander het gedrag van de kat
			Console.WriteLine("the button was clicked");
		}
	}

}
