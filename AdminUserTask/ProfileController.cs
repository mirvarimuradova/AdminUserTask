using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUserTask
{
    public class ProfileController
    {
        public static ArrayList Users { get; set; }



        public ProfileController(Profile user)
        {
            Users = new ArrayList();
            Users.Add(user);

        }

        public static void Showdatas() {

            foreach (Profile item in Users)
            {
                Console.WriteLine(item.Email);
                Console.WriteLine(item.Password);
            }
        }
        public static UserRole SignIn(string email, string password)
        {
            foreach (Profile user in Users)
            {

                if (user.Email == email && user.Password == password)
                {
                    return user.UserRole;
                }
               


            }
           return UserRole.None;
        }
        public static void SignUp(Profile user)
        {
            Users.Add(user);

        }

        public static void UpdateProfile(string email, string password, string number, string newvalue)
        {

            foreach (Profile user in Users)
            {

                if (user.Email == email && user.Password == password)
                {
                    switch (number)
                    {
                        case "1":
                            user.Name = newvalue;
                            Console.WriteLine(" User successfully updated");
                            break;
                        case "2":
                            user.Surname = newvalue;
                            Console.WriteLine(" User successfully updated");
                            break;
                        case "3":
                            user.Age = Convert.ToInt32(newvalue);
                            Console.WriteLine(" User successfully updated");
                            break;
                        case "4":
                            user.Email = newvalue;
                            Console.WriteLine(" User successfully updated");
                            break;
                        case "5":
                            user.Password = newvalue;
                            Console.WriteLine(" User successfully updated");
                            break;
                        case "6":
                        wrongValue:
                            Console.WriteLine("1.Admin\n" +
                                "2.User");
                            string rolenum = Console.ReadLine();
                            if (rolenum == "1")
                            {
                                user.UserRole = UserRole.Admin;
                                Console.WriteLine(" User successfully updated");
                            }
                            else if (rolenum == "2")
                            {
                                user.UserRole = UserRole.User;
                                Console.WriteLine(" User successfully updated");
                            }
                            else
                            {
                                Console.WriteLine("Wrong value");
                                goto wrongValue;
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong value:");
                            break;
                    }
                }

            }
        }

        public static void Delete(string email, string password) {


            foreach (Profile user in Users)
            {

                if (user.Email == email && user.Password == password)
                {
                   Users.Remove(user);
                    Console.WriteLine("Profile succesfully deleted.");
                }
                else { Console.WriteLine(" Email or password is not correct"); }


            }
        }
    }
}
