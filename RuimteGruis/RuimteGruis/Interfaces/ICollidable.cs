using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruis.Interfaces
{
    interface ICollidable
    {
        Rectangle BoundingBox { get; }
        int Damage { get; }
        void onCollision(Ship ship);
    }
}
