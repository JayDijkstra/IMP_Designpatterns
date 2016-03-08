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
    public class Truck : GameObject, IFuelable
    {
        public int Fuel { get; set; }
        
            

        public void UseFuel()
        {
            Fuel -= 20;
            Console.WriteLine("Truck uses Fuel");
        }
    }

}
