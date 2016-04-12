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
    class World
    {
        private Cat         _cat;
		private Button 		_button;

        public World()
        {
			_cat = new Cat(new Vector2(0,0));
			_button = new BehaviorButton(new Vector2(50,490), _cat);
        }

		public void Update(GameTime gameTime)
		{
			_cat.Update(gameTime);
			_button.Update(gameTime);
		}


		public void Draw(SpriteBatch spriteBatch)
        {
			_cat.Draw(spriteBatch);
			_button.Draw(spriteBatch);
        }
    }
}
