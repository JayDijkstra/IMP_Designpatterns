using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatClicker
{
	public abstract class Button : GameObject
	{
		private MouseState _previousMouse;
		private MouseState _mouse;

		public Button() {
			
		}

		//
		// update functie kijkt of er geklikt is binnen de bounds van de button
		//
		public override void Update(GameTime gameTime){
			_mouse = Mouse.GetState();

			bool mouseHit = (Bounds.Contains(_mouse.X, _mouse.Y));
			bool mouseClicked = (_mouse.LeftButton != _previousMouse.LeftButton && _mouse.LeftButton == ButtonState.Pressed);

			if(mouseHit && mouseClicked) {
				OnClick();
			}

			_previousMouse = _mouse;
		}

		//
		// cat en behaviorbutton vullen dit zelf in
		//
		public virtual void OnClick(){
			
		}
	}
}
