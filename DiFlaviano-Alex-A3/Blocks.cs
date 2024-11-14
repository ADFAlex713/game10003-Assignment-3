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

        public void MoveBlock()
        {
            moveSpeed = Random.Float(700, 800);
            position.X -= moveSpeed * Time.DeltaTime;
        }

        public void RespawnBlock()
        {
            // if block is off screen on left then respawn at random x between 1000, 4000
            if(position.X > 0)
            {
                position.X = Random.Float(1000, 4000);
            }
        }
    }
}
