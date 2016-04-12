using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Proeftentamen.GameObjects.Abstract;
using Proeftentamen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proeftentamen.GameObjects
{
    public class FoodBowl : Button
    {

        private List<IObserver> _observers = new List<IObserver>();
        private List<IObserver> _removables = new List<IObserver>();

        public FoodBowl(Vector2 position): base(position)
        {
            Texture = Game1.instance.Content.Load<Texture2D>("food");
        }


        public void SubscribeCat(IObserver c)
        {
            _observers.Add(c);
        }

        public void UnsubscribeCat(IObserver c)
        {
            _removables.Add(c);
        }


        public override void ButtonClick()
        {
           foreach(IObserver c in _observers)
            {
                c.NotifyCats();
            }
           foreach(IObserver c in _removables)
            {
                _observers.Remove(c);
            }
            _removables.Clear();
        }
    }
}
