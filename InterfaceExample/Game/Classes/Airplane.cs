using System;

namespace InterfaceExample
{
    class Airplane : GameObject, IFuelable
    {

        public int Fuel { get; set; }

        public Airplane()
        {
            Fuel = 200;
        }

        public void UseFuel()
        {
            Fuel = -5;
            Console.WriteLine("AirPlane uses Fuel!");
        }
    }
}