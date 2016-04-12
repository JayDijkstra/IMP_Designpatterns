using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyPlane
{
    public class World
    {
        private Aircraft _aircraft;
        

        public World()
        {
            Texture2D planeTexture = Game1.Instance.Content.Load<Texture2D>("CoolPlane");
            _aircraft = new Aircraft(new Vector2(50, 150), planeTexture);
            
        }

        public void Draw()
        {
            _aircraft.Draw();
        }

        public void Update()
        {
            _aircraft.Move();
        }
    }
}
