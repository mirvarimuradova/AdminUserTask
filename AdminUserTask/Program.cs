using AdminUserTask;
using static System.Runtime.InteropServices.JavaScript.JSType;



Profile user1 = new Profile("Zehra", "Melikzade", 20, "zarallo@gmail.com", "zahra2004", UserRole.User);

Profile user2 = new Profile("Mirvari","Muradova", 21, "mirvari@gmail.com","mirvari2003", UserRole.Admin);

ProfileController controller1 = new ProfileController(user1);
ProfileController controller2 = new ProfileController(user2);


ProfileController.Showdatas();
restart:
Console.Clear();
Console.WriteLine("Choose the section:\n" +
    "1.Sign up\n" +
    "2.Sign in\n" +
    "3.Quit");


string section = Console.ReadLine() ?? "2";
Profile newuser;
if (section == "1")
{

    Console.Write("Name:");
    string name = Console.ReadLine() ?? "Unknown";

    Console.Write("Surname:");
    string surname = Console.ReadLine() ?? "Unknown";

    Console.Write("Age:");
    int age = Convert.ToInt32(Console.ReadLine()) ;

    Console.Write("Email:");
    string email = Console.ReadLine() ?? "Unknown";

    Console.Write("Password:");
    string password = Console.ReadLine() ?? "Unknown";

wrongUserRole:
    Console.WriteLine("UserRole:\n" +
        "1.Admin\n" +
        "2.User\n");

    int role = Convert.ToInt32(Console.ReadLine());
    if (role == 1)
    {
        newuser = new Profile(name, surname, age, email, password, UserRole.Admin);

        ProfileController.SignUp(newuser);
        Console.WriteLine("Your registration is succesfully completed...");
        Console.ReadLine();
    }
    else if (role == 2)
    {
        newuser = new Profile(name, surname, age, email, password, UserRole.User);

        ProfileController.SignUp(newuser);
        Console.WriteLine("Your registration is succesfully completed...");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Wrong value:");
        goto wrongUserRole;
    }

    Console.WriteLine("Do you want to continue?y/n");

    string restart = Console.ReadLine() ?? "Unknown";

    if (restart == "y")
    {
        goto restart;
    }
    else if (restart == "n")
    {
        Console.WriteLine("The process is finished!");
    }

}
else if (section == "2")
{
    Console.Write(" Email: ");
    string email = Console.ReadLine() ?? "Unknown";

    Console.Write("Password: ");
    string password = Console.ReadLine() ?? "Unknown";

    Console.WriteLine(ProfileController.SignIn(email, password)); 

    if (UserRole.User == ProfileController.SignIn(email, password))
    {
        foreach (Profile user in ProfileController.Users)
        {
            if (user.Email == email && user.Password == password)
            {
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Surname: {user.Surname}");
                Console.WriteLine(($"Age: {user.Age}"));
            }


        }

        Console.WriteLine("Do you want to continue?y/n");

        string restart = Console.ReadLine() ?? "Unknown";

        if (restart == "y")
        {
            goto restart;
        }
        else if (restart == "n")
        {
            Console.WriteLine("The process is finished!");
        }
    }

    else if (UserRole.Admin == ProfileController.SignIn(email, password))
    {

        foreach (Profile user in ProfileController.Users)
        {
            if (user.Email == email && user.Password == password)
            {
                Console.WriteLine($" {user.Name}  {user.Surname} {user.Age} age\n");

            }

        }

        Console.WriteLine("1.Add user\n" +
            "2.Update user\n" +
            "3.Delete user\n" +
            "4.Quit");

        string temp = Console.ReadLine() ?? "Unknown";

        if (temp == "1")
        {
            Console.WriteLine("PLease include datas of user: \n");
            Console.Write("Name:");
            string name = Console.ReadLine() ?? "Unknown";

            Console.Write("Surname:");
            string surname = Console.ReadLine() ?? "Unknown";

            Console.Write("Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Email:");
            string gmail = Console.ReadLine() ?? "Unknown";

            Console.Write("Password:");
            string passwordd = Console.ReadLine() ?? "Unknown";
            Profile newprofile = new Profile(name, surname, age, gmail, passwordd, UserRole.User);

            ProfileController.SignUp(newprofile);

            Console.WriteLine("New profile succesfully added.");

            Console.WriteLine("Do you want to continue?y/n");

            string restart = Console.ReadLine() ?? "Unknown";

            if (restart == "y")
            {
                goto restart;
            }
            else if (restart == "n")
            {
                Console.WriteLine("The process is finished!");
            }

        }
        else if (temp == "2")
        {
            Console.WriteLine(" Which user do you want to update?\n");

            Console.WriteLine("Email: ");
            string gmail = Console.ReadLine() ?? "Unknown";

            Console.WriteLine("Password: ");
            string passswordd = Console.ReadLine() ?? "Unknown";


            foreach (Profile profile in ProfileController.Users)
            {
                if(profile.Email== gmail && profile.Password == passswordd)
                {
                    Console.WriteLine($"1.Name: {profile.Name}");
                    Console.WriteLine($"2.Surname: {profile.Surname}");
                    Console.WriteLine($"3.Age: {profile.Age}");
                    Console.WriteLine($"4.email: {profile.Email}");
                    Console.WriteLine($"5.password: {profile.Password}");
                    Console.WriteLine($"6.User role:: {profile.UserRole}");
                }
            }
           

                string propertynum = Console.ReadLine() ?? "Unknown";

                string newvalue = Console.ReadLine() ?? "Unknown";


            ProfileController.UpdateProfile(gmail, password, propertynum, newvalue);

        }
        else if (temp == "3")
        {

            Console.WriteLine("Which user do you want to delete?");
            Console.Write("Email: ");
            string gmail = Console.ReadLine() ?? "Unknown";

            Console.Write("Email: ");
            string Passowrd = Console.ReadLine() ?? "Unknown";

            ProfileController.Delete(gmail, Passowrd);



        }

        goto restart;
    }
}
else if (section == "3")
{
    Console.WriteLine("Program is finished");
    Console.ReadLine();
}
else
{
    Console.WriteLine("Wrong value ");
    goto restart;
}


