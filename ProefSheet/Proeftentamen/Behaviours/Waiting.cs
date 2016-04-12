using Proeftentamen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proeftentamen.Behaviours
{
    class Waiting : IBehaviour
    {
        public Cat _cat { get; set; }

        public Waiting(Cat c)
        {
            _cat = c;
            _cat.Texture = Game1.instance.Content.Load<Texture2D>("cat_awake");
            _cat.RegisterCat();
        }

        public void DoBehaviour()
        {
            
        }

        public void Update(GameTime gameTime)
        {
          
        }
    }
}
