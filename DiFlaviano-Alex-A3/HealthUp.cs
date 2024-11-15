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
        
        // Setup Health Up
        public HealthUp()
        {
            float randHealthUpY = Random.Float(50, 550);
            position = new Vector2(900, randHealthUpY);
            size = new Vector2(20, 20);
            color = Color.Red;
        }

        public void DrawHealthUp()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Black;
            Draw.FillColor = color;
            Draw.Rectangle(position, size);
        }

        // Move Health Up Block
        public void MoveHealthUp()
        {
            moveSpeed = Random.Float(500, 700);
            position.X -= moveSpeed * Time.DeltaTime;
        }
    }
}
