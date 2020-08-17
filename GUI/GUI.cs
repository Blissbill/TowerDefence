using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TD.GUI
{
    class GUI
    {
        private static Texture2D t;
        private static GraphicsDevice graphicsDevice;

        public static SpriteFont font;

        public static void LoadContent(GraphicsDevice graphics)
        {
            graphicsDevice = graphics;

            // create 1x1 texture for line drawing
            t = new Texture2D(graphicsDevice, 1, 1);
            t.SetData<Color>(
                new Color[] { Color.White });// fill the texture with white
        }
        public static void DrawRectangle(SpriteBatch sb, Rectangle rect, Color clr, bool isFilled = false,
            float depth = 0.0f)
        {
            if (isFilled)
            {
                sb.Draw(t, rect, null, clr);
            }
            else
            {
                Vector2 p1 = new Vector2(rect.X, rect.Y);
                Vector2 p2 = new Vector2(rect.X + rect.Width, rect.Y);
                Vector2 p3 = new Vector2(rect.X + rect.Width, rect.Y + rect.Height);
                Vector2 p4 = new Vector2(rect.X, rect.Y + rect.Height);

                DrawLine(sb, p1, p2, clr, depth);
                DrawLine(sb, p2, p3, clr, depth);
                DrawLine(sb, p3, p4, clr, depth);
                DrawLine(sb, p4, p1, clr, depth);
            }
        }
        
        public static void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, Color clr, float depth = 0.0f)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle = (float)Math.Atan2(edge.Y, edge.X);
            
            sb.Draw(t,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                clr, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                depth);
        }
    }
}