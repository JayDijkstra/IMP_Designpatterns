using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proeftentamen.GameObjects.Abstract
{
    public abstract class Button : GameObject
    {
        private MouseState _previousMouse;
        private MouseState _mouse;

        public Button(Vector2 position): base(position)
        {

        }

        public override void Update(GameTime gameTime)
        {
            _mouse = Mouse.GetState();

            bool mouseHit = (Bounds.Contains(_mouse.X, _mouse.Y));
            bool mouseClicked = (_mouse.LeftButton != _previousMouse.LeftButton && _mouse.LeftButton == ButtonState.Pressed);

            if (mouseHit && mouseClicked)
            {
                ButtonClick();
            }

            _previousMouse = _mouse;
            base.Update(gameTime);
        }


        public abstract void ButtonClick();
    }
}
