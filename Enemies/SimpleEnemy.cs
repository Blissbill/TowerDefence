using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD.Enemies
{
    class SimpleEnemy : Enemy
    {
        private double _deltaTime;
        public SimpleEnemy(Vector2 position, Vector2 size, Vector2 startPosition) : base(position, size, startPosition)
        {
        }

        public override void Update(double deltaTime)
        {
            if (!Visible) return;
            _deltaTime = deltaTime;
            Position = new Vector2(Position.X, (float)(Position.Y + Speed * deltaTime));
        }

        public override void Draw(double deltaTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            if (!Visible) return;
            Vector2 a = new Vector2(Position.X, Position.Y - 20);
            Vector2 b = new Vector2(Position.X - 20, Position.Y + 20);
            Vector2 c = new Vector2(Position.X + 20, Position.Y + 20);
            spriteBatch.Begin();
            GUI.GUI.DrawLine(spriteBatch, a, b, Color.Yellow);
            GUI.GUI.DrawLine(spriteBatch, b, c, Color.Yellow);
            GUI.GUI.DrawLine(spriteBatch, c, a, Color.Yellow);
            spriteBatch.DrawString(GUI.GUI.font, (_deltaTime ).ToString(), new Vector2(1000, 50), Color.Blue );
            spriteBatch.End();
        }

    }
}
