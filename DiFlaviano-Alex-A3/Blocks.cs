using System;
using System.Numerics;

namespace Game10003
{
    public class Blocks
    {
        public Vector2 position;
        public Vector2 size;
        public Color color;
        public float moveSpeed;

        public void DrawBlock()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Rectangle(position, size);
        }

        // Move Blocks accross screen at random speeds
        public void MoveBlock()
        {
            moveSpeed = Random.Float(700, 800);
            position.X -= moveSpeed * Time.DeltaTime;
        }

        // respawns block on right side of screen at random X value
        public void RespawnBlock()
        {
            // if block is off screen on left then respawn at random x and y value
            if((position.X - size.X) > 0)
            {
                position.X = Random.Float(1000, 4000);
                position.Y = Random.Float(100, 700);
            }
        }
    }
}
