﻿namespace ItemRazorV1Real.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public User()
        {
            UserName = "";
            Password = "";
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
