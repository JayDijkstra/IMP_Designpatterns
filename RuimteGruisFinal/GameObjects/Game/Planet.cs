using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Planet : GameObject, IRemovable
    {

		public bool RemoveMe
		{
			get
			{
				return (Position.X + Texture.Width < 0);
			}

		}

		public Planet(Vector2 position) : base(position)
        {
			int img = Game1.Instance.Random.Next(0,AssetsManager.Planets.Count);

            Texture = AssetsManager.Planets[img];
			float randomSpeed = (float)Game1.Instance.Random.NextDouble() * -1;
			Speed = new Vector2(-0.5f + randomSpeed, 0);
        }

		public void OnRemove(World world)
		{

		}
    }
}
