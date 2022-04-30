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
            // Сортируем всю коллекцию еды сначала по оси Х, потом по оси Y
            // и берем самый первый
            var food = foods
                .OrderBy(x=>x.X)
                .ThenBy(x=>x.Y)
                .FirstOrDefault();

            // 3 четверть (-,-) 1.1
            // сначала определяем , какое растояние больше по оси Х  или по оси Y
            if (snake.Position.X < food.X || snake.Position.Y < food.Y)
            {
                // если дальше по Х то
                if (snake.Position.X - food.X < snake.Position.Y - food.Y)
                {
                    // если на пути направо нет камня, двигаемся вправо, иначе по часовой (вниз)
                    if (!CurrentStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y))
                        & !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                    {
                        Console.WriteLine("Move.Right\t1.1");
                        Direction = Move.Right;
                    }
                    // иначе по часовой (вниз)
                    else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                    {
                        Console.WriteLine("Move.Down\t1.1");
                        Direction = Move.Down;
                    }
                    // проверяем возможность хода вверх
                    else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1)) & !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                    {
                        Console.WriteLine("Move.Up\t1.1");
                        Direction = Move.Up;
                    }
                    // проверяем возможность хода вверх
                    else
                    {
                        Console.WriteLine("Reverse = true\t1.1");
                        Reverse = true;
                        Console.WriteLine("Reverse = true => Move.Up\t1.1");
                        Direction = Move.Up;
                    }
                }
                // если дальше по Y то 1.2
                else if (snake.Position.X - food.X > snake.Position.Y - food.Y)
                {
                    // если на пути вниз нет камня, двигаемся вниз, иначе по часовой (влево)
                    if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1))
                        && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                    {
                        Console.WriteLine("Move.Down\t1.2");
                        Direction = Move.Down;
                    }
                    // иначе по часовой (влево)
                    else if (!CurrentStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y))
                             && !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                    {
                        Console.WriteLine("Move.Left\t1.2");
                        Direction = Move.Left;
                    }
                    // проверяем возможность хода направо
                    else if (!CurrentStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y))
                             && !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                    {
                        Console.WriteLine("Move.Right\t1.2");
                        Direction = Move.Right;
                    }
                    // проверяем возможность хода направо
                    else
                    {
                        Console.WriteLine("Reverse = true\t1.2");
                        Reverse = true;
                        Console.WriteLine("Reverse = true => Move.Right\t1.2");
                        Direction = Move.Right;
                    }

                }
            }

            // 1 четверть (+,+) 1.3
            // сначала определяем , какое растояние больше по оси Х  или по оси Y
            if (!(snake.Position.X > food.X || snake.Position.Y > food.Y))
                return;

            // если дальше по Х то
            if (snake.Position.X - food.X > snake.Position.Y - food.Y)
            {
                // если на пути налево нет камня, двигаемся влево, иначе по часовой (вверх)
                if (!CurrentStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y))
                    && !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                {
                    Console.WriteLine("Move.Left\t1.3");
                    Direction = Move.Left;
                }
                // иначе по часовой (вверх)
                else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1))
                         && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                {
                    Console.WriteLine("Move.Up\t1.3");
                    Direction = Move.Up;
                }
                // проверяем возможность хода вниз
                else if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y + 1))
                         && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y + 1)))
                {
                    Console.WriteLine("Move.Down\t1.3");
                    Direction = Move.Down;
                }
                // проверяем возможность хода вниз
                else
                {
                    Console.WriteLine("Reverse = true\t1.3");
                    Reverse = true;
                    Console.WriteLine("Reverse = true => Move.Down\t1.3");
                    Direction = Move.Down;
                }
            }
            // если дальше по Y то 1.4
            else if (snake.Position.X - food.X < snake.Position.Y - food.Y)
            {
                // если на пути налево нет камня, двигаемся вверх, иначе по часовой (вправо)
                if (!CurrentStones.Contains(new Point(snake.Position.X, snake.Position.Y - 1)) 
                    && !snake.Tail.Contains(new Point(snake.Position.X, snake.Position.Y - 1)))
                {
                    Console.WriteLine("Move.Up\t1.4");
                    Direction = Move.Up;
                }
                // иначе по часовой (вверх)
                else if (!CurrentStones.Contains(new Point(snake.Position.X + 1, snake.Position.Y))
                         && !snake.Tail.Contains(new Point(snake.Position.X + 1, snake.Position.Y)))
                {
                    Console.WriteLine("Move.Right\t1.4");
                    Direction = Move.Right;
                }
                // проверяем возможность хода налево
                else if (!CurrentStones.Contains(new Point(snake.Position.X - 1, snake.Position.Y))
                         && !snake.Tail.Contains(new Point(snake.Position.X - 1, snake.Position.Y)))
                {
                    Console.WriteLine("Move.Left\t1.4");
                    Direction = Move.Left;
                }
                // проверяем возможность хода влево
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
