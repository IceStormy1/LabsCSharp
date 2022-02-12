using System;

namespace Lab1
{
    public class Student
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Показывает, женат ли студент
        /// </summary>
        public bool IsMarried { get; set; }

        /// <summary>
        /// Пол студента (мужчина / женшина)
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Отображает ориентацию студента
        /// </summary>
        public OrientationType Orientation { get; set; }

        /// <summary>
        /// Партнер студента
        /// </summary>
        public Student Partner { get; private set; }

        public static void MarryTwoStudents(Student firstStudent, Student secondStudent)
        {
            if (!firstStudent.Orientation.Equals(secondStudent.Orientation))
            {
                Console.WriteLine("Увы, они не подходят друг другу");
                return;
            }

            if (firstStudent.IsMarried || secondStudent.IsMarried)
            {
                Console.WriteLine("Кто-то из них уже занят");
                return;
            }

            firstStudent.Partner = secondStudent;
            secondStudent.Partner = firstStudent;

            Console.WriteLine($"Поздравляем молодожен {firstStudent.FirstName} и {secondStudent.FirstName}");
        }

    }
}
