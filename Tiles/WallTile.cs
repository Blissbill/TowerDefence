using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD.Tiles
{
    class WallTile : Tile
    {
        public WallTile(Vector2 position, Vector2 size) : base(position, size)
        {
        }

        public override void Update(double deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(double deltaTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            GUI.GUI.DrawRectangle(spriteBatch, GetRectangle(), new Color(10, 10, 10), true);
            Point leftTop = new Point((int)(Position.X - Size.X / 2 + 5), (int)(Position.Y - Size.Y / 2 + 5));
            Point size = new Point((int)(Size.X - 10), (int)(Size.Y - 10));
            GUI.GUI.DrawRectangle(spriteBatch, new Rectangle(leftTop, size), new Color(30, 30, 30), true);
            spriteBatch.End();
        }
    }
}
