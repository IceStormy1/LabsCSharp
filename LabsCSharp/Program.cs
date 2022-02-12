using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа 1");
            Console.WriteLine("Выполнил - Толмачев Михаил Евгеньевич ВИС-32");

            #region Ex1
            var a = new Complex() { Real = 3, Imag = 0.5 };
            var b = new Complex() { Real = 2, Imag = 0.8 };

            a.Add(b);
            b.Substract(a);

            Console.WriteLine($"a = {a.Real} + {a.Imag}i");
            Console.WriteLine($"b = {b.Real} + {b.Imag}i");
            #endregion

            #region Ex2

            var firstStudent = new Student()
            {
                FirstName = "Test",
                MiddleName = "Testovich",
                LastName = "Testov",
                Gender = GenderType.Women,
                IsMarried = false,
                Orientation = OrientationType.Homo
            };

            var secondStudent = new Student()
            {
                FirstName = "Testa",
                MiddleName = "Testovna",
                LastName = "Testova",
                Gender = GenderType.Women,
                IsMarried = false,
                Orientation = OrientationType.Hetero
            };

            Student.MarryTwoStudents(firstStudent, secondStudent);

            #endregion
        }
    }
}
