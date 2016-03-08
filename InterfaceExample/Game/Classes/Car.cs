using System;

namespace InterfaceExample
{
	public class Car : GameObject, IFuelable, IUpgradeable
	{

        public int Fuel { get; set; }

        public Car()
		{
            Fuel = 50;
			Console.WriteLine("Vroom");
		}

      
      
        public void UseFuel()
        {
            Fuel = -2;
            Console.Write("Car uses Fuel");
        }

        public void Upgrade()
        {
            
        }
    }
}

