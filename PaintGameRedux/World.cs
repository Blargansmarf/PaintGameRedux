using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PaintGameRedux
{
    class World
    {
        List<WorldBlock> blocks;

        Random random;

        public World()
        {
            blocks = new List<WorldBlock>();
            WorldBlock firstBlock = new WorldBlock(0, 300, 800, 800);
            blocks.Add(firstBlock);
            random = new Random();
        }

        public void addRandomBlock()
        {
            WorldBlock tempBlock = blocks[blocks.Count - 1];
            //WorldBlock newBlock = new WorldBlock(//FIX THE SHIT OUT OF ME//
        }

        public void addBlock(int x, int y, int width, int height)
        {
            WorldBlock newBlock = new WorldBlock(x, y, width, height);
            blocks.Add(newBlock);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (WorldBlock block in blocks)
            {
                block.Draw(spriteBatch);
            }
        }
    }
}
