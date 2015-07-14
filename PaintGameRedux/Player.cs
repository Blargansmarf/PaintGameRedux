using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PaintGameRedux
{
    class Player
    {
        float x, y;
        Texture2D texture;
        enum PlayerState { IDLE, MOVING, JUMPING, FALLING };
        PlayerState state;
        float xVel, yVel;
        float acceleration, jumpHeight;
        float maxMoveSpeed, maxFallSpeed;
        float gravity;

        Rectangle testRect;

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
            acceleration = .6f;
            jumpHeight = 17;
            maxMoveSpeed = 5;
            maxFallSpeed = 15;
            gravity = 1.1f;

            testRect = new Rectangle(0, 300, 300, 40);
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
            if (input.currentKeyboardState.IsKeyUp(Keys.Space) && state == PlayerState.JUMPING)
            {
                state = PlayerState.FALLING;
                yVel = 0;
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
                    xVel -= acceleration;
                    if (xVel < 0)
                        xVel = 0;
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
                    xVel += acceleration;
                    if (xVel > 0)
                        xVel = 0;
                }

            if (state != PlayerState.IDLE)
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

            checkCollision();
        }

        public void checkCollision()
        {
            Rectangle playerRect = new Rectangle((int)x, (int)y, (int)texture.Width, (int)texture.Height);

            if (playerRect.Intersects(testRect))
            {
                y = testRect.Top - texture.Height;
                yVel = 0;
                state = PlayerState.IDLE;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
            spriteBatch.Draw(texture, testRect, Color.Black);
        }
    }
}
