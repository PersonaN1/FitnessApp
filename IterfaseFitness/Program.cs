using System;
using FitnessMainLogic.Controller;
using FitnessMainLogic.Model;

namespace IterfaseFitness
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Нихуа хуа, новый пользователь");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.IsNewUser == true)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();

                //запрос и проверка
                var birthday = ParseDateTime();

                double weight = ParseDouble("Вес");
                double height = ParseDouble("Рост");

                userController.SetNewUserData(gender, birthday, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine("Введите {0} ", name);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                else Console.WriteLine("Неверный {0} ", name);
            }

        }

        private static DateTime ParseDateTime()
        {
            DateTime birthday;
            while (true)
            {
                Console.WriteLine("Введите дату рождения dd.mm.yyyy");
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                    break;
                else Console.WriteLine("Неверный формат даты рождения");
            }
            return birthday;
        }
    }
}