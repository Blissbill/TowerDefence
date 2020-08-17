using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TD.Enemies
{
    class EnemyHandler
    {
        private List<Enemy> _enemies;
        private float _spawnTime;
        private float _elapsedTime;
        private int _indexLastEnemy;

        public EnemyHandler(List<Enemy> enemies)
        {
            _enemies = enemies;
            _spawnTime = 1f;
            _elapsedTime = 0.8f;
            _indexLastEnemy = -1;
        }

        public void Update(double deltaTime)
        {
            if (_elapsedTime >= _spawnTime)
            {
                _elapsedTime = 0;
                if (_indexLastEnemy < _enemies.Count - 1)
                {
                    _enemies[++_indexLastEnemy].Visible = true;
                }
            }
            else
            {
                _elapsedTime += (float)deltaTime;
            }
            UpdateEnemy(deltaTime);
        }

        public void UpdateEnemy(double deltaTime)
        {
            for (int i = 0; i <= _indexLastEnemy; i++)
            {
                _enemies[i].Update(deltaTime);
            }
        }

        public void Draw(double deltaTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= _indexLastEnemy; i++)
            {
                _enemies[i].Draw(deltaTime, graphics, spriteBatch);
            }
        }
    }
}
