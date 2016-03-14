using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using RuimteGruis.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using RuimteGruis.Obstacles;
using System.Diagnostics;

namespace RuimteGruis
{
    class HealthPack : GameObject, ICollectable
    {
        public HealthPack(Vector2 position) : base(position)
        {
            Texture = Game1.instance.Content.Load<Texture2D>("health");
            Speed = 5f;
        }

        public override void Update()
        {
            Position = new Vector2(Position.X - 1 * Speed, Position.Y);
            base.Update();
        }

        public bool PickedUp
        {
            get
            {
                return true;
            }
        }

        public void onPickedUp(Ship ship, World world)
        {
            ship.Health += 10;
            Debug.WriteLine("Healthpack has been collected!");
            
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw();
        }
    }
}
