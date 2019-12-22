using System;
using FitnessMainLogic.Controller;

namespace FitnessMainLogic.Model
{
    [Serializable]
    public class User
    {


        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        // <param   name = "name"> Имя. </param>
        // <param  gender = "gender"> Пол. </param>
        //  <param  birthDate = "birthday"> Дата рождения. </param>
        //   <param  weight = "weight"> Вес.</param>
        //   <param  height = "height"> Рост.</param>
        public User(string name, Gender gender, DateTime birthday, double weight, double height)
        {
            #region //проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            if (gender==null)
            {
                throw new ArgumentNullException("Имя пола не может быть пустым", nameof(gender));
            }
            if (birthday < DateTime.Parse("01.01.1920")&& birthday>=DateTime.Now)
            {
                throw new ArgumentException("Нужно указать возраст", nameof(birthday));
            }
            if (weight<=0)
            {
                throw new ArgumentException("Вес не может быть меньше 0", nameof(weight));
            }
            if (height<=0)
            {
                throw new ArgumentException("Рост не может быть меньше 0", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthday;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
