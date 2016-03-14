using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruis.Interfaces
{
    interface ICollectable
    {
        bool PickedUp { get; }
        void onPickedUp(Ship ship, World world);
    }
}
