﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RuimteGruis.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruis.Obstacles
{
    class Rock2 : GameObject, ICollidable, IRemovable
    {
        public bool RemoveMe
        {
            get
            {
                return true;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return Bounds;
            }
        }

        public int Damage
        {
            get
            {
                return 5;
            }
        }

        public Rock2(Vector2 position): base(position)
        {
            Texture = Game1.instance.Content.Load<Texture2D>("block3");
            Position = position;
            Speed = 4f;
        }

        public override void Update()
        {
            Position = new Vector2(Position.X - 1 * Speed, Position.Y);
            base.Update();
        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(Texture, Position, Color.White);
            base.Draw();
        }

        public void OnRemove(World world)
        {
            world._obstacles.Remove(this);
        }

        public void onCollision(Ship ship)
        {
            ship.Health -= Damage;
        }
    }
}
