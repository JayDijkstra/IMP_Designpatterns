using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuimteGruisFinal
{
    public class World
    {
		private List<GameObject> _gameobjects = new List<GameObject>();

		private Background _background;
        private ProgressBar _progressBar;
		private JunkGenerator _junkGenerator;

        public World()
        {
			_junkGenerator = new JunkGenerator();
			_background = new Background();
			_progressBar = new ProgressBar(new Vector2(100, Game1.Instance.GraphicsDevice.Viewport.Height * 0.95f));

			_gameobjects.Add(new Ship(new Vector2(100, 290), this));
        }

     
		// __________________________________________________________________________________________
		// all update functions
		// __________________________________________________________________________________________
        public void Update(GameTime gameTime)
		{
			_junkGenerator.GenerateJunk(_gameobjects);
			_background.Update();
			_progressBar.Update(gameTime);

			// update - kan niet met foreach omdat sommige updates de lijst veranderen
			for(int i = 0; i < _gameobjects.Count; i++) {
				_gameobjects[i].Update(gameTime);
			}

			// check voor collisions
			CheckCollisions();

			// finally we remove everything that has died
			CheckRemovables();
		}


		// __________________________________________________________________________________________
		// check collisions
		// __________________________________________________________________________________________
		private void CheckCollisions(){
            foreach (GameObject go in _gameobjects)
            {
                if(go is ICollidable)
                {
                    
                    ICollidable colGo = go as ICollidable;
                    ((ICollidable)go).OnCollision(colGo);
                }
            }
			
				
		}

		// __________________________________________________________________________________________
		// remove objects - the ugly part - hoe versimpelen?
		// __________________________________________________________________________________________
		public void CheckRemovables() 
		{

			for(int i = _gameobjects.Count - 1; i >= 0; i--) {
				GameObject go = _gameobjects[i];

				// remove
				if(go is IRemovable) {

					IRemovable rmv = go as IRemovable;

					if(rmv.RemoveMe == true) {
						rmv.OnRemove(this);
						_gameobjects.Remove(go);
					}
				}
			}



		}

		// __________________________________________________________________________________________
		// dingen toevoegen en verwijderen
		// __________________________________________________________________________________________
		public void AddGameObject(GameObject b){
			_gameobjects.Add(b);
		}

		public void HitAllObjectsWithBomb(Bomb bomb){
			List<ICollidable> collidables = new List<ICollidable>(_gameobjects.OfType<ICollidable>());

			foreach(ICollidable target in collidables) {
				if(target != bomb && !(target is Ship)) {
					target.OnCollision(bomb);
				}
			}
		}

		// __________________________________________________________________________________________
		// draw
		// __________________________________________________________________________________________
		public void Draw()
		{
			_background.Draw();
			foreach(GameObject g in _gameobjects) {
				g.Draw();
			}
			_progressBar.Draw();

			// debug
			int total = _gameobjects.Count;
			Game1.spriteBatch.DrawString(AssetsManager.Verdana, "Aantal gameobjects:" + total.ToString(), new Vector2(10, 10), Color.LightGray);
		}
    }
}
