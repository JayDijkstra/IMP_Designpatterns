using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public class Explosion : GameObject, IRemovable
    {

		public bool RemoveMe
		{
			get
			{
				return (Alpha <= 0);
			}

		}
        
		public Explosion(Vector2 position, float scale) : base(position)
        {
			Texture = AssetsManager.Textures["explosion"];
			Origin = new Vector2(50, 50);
			Position += new Vector2(20,0);
			Scale = scale;
        }



		public override void Update(GameTime gameTime)
		{
			Scale += 0.02f;
			Alpha -= 0.02f;
		}

		public void OnRemove(World world)
		{

		}

    }
}
