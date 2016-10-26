//****************************************************************************************************************************
//Program:      Vintage Pong
//Description:  Using loops will create a one player pong experience inside a gdidrawer window. The paddle will follow the 
//              mouse position on the screen while the ball will bounce around based on it's velocity and direction until it 
//              collides with the left side of the screen, ending the game and displaying the score then asking for rematch
//Lab:          3
//Date:         October 28, 2016
//Author:       Jake Wilkins
//Class:        CNTA01
//Instructor:   JD Silver
//****************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Lab3_jake_wilkins
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int xVelocity = 1;                      //the rate at which the ball moves on the X plane
            int yVelocity = 1;                      //the rate at which the ball moves on the Y plane
            int xBall = 80;
            int yBall = 60;
            int wallTop = 0;                        //top boundry of screen/game
            int wallRight = 0;                      //right boundry of screen/game
            int wallBottom = 0;                     //bottom boundry of screen/game
            bool playAgain = true; 
            Point playerPosition;                   //location of mouse so paddle can be appropriately set on the Y plane

            const int playerPositionX = 0;          //the constant postion of the paddle against the left side of screen

            CDrawer gdi = new CDrawer();
            gdi.Scale = 5;
            gdi.ContinuousUpdate = false;

            do
            {
                while (true)
                {
                    //sets the boundry for the ball with as a visual
                    for (wallTop = 0; wallTop < 160; wallTop = ++wallTop)
                    {
                        gdi.SetBBScaledPixel(wallTop, 0, Color.SkyBlue);
                    }
                    for (wallRight = 0; wallRight < 120; wallRight = ++wallRight)
                    {
                        gdi.SetBBScaledPixel(wallTop - 1, wallRight, Color.SkyBlue);
                    }
                    for (wallBottom = 0; wallBottom < 160; wallBottom = ++wallBottom)
                    {
                        gdi.SetBBScaledPixel(wallBottom, wallRight - 1, Color.SkyBlue);
                    }

                    //the ball
                    while (xBall < wallRight && yBall < wallTop && yBall > wallBottom)
                    {

                        gdi.AddRectangle(xBall, yBall, 2, 2, Color.Gainsboro);

                        //the paddle
                        gdi.GetLastMousePosition(out playerPosition);

                        //playerPositionYStart = playerPositionYStart + playerPosition;
                        gdi.AddLine(playerPositionX, (playerPosition.Y + 25) / 5, playerPositionX, (playerPosition.Y - 25) / 5, Color.DarkRed, 10);



                        //the delay, new images then removal of old images to create "animation"
                        gdi.Render();
                        System.Threading.Thread.Sleep(20);
                        gdi.Clear();

                        xBall += xVelocity;
                        yBall += yVelocity;
                    }

                }

                playAgain = false;
            } while (playAgain);

        }
    }
}
