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
        Projectile projectile = new Projectile();

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("2D Game");
            Window.SetSize(800, 600);

            player.health = 3;

            // Blocks Setup
            for (int i = 0; i < blocks.Length; i++)
            {
                Blocks block = new Blocks();
                float randBlockY = Random.Float(0, 600);
                block.position = new Vector2(Random.Float(1000, 4000), randBlockY);
                block.size = new Vector2(Random.Float(80, 300), Random.Float(10, 30));
                block.color = Color.Yellow;
                blocks[i] = block;
            }
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

            projectile.FireProjectile();
            
            for(int i = 0; i < blocks.Length;i++)
            {
                blocks[i].DrawBlock();
                blocks[i].MoveBlock();

                // check for collsion with block, substract 1 hp from player and respawn the block at random x position
                bool collideBlockWithPlayer = player.CollidePlayerWithBlock(blocks[i]);
                if (collideBlockWithPlayer)
                {
                    player.health -= 1;
                    blocks[i].position.X = Random.Float(1000, 4000);
                    blocks[i].RespawnBlock();
                }

                // check for collision between projectile and block, respawn block if hit
                bool collideProjectileWithBlock = projectile.CollideProjWithBlock(blocks[i]);
                if (collideProjectileWithBlock)
                {
                    blocks[i].position.X = Random.Float(1000, 4000);
                    blocks[i].RespawnBlock();
                }
            }

            // Only Spawn Health Up when player is at 1 HP
            if (player.health == 1)
            {
                healthUp.DrawHealthUp();
                healthUp.MoveHealthUp();
            }

            // check for collision with health up and add 1 hp to player
            bool collideHealthWithPlayer = player.CollideWithHealthUp(healthUp);
            if (collideHealthWithPlayer)
            {
                player.health += 1;
            }

            if(player.health == 0)
            {
                Setup();
            }

        }
    }
}
