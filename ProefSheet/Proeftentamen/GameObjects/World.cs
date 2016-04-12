using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proeftentamen.GameObjects;

namespace Proeftentamen
{
    class World
    {
		private List<GameObject> _gameobjects = new List<GameObject>();
		private SpriteFont  _spVerdana;
        private FoodBowl _bowl;

        public World()
        {
			_spVerdana  = Game1.instance.Content.Load<SpriteFont>("Verdana");

            _bowl = new FoodBowl(new Vector2(0,0));

			_gameobjects.Add(new Cat(new Vector2(70,170), _bowl));
            _gameobjects.Add(new Cat(new Vector2(150, 50), _bowl));
            _gameobjects.Add(new Cat(new Vector2(350, 170), _bowl));
            _gameobjects.Add(new Cat(new Vector2(200, 300), _bowl));


            _gameobjects.Add(_bowl);

        }

		public void Update(GameTime gameTime)
		{
            foreach(GameObject go in _gameobjects)
            {
                go.Update(gameTime);
            }
		}


		public void Draw(SpriteBatch spriteBatch)
        {
           foreach(GameObject go in _gameobjects)
            {
                go.Draw(spriteBatch);
            }

			spriteBatch.DrawString(_spVerdana, "Click on sleeping cats to wake them up", new Vector2(10, 460), Color.Black);
			spriteBatch.DrawString(_spVerdana, "Awake cats wait for food", new Vector2(10, 480), Color.Black);
			spriteBatch.DrawString(_spVerdana, "Click on food to feed waiting cats", new Vector2(10, 500), Color.Black);
			spriteBatch.DrawString(_spVerdana, "Eating will fall asleep after a while...", new Vector2(10, 520), Color.Black);
        }
    }
}
