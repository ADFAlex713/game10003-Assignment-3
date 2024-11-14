// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;


// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Player player = new Player();
        Blocks[] blocks = new Blocks[10];
        HealthUp healthUp = new HealthUp();

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("2D Game");
            Window.SetSize(800, 600);


            // setup player
            player.health = 3;
            player.moveSpeed = 250;
            player.color = Color.Gray;
            player.size = new Vector2(80, 40);
            player.position = new Vector2(Window.Width - 700, Window.Height / 2);

            // setup block
            for (int i = 0; i < blocks.Length; i++)
            {
                Blocks block = new Blocks();
                float randBlockY = Random.Float(0, 600);
                block.position = new Vector2(Random.Float(1000, 4000), randBlockY);
                block.size = new Vector2(Random.Float(150, 300), Random.Float(10, 30));
                block.color = Color.Yellow;
                blocks[i] = block;
            }

            // setup health up
            float randHealthUpY = Random.Float(50, 550);
            healthUp.position = new Vector2(900, randHealthUpY);
            healthUp.size = new Vector2(20, 20);
            healthUp.color = Color.Red;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            player.DrawPlayer();
            player.PlayerMovement();
            Text.Draw($"HP: {player.health}", new Vector2(20, 20));

            for(int i = 0; i < blocks.Length;i++)
            {
                blocks[i].DrawBlock();
                blocks[i].MoveBlock();

                bool collideWithPlayer = player.CollideWithBlock(blocks[i]);
                if (collideWithPlayer)
                {
                    player.health -= 1;
                    blocks[i].position.X = Random.Float(1000, 4000);
                    blocks[i].RespawnBlock();
                }
            }
        }
    }
}
