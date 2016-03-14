using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuimteGruis.Interfaces;
using RuimteGruis.Obstacles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RuimteGruis
{
    class World
    {
        private Texture2D _background;
        private Ship _ship;

        public List<GameObject> _obstacles = new List<GameObject>();
        public Random Random { get; set; }


        public World()
        {
            _background = Game1.instance.Content.Load<Texture2D>("background");
            _ship = new Ship(new Vector2(100, 100));
            Random = new Random();
        }

        public void Update()
        {
            foreach (Obstacle o in _obstacles)
            {
                o.Update();
            }
            _ship.Update();
            CheckCollision();
            GenerateJunk();
        }


        public void GenerateJunk()
        {
            if (Random.NextDouble() < 0.02f)
            {

                int randomJunk = Random.Next(0, 12);
                Vector2 pos = new Vector2(1000, Random.Next(0, 600));

                switch (randomJunk)
                {
                    case 1:
                        _obstacles.Add(new Rock(pos));
                        break;
                    case 2:
                        _obstacles.Add(new Star(pos));
                        break;
                    case 3:
                        _obstacles.Add(new Satelite(pos));
                        break;
                    case 4:
                        _obstacles.Add(new HealthPack(pos));
                        break;
                    default:
                        _obstacles.Add(new Rock2(pos));
                        break;
                }
            }
        }

        public void CheckCollision()
        {
            foreach (Obstacle o in _obstacles)
            {
                if (_ship.Bounds.Intersects(o.Bounds))
                {
                    if(o is ICollectable)
                    {
                        ((ICollectable)o).onPickedUp(_ship,this);
                        Console.WriteLine(_ship.Health);
                    }
                    
                }
            }
        }

        public void Draw()
        {
            Game1.spriteBatch.Draw(_background, Vector2.Zero, Color.White);
            _ship.Draw();
            foreach (Obstacle o in _obstacles)
            {
                o.Draw();
            }
        }
    }
}
