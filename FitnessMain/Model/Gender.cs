using System;
using System.Collections.Generic;
using System.Text;
using FitnessMainLogic.Controller;
namespace FitnessMainLogic.Model
{
    //Определим пол
    [Serializable]
    public class Gender
    {
        public string Name { get; }
        //Создаем пол
        public Gender (string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
