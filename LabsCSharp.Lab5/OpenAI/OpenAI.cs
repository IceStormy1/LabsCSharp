using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using PluginInterface;

namespace OpenAI
{
    public class OpenAI : ISmartSnake
    {
        public string Name { get; set; }
        public Move Direction { get; set; }
        public bool Reverse { get; set; }
        public Color Color { get; set; }

        public List<Point> CurrentStones { get; set; }

        public void Startup(Size size, List<Point> stones)
        {
          Color = Color.Aqua;
          CurrentStones = stones;
        }

        public void Update(Snake snake, List<Snake> enemies, List<Point> foods, List<Point> dead)
        {
            var food = foods
                .OrderBy(x=>x.X)
                .ThenBy(x=>x.Y)
                .FirstOrDefault();

            if (snake.Position.X < food.X || snake.Position.Y < food.Y)
            {
                if (snake.Position.X - food.X < snake.Position.Y - food.Y)
                {
                    if (!CurrentStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y))
                        & !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                    {
                        Console.WriteLine("Move.Right\t1.1");
                        Direction = Move.Right;
                    }
                    else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                    {
                        Console.WriteLine("Move.Down\t1.1");
                        Direction = Move.Down;
                    }
                    else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                    {
                        Console.WriteLine("Move.Up\t1.1");
                        Direction = Move.Up;
                    }
                    else
                    {
                        Console.WriteLine("Reverse = true\t1.1");
                        Reverse = true;
                        Console.WriteLine("Reverse = true => Move.Up\t1.1");
                        Direction = Move.Up;
                    }
                }
                else if (snake.Position.X - food.X > snake.Position.Y - food.Y)
                {
                    if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1))
                        && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                    {
                        Console.WriteLine("Move.Down\t1.2");
                        Direction = Move.Down;
                    }
                    else if (!CurrentStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y))
                             && !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                    {
                        Console.WriteLine("Move.Left\t1.2");
                        Direction = Move.Left;
                    }
                    else if (!CurrentStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y))
                             && !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                    {
                        Console.WriteLine("Move.Right\t1.2");
                        Direction = Move.Right;
                    }
                    else
                    {
                        Console.WriteLine("Reverse = true\t1.2");
                        Reverse = true;
                        Console.WriteLine("Reverse = true => Move.Right\t1.2");
                        Direction = Move.Right;
                    }

                }
            }

            if (!(snake.Position.X > food.X || snake.Position.Y > food.Y))
                return;

            // если дальше по Х то
            if (snake.Position.X - food.X > snake.Position.Y - food.Y)
            {
                if (!CurrentStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y))
                    && !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                {
                    Console.WriteLine("Move.Left\t1.3");
                    Direction = Move.Left;
                }
                else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1))
                         && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                {
                    Console.WriteLine("Move.Up\t1.3");
                    Direction = Move.Up;
                }
                else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1))
                         && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                {
                    Console.WriteLine("Move.Down\t1.3");
                    Direction = Move.Down;
                }
                else
                {
                    Console.WriteLine("Reverse = true\t1.3");
                    Reverse = true;
                    Console.WriteLine("Reverse = true => Move.Down\t1.3");
                    Direction = Move.Down;
                }
            }
            else if (snake.Position.X - food.X < snake.Position.Y - food.Y)
            {
                if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1)) 
                    && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                {
                    Console.WriteLine("Move.Up\t1.4");
                    Direction = Move.Up;
                }
                else if (!CurrentStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y))
                         && !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                {
                    Console.WriteLine("Move.Right\t1.4");
                    Direction = Move.Right;
                }
                else if (!CurrentStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y))
                         && !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                {
                    Console.WriteLine("Move.Left\t1.4");
                    Direction = Move.Left;
                }
                else
                {
                    Console.WriteLine("Reverse = true\t1.4");
                    Reverse = true;
                    Console.WriteLine("Reverse = true => Move.Left\t1.4");
                    Direction = Move.Left;
                }
            }
        }
    }
}
