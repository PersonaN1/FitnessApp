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
            var eatingController = new EatingController(userController.CurrentUser);
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

            Console.WriteLine("Что дальше?");
            Console.WriteLine("Е-ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if(key.Key==ConsoleKey.E)
            {
               var foods= EnterEating();
               eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine(item.Key+"-"+item.Value);
                }

            }
            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта");
            var food = Console.ReadLine();
         //   Console.WriteLine("Введите калорийность продукта");
            var calories = ParseDouble("калорийность");

         //   Console.WriteLine("протеины");
            var prot= ParseDouble("протеины");

         //   Console.WriteLine("жиры");
            var fats = ParseDouble("жиры");

          //  Console.WriteLine("углеводы");
            var charb = ParseDouble("углеводы");

            var weight = ParseDouble("вес");

            var product = new Food(food, calories, prot, fats, charb);
            return (product, weight);
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