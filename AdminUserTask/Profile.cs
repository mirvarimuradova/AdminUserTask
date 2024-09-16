﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUserTask
{
    public class Profile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public Profile(string name, string surname, int age, string email, string password, UserRole userrole)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
            UserRole = userrole;

        }
    }
}
