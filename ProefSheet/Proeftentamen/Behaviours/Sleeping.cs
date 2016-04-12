using Proeftentamen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proeftentamen.Behaviours
{
    class Sleeping : IBehaviour
    {
        public Cat _cat {get; set;}

        public Sleeping(Cat c)
        {
            _cat = c;
            _cat.Texture = Game1.instance.Content.Load<Texture2D>("cat_sleeping");
        }

        public void DoBehaviour()
        {
            _cat.catBehaviour = new Waiting(_cat);
        }

        public void Update(GameTime gameTime)
        {
           
        }
    }
}
