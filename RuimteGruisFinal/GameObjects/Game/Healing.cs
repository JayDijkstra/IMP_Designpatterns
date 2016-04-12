using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Healing : GameObject, IRemovable
	{

		public bool RemoveMe
		{
			get
			{
				return (Alpha <= 0);
			}

		}

		public Healing(Vector2 position) : base(position)
		{
			Texture = AssetsManager.Textures["health"];
			Origin = new Vector2(-10, 50);
			Speed = new Vector2(0, -0.6f);
		}



		public override void Update(GameTime gameTime)
		{
			Alpha -= 0.01f;
			base.Update(gameTime);
		}

		public void OnRemove(World world)
		{

		}

	}
}
