using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PaintGameRedux
{
    class WorldBlock
    {
        Rectangle rect;

        Texture2D texture;

        public WorldBlock(int x, int y, int width, int height)
        {
            rect = new Rectangle(x, y, width, height);
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("WhiteSquare");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.Black);
        }

        public int getX()
        {
            return rect.X;
        }
        public int getY()
        {
            return rect.Y;
        }
        public int getWidth()
        {
            return rect.Width;
        }
        public int getHeight()
        {
            return rect.Height;
        }
    }
}
