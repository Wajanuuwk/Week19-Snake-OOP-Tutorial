using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point snakeTail = new Point(15, 15, '-');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            FoodGenerator foodGenerator = new FoodGenerator(79, 24, '*');
            Point food = foodGenerator.GenerateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score++;
                }
                else
                {
                    snake.Move();
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(300);

            }
            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }

        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("_____________________________________________", xOffset, yOffset++);
            WriteText("     Haha sa kaotasid nii halb oled       ", xOffset + 1, yOffset++);
            yOffset++;
            WriteText($"      Sina said ainult {score} Punkti", xOffset + 2, yOffset++);
            WriteText("", xOffset + 1, yOffset++);
            WriteText("_____________________________________________", xOffset, yOffset++);
        }


        public static void WriteText(string text, int xOffset, int YOffset)
        {
            Console.SetCursorPosition(xOffset, YOffset);
            Console.WriteLine(text);
        }
    }
}
