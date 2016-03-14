using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruis.Interfaces
{
    interface IRemovable
    {
        bool RemoveMe { get; }
        void OnRemove(World world);
    }
}
