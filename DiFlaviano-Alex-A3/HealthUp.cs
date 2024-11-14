using System;
using System.Numerics;

namespace Game10003
{
    public class HealthUp
    {
        public Vector2 position;
        public Vector2 size;
        public Color color;
        public float moveSpeed;


        public void DrawHealthUp()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Rectangle(position, size);
        }

        public void MoveHealthUp()
        {
            moveSpeed = Random.Float(500, 700);
            position.X -= moveSpeed * Time.DeltaTime;
        }
    }
}
