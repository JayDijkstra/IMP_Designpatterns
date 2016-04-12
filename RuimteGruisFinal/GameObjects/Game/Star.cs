using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Star : GameObject, IRemovable
    {
		public bool RemoveMe
		{
			get
			{
				return (Position.X + Texture.Width < 0);
			}

		}
        
		public Star(Vector2 position) : base(position)
        {
			Texture = AssetsManager.Textures["star"];
			Speed = new Vector2(Game1.Instance.Random.Next(-20,-12), 0);
			Color = Color.White * 0.5f;
        }

		public void OnRemove(World world)
		{

		}
    }
}
