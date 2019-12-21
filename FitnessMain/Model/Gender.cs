using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessMainLogic.Model
{
    //Определим пол
    public class Gender
    {
        public string Name { get; }
        //Создаем пол
        public Gender (string name)
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым", nameof(Name));
            }
            Name = name;
        }
    }
}
