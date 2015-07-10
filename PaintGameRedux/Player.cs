using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PaintGameRedux
{
    class Player
    {
        int x, y;
        Texture2D texture;
        enum PlayerState { IDLE, MOVING, JUMPING, FALLING };
        PlayerState state;
        int xVel, yVel;
        int acceleration, jumpHeight;
        int maxMoveSpeed, maxFallSpeed;
        int gravity;

        public Player()
        {
            Initialize();
        }

        public void Initialize()
        {
            state = PlayerState.FALLING;
            x = 0;
            y = 0;
            xVel = 0;
            yVel = 0;
            acceleration = 1;
            jumpHeight = 20;
            maxMoveSpeed = 6;
            maxFallSpeed = 20;
            gravity = 2;
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("WhiteSquare");
        }

        public void Update(InputClass input)
        {
            if (input.currentKeyboardState.IsKeyDown(Keys.Space) &&
                input.prevKeyboardState.IsKeyUp(Keys.Space) &&
                state != PlayerState.JUMPING && state != PlayerState.FALLING)
            {
                state = PlayerState.JUMPING;
                yVel = -jumpHeight;
            }
            if (yVel >= 0 && state == PlayerState.JUMPING)
            {
                state = PlayerState.FALLING;
            }

            if (input.currentKeyboardState.IsKeyDown(Keys.Right))
            {
                xVel += acceleration;
                if(xVel > maxMoveSpeed)
                    xVel = maxMoveSpeed;
                if (yVel == 0 && state != PlayerState.FALLING)
                    state = PlayerState.MOVING;
            }
            else
                if (xVel > 0)
                {
                    xVel--;
                }
            if (input.currentKeyboardState.IsKeyDown(Keys.Left))
            {
                xVel -= acceleration;
                if (xVel < -maxMoveSpeed)
                    xVel = -maxMoveSpeed;
                if (yVel == 0 && state != PlayerState.FALLING)
                    state = PlayerState.MOVING;
            }
            else
                if (xVel < 0)
                {
                    xVel++;
                }

            if (state == PlayerState.JUMPING || state == PlayerState.FALLING)
            {
                yVel += gravity;
                if (yVel > maxFallSpeed)
                {
                    yVel = maxFallSpeed;
                }
            }

            if (input.currentKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                maxMoveSpeed = 15;
            }
            else
            {
                maxMoveSpeed = 6;
            }

            x += xVel;
            y += yVel;

            if (y > 300)
            {
                y = 300;
                yVel = 0;
                state = PlayerState.IDLE;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        }
    }
}
