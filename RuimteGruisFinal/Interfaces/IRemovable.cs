using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
	public interface IRemovable
	{
		bool RemoveMe { get; }
		void OnRemove(World world);
	}

}
