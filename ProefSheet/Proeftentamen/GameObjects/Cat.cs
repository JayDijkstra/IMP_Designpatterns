using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Proeftentamen.GameObjects.Abstract;
using Proeftentamen.Interfaces;
using Proeftentamen.Behaviours;
using Proeftentamen.GameObjects;

namespace Proeftentamen
{
	public class Cat : Button, IObserver
	{
        public IBehaviour catBehaviour;

        private FoodBowl _bowl;

		public Cat(Vector2 position, FoodBowl bowl) : base (position) {
            _bowl = bowl;
            catBehaviour = new Sleeping(this);
		}

        public void RegisterCat()
        {
            _bowl.SubscribeCat(this);
        }


        public void UnregisterCat()
        {
            _bowl.UnsubscribeCat(this);
        }

		//
		// reactie op klik
		//
		public override void ButtonClick(){
            catBehaviour.DoBehaviour();
        }

        public void NotifyCats()
        {
            catBehaviour = new Eating(this);
        }

        public override void Update(GameTime gameTime)
        {
            catBehaviour.Update(gameTime);
            base.Update(gameTime);
        }
    }
}