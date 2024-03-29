﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using FitnessMainLogic.Model;
using System.Linq;

namespace FitnessMainLogic.Controller
{

    /// <summary>
    /// контроллер пользователя
    /// </summary>
    public class UserController: BaseController
    {
        /// <summary>
        /// Пользователь
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        private const string User_FL = "user.dat";

        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не мб пустым", nameof(userName));
            }

            //Users = new List<User>();

            Users = GetUserData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
            


        }

        /// <summary>
        /// Получение пользователя или создание нового списка пользователей
        /// </summary>
        /// <returns></returns>

        //private List<User> GetUserData()
        //{
        //    var formatter = new BinaryFormatter();
        //    using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
        //    {

        //        if (fs.Length>0 && formatter.Deserialize(fs) is List<User> users)
        //            return users;
        //        else
        //            return new List<User>();
        //    }
        //}

        private List<User> GetUserData()
        {
            return Load<List<User>>(User_FL) ?? new List<User>();
        }
        public void SetNewUserData(string genderName, DateTime birthDay, double weight=1, double height=1)
        {
            //Проверка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        ///<summary>
        ///Сохранение данных пользователя
        ///</summary>
        //public void Save()
        //{
        //    var formatter = new BinaryFormatter();
        //    using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
        //    {
        //        formatter.Serialize(fs, Users);
        //    }
        //}
        public void Save()
        {
            base.Save(User_FL, Users);
        }
    }
}
