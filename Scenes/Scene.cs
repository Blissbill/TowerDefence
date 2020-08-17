using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TD.Scenes
{
    public abstract class Scene
    {
        public static Scene Selected { get; private set; }

        public virtual void Deselect()
        {
        }

        public virtual void Select()
        {
            Selected?.Deselect();
            Selected = this;
        }

        public abstract void Update(double deltaTime);

        public abstract void Draw(double deltaTime, GraphicsDevice graphics, SpriteBatch spriteBatch);
    }
}
