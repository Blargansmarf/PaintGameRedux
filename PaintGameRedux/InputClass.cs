using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PaintGameRedux
{
    class InputClass
    {
        public KeyboardState currentKeyboardState, prevKeyboardState;
        public GamePadState currentGamePadState, prevGamePadState;

        public void beginUpdate()
        {
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
        }

        public void endUpdate()
        {
            prevKeyboardState = currentKeyboardState;
            prevGamePadState = currentGamePadState;
        }
    }
}
