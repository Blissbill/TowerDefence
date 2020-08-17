using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TD.Scenes;

namespace TD
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    //TODO: Баффы / дебаффы
    //TODO: RoadTile даёт эффекты

    public class GameMain : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Scene _currentScene;
        private GameScene _gameScene;
        public static int GraphicsWidth, GraphicsHeight;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);

            GraphicsWidth = 1280;
            GraphicsHeight = 700;

            //graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = GraphicsWidth;
            _graphics.PreferredBackBufferHeight = GraphicsHeight;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 120d);
            IsMouseVisible = true;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            _gameScene = new GameScene();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GUI.GUI.font = Content.Load<SpriteFont>("SpriteFont1");
            GUI.GUI.LoadContent(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
            double deltaTime = gameTime.ElapsedGameTime.TotalSeconds;
            _gameScene.Update((float)deltaTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(45, 45, 48));
            _gameScene.Draw(gameTime.ElapsedGameTime.TotalSeconds, GraphicsDevice, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}
