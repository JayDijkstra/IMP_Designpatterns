using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceExample
{
    class World
    {
        List<GameObject> vehicles = new List<GameObject>();

        public World()
        {
         

            vehicles.Add(new Car());
            vehicles.Add(new Truck());
            vehicles.Add(new Airplane());
            vehicles.Add(new Tank());
            vehicles.Add(new Fiets());
        }

        public void Update()
		{
            foreach(GameObject v in vehicles)
            {
                v.Update();

                if(v is IFuelable)
                {
                    ((IFuelable)v).UseFuel();
                }

                if(v is IUpgradeable)
                {
                    ((IUpgradeable)v).Upgrade();
                }
            }
		}
	

		public void checkKeyboard(){
			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Space))
			{
			}

		}


        public void Draw()
        {
			foreach(GameObject v in vehicles)
            {
                v.Draw();
            }
        }
    }
}
