using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proeftentamen.Interfaces
{
    public interface IBehaviour
    {
        Cat _cat { get; set; }
        void Update(GameTime gameTime);
        void DoBehaviour();
    }
}
