using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD.Tiles
{
    class BaseTile : Tile
    {
        public BaseTile(Vector2 position, Vector2 size) : base(position, size)
        {
        }

        public override void Update(double deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(double deltaTime, GraphicsDevice graphics, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            GUI.GUI.DrawRectangle(spriteBatch, GetRectangle(), new Color(224, 126, 20), true);
            spriteBatch.End();
        }
    }
}
