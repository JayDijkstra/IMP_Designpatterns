using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceExample
{
	public abstract class GameObject
	{

        public int Speed { get; set; }


        public GameObject()
		{
            Speed = 0;
			Console.WriteLine("ik ben een gameobject");
		}

        public virtual void Move()
        {

            Console.Write("Ik beweeg met een snelheid " + Speed);
        }

		public virtual void Update(){
			
		}

		public virtual void Draw(){
	
		}
	}
}

