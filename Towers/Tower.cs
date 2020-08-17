﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD.Towers
{
    abstract class Tower
    {
        protected Tower(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        
        public Vector2 Position { get; set; } //center tower

        public Vector2 Size { get; set; }

        public abstract void Update(double deltaTime);

        public abstract void Draw(double deltaTime, GraphicsDevice graphics, SpriteBatch spriteBatch);

        public Rectangle GetRectangle()
        {
            Point leftTop = new Point((int)(Position.X - Size.X / 2), (int)(Position.Y - Size.Y / 2));
            return new Rectangle(leftTop, Size.ToPoint());
        }
    }
}
