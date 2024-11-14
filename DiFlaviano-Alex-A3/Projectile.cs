using System;
using System.Net;
using System.Numerics;

namespace Game10003
{
    public class Projectile
    {
        Player player = new Player();

        public Vector2 position;
        public Vector2 size;
        public Color color;
        public float moveSpeed;

        public void DrawProjectile()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Rectangle(position, size);
        }

        // fire projectile when space is pressed
        public void FireProjectile()
        {
            if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                DrawProjectile();
                moveSpeed = 250;
                position.X += moveSpeed * Time.DeltaTime;
            }
        }

        // Collision check between projectile and blocks
        public bool CollideProjWithBlock(Blocks block)
        {
            float projectileRight = position.X + size.X;
            float blockLeft = block.position.X;
            bool collideBlockLeft = projectileRight > blockLeft;
            bool collide = collideBlockLeft;

            return collide;
        }
    }
}
