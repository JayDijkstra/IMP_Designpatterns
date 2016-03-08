using System;

namespace InterfaceExample
{
    class Tank : GameObject, IFuelable
    {

        public int Fuel { get; set; }

        public Tank()
        {
            Fuel = 100;
        }

      

        public void UseFuel()
        {
            Fuel -= 10;
            Console.WriteLine("Tank uses Fuel");
        }
    }
}