using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TD.Enemies;
using TD.Tiles;
using TD.Towers;

namespace TD.Scenes
{
    public class GameScene : Scene
    {
        private int[,] _field;
        private List<Tile> _tiles;
        private List<Enemy> _enemies;
        private EnemyHandler _enemyHandler;

        public GameScene()
        {
            /*
             1 - wall
             2 - road
             3 - spawn enemy
             4 - base
            */
            _field = new [,]
            {
                {0, 3, 0, 0, 0, 0, 0, 1, 1, 0},
                {0, 2, 1, 0, 0, 2, 2, 2, 2, 1},
                {0, 2, 1, 0, 0, 2, 1, 1, 2, 1},
                {1, 2, 1, 0, 0, 2, 1, 1, 2, 0},
                {1, 2, 1, 1, 1, 2, 1, 0, 2, 0 },
                {1, 2, 2, 2, 2, 2, 1, 0, 4, 0 },
                {0, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
            };
            _tiles = new List<Tile>();
            Vector2 startPosition = new Vector2(200, 100);
            Vector2 tileSize = new Vector2(50, 50);
            Vector2 indent = new Vector2(5, 5);
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (_field[i, j] == 1)
                    {
                        _tiles.Add(new WallTile(new Vector2(startPosition.X + j * (50 + indent.X), startPosition.Y + i * (50 + indent.Y)), tileSize));
                    }
                    if (_field[i, j] == 2)
                    {
                        _tiles.Add(new RoadTile(new Vector2(startPosition.X + j * (50 + indent.X), startPosition.Y + i * (50 + indent.Y)), tileSize));
                    }
                    if (_field[i, j] == 3)
                    {
                        _tiles.Add(new SpawnTile(new Vector2(startPosition.X + j * (50 + indent.X), startPosition.Y + i * (50 + indent.Y)), tileSize));
                    }
                    if (_field[i, j] == 4)
                    {
                        _tiles.Add(new BaseTile(new Vector2(startPosition.X + j * (50 + indent.X), startPosition.Y + i * (50 + indent.Y)), tileSize));
                    }
                }
            }

            _enemies = new List<Enemy>
            {
                new SimpleEnemy(new Vector2(startPosition.X + tileSize.X + indent.X, startPosition.Y + tileSize.Y + indent.Y - 55), new Vector2(40, 40), Vector2.Zero),
                new SimpleEnemy(new Vector2(startPosition.X + tileSize.X + indent.X, startPosition.Y + tileSize.Y + indent.Y - 55), new Vector2(40, 40), Vector2.Zero),
                new SimpleEnemy(new Vector2(startPosition.X + tileSize.X + indent.X, startPosition.Y + tileSize.Y + indent.Y - 55), new Vector2(40, 40), Vector2.Zero)
            };

            _enemyHandler = new EnemyHandler(_enemies);

        }

        public override void Update(double deltaTime)
        {
            _enemyHandler.Update(deltaTime);
        }

        public override void Draw(double deltaTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            foreach (var tile in _tiles)
            {
                tile.Draw(deltaTime, graphics, spriteBatch);
            }
            _enemyHandler.Draw(deltaTime, graphics, spriteBatch);
        }
    }
}