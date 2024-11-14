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

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("2D Game");
            Window.SetSize(800, 600);


            // setup player
            //player.health = 3;
            player.moveSpeed = 250;
            player.color = Color.Gray;
            player.size = new Vector2(80, 40);
            player.position = new Vector2(Window.Width - 700, Window.Height / 2);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            player.DrawPlayer();
            player.PlayerMovement();
        }
    }
}
