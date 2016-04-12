using Proeftentamen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Proeftentamen.Behaviours
{
    class Eating : IBehaviour
    {
        public Cat _cat { get; set; }
        private int _counter;


        public Eating(Cat c)
        {
            _cat = c;
            _cat.Texture = Game1.instance.Content.Load<Texture2D>("cat_eating");
            _counter = 0;
            _cat.UnregisterCat();
        }

        public void DoBehaviour()
        {
           
        }

        public void Update(GameTime gameTime)
        {
            _counter++;
            if(_counter > 180)
            {
                _cat.catBehaviour = new Sleeping(_cat);
            }  
        }
    }
}
