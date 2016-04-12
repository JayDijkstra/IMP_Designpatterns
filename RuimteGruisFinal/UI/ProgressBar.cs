using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
    public class ProgressBar : GameObject
    {
        private const int STROKE_SIZE = 2;           // Dikte van de lijn rond de bar
        private const int MAX_PROGRESS = 800;         // Breedte van de bar
        private Color TEXT_COLOR = Color.White; // Tekstkleur van de tijd
        /// <summary>
        /// Voortgang en ligt tussen 0 en 600
        /// </summary>
        private float _progress = 0;
        /// <summary>
        /// Scale van het schip dat getekend wordt op de progress bar
        /// </summary>
        private float _scale = 0.3f;
        /// <summary>
        /// Inner progress bar
        /// </summary>
        private Rectangle _drawArea;
        private string _gameTime;
        private Texture2D _textureShip;
        /// <summary>
        /// Outer progress bar (Stroke)
        /// </summary>
        private Rectangle _drawAreaStroke
        {
            get
            {
                return new Rectangle(
                    (int)Position.X - STROKE_SIZE,
                    (int)Position.Y - STROKE_SIZE,
                    (int)(MAX_PROGRESS),
                    10 + STROKE_SIZE * 2
                    );
            }
        }

        /// <summary>
        /// Wordt geset als het spel is afgelopen
        /// </summary>
        public bool HasFinished { get; set; }

        public ProgressBar(Vector2 position) : base(position)
        {
            _textureShip = Game1.Instance.Content.Load<Texture2D>("ship");
        }

        public override void Update(GameTime gameTime)
        {
            if (_progress >= MAX_PROGRESS)
            {
                HasFinished = true;
            }
            else
            {
                //_progress += World.Instance.Ship.Speed;
                _progress += 0.2f; // speed ship hardcoded
                _drawArea = new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    (int)_progress,
                    10
                );

                // wegschrijven van de tijd dat het spel duurt naar een string
                _gameTime = "Time: " + ((int)(gameTime.TotalGameTime.TotalMinutes)).ToString("D2") + ":" + ((int)(gameTime.TotalGameTime.TotalSeconds)).ToString("D2");
            }
        }

        public override void Draw()
        {
            // Progress bar
            Texture2D redBar = new Texture2D(Game1.Instance.GraphicsDevice, 1, 1);
                      redBar.SetData(new[] { Color.Red });
            Texture2D blackBar = new Texture2D(Game1.Instance.GraphicsDevice, 1, 1);
                      blackBar.SetData(new[] { Color.White });

            Game1.spriteBatch.Draw(blackBar, _drawAreaStroke, Color.White);
            Game1.spriteBatch.Draw(redBar, _drawArea, Color.White);

            // Ship on progress bar
            Game1.spriteBatch.Draw(
                _textureShip,
                new Vector2(Position.X + _drawArea.Width, Position.Y),
                null,
                Color.White,
                0,
                new Vector2(_textureShip.Width / 2 * _scale, _textureShip.Height / 2 * _scale),
                _scale,
                SpriteEffects.None,
                0);

            // Time
            Game1.spriteBatch.DrawString(
                AssetsManager.Verdana,
                _gameTime,
                new Vector2(400, Position.Y - 30),
                TEXT_COLOR);
        }
    }
}
