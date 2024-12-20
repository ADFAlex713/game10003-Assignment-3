﻿using System;
using System.Numerics;

namespace Game10003
{
    public class Player
    {
        public Vector2 position;
        public Vector2 size;
        public Color color;
        public float moveSpeed;
        public int health;

        // Player Setup
        public Player()
        {
            moveSpeed = 250;
            color = Color.Gray;
            size = new Vector2(80, 40);
            position = new Vector2(Window.Width - 700, Window.Height / 2);
        }

        public void DrawPlayer()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Rectangle(position, size);
        }

        // Controls for Player Movement
        public void PlayerMovement()
        {
            // Move Left
            if(Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                position.X -= moveSpeed * Time.DeltaTime;
            }
            // Move Right
            if(Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                position.X += moveSpeed * Time.DeltaTime;
            }
            // Move Up
            if(Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                position.Y -= moveSpeed * Time.DeltaTime;
            }
            // Move Down
            if(Input.IsKeyboardKeyDown (KeyboardInput.S))
            {
                position.Y += moveSpeed * Time.DeltaTime;
            }

            // Constrain left
            if (position.X < 0)
            {
                position.X = 0;
            }
            // Constrain right
            if (position.X + size.X > Window.Width / 2)
            {
                position.X = (Window.Width/2) - size.X;
            }
            // Constrain top
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            // Contrain bottom
            if (position.Y +size.Y > Window.Height)
            {
                position.Y= Window.Height - size.Y;
            }
        }

        // Player Collision with Health Up
        public bool CollideWithHealthUp(HealthUp healthUp)
        {
            float playerLeft = position.X;
            float playerRight = position.X + size.X;
            float playerTop = position.Y;
            float playerBottom = position.Y + size.Y;

            float healthUpLeft = healthUp.position.X;
            float healthUpRight = healthUp.position.X + healthUp.position.X;
            float healthUpTop = healthUp.position.Y;
            float healthUpBottom = healthUp.position.Y + healthUp.position.Y;

            bool collideHealthUpLeft = playerRight > healthUpLeft;
            bool collideHealthUpRight = playerLeft > healthUpRight;
            bool collideHealthUpTop = playerBottom > healthUpTop;
            bool collideHealthUpBottom = playerTop > healthUpBottom;
            bool collide = collideHealthUpLeft && collideHealthUpRight && collideHealthUpTop && collideHealthUpBottom;

            return collide;
        }

        // Player Collision with Block Obstacles
        public bool CollidePlayerWithBlock(Blocks block)
        {
            float playerLeft = position.X;
            float playerRight = position.X + size.X;
            float playerTop = position.Y;
            float playerBottom = position.Y + size.Y;

            float blockLeft = block.position.X;
            float blockRight = block.position.X + block.position.X;
            float blockTop = block.position.Y;
            float blockBottom = block.position.Y + block.position.Y;

            bool collideBlockLeft = playerRight > blockLeft;
            bool collideBlockRight = playerLeft > blockRight;
            bool collideBlockTop = playerBottom > blockTop;
            bool collideBlockBottom = playerTop > blockBottom;
            bool collide = collideBlockLeft && collideBlockRight && collideBlockTop && collideBlockBottom;

            return collide;
        }
    }
}
