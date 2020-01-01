using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using FitnessMainLogic.Model;
using System.Linq;

namespace FitnessMainLogic.Controller
{
    public class EatingController:BaseController
    {
        private const string Foods_FL = "food.dat";
        private const string Eating_FL = "eating.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        //public bool Add(string foodName, double weight)
        //{
        //    var food = Foods.SingleOrDefault(f => f.Name == foodName);
        //    if (food != null)
        //    {
        //        Eating.Add(food, weight);
        //        Save();
        //        return true;
        //    }
        //    return false;
        //}

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(Eating_FL) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(Foods_FL) ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods_FL, Foods);
            Save(Eating_FL, Eating);
        }
    }
}
