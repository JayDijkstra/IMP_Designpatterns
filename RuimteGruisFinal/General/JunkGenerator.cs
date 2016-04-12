using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RuimteGruisFinal
{
    public class JunkGenerator
    {
        public static Texture2D Background;

		public JunkGenerator()
        {

        }

		public void GenerateJunk(List<GameObject> gameObjects){

			if (Game1.Instance.Random.NextDouble() < 0.03f)
			{
				int randomJunk = Game1.Instance.Random.Next(1, 14);

				Vector2 pos = new Vector2(1000, Game1.Instance.Random.Next(0, Game1.Instance.GraphicsDevice.Viewport.Height - 100));

				switch (randomJunk)
				{
				case 1:
				case 2:
					gameObjects.Insert(0, new Planet(pos));
					break;
				case 3:
					gameObjects.Add(new Satellite(pos));
					break;
				case 4:
					gameObjects.Add(new PowerUp(pos));
					break;
				case 5:
					gameObjects.Add(new Bomb(pos));
					break;
				case 6:
				case 7:
				case 8:
					gameObjects.Add(new Star(pos));
					break;
				default:
					gameObjects.Add(new Rock(pos));
					break;

				}
			}
		}

    }
}
