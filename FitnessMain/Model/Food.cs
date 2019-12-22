using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessMainLogic.Model
{
    public class Food
    {
        public string Name { get; }
        
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; }
        
        //private double CalloriesOneGramm { get { return Calories / 100.0; } }
        //private double proteinOneGramm { get { return Proteins / 100.0; } }
        //private double FatsOneGramm { get { return Fats / 100.0; } }
        //private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name):this(name,0,0,0)
        {
        }

        public Food(string name, double protein, double fats, double carbohydrates)
        {
            //Проверка

            Name = name;
            Proteins = protein/100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
           
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
