using System;
using System.Collections.Generic;
using H3_ormtest.Model;
using H3_ormtest.ORM;

namespace H3_ormtest
{
    class Program
    {
        static void Main(string[] args)
        {

            // Instantiate ORM object
            ORM_MSSQL ORM = new ORM_MSSQL();



            // Call function from the ORM to get all users
            List<User> users = ORM.GetAllUsers();
            Console.WriteLine("Alle users:");
            foreach (User user in users)
            {
                Console.WriteLine("Navn: " + user.Name + "    Id: " + user.Id);
            }



            //Call function from ORM to get 1 user
            User userSpecific = ORM.GetUserById(2);
            Console.WriteLine("\nUser by id:\nNavn: " + userSpecific.Name + " Id: " + userSpecific.Id);



            //// Call function to create a user
            //    // Zipcode is an object, so this needs to be instantiated before passing it in
            //Zipcode zip = new Zipcode();
            //zip.Zip = 5200;

            //    // Same with usertype and department
            //UserType type = new UserType();
            //type.Id = 2;

            //    //User newUser = new User("Anna Test", "appelsinmand2021", 22334455, "Annatest@test.dk", "Testvej 127", type, zip);
            //User newUser = new User("Børge Test", "kagemand2021", 33445566, "Børgetest@test.dk", "Testvej 132", type, zip);
            //newUser = ORM.CreateNewUser(newUser);
            //Console.WriteLine("Ny bruger: ");
            //Console.WriteLine("Navn: " + newUser.Name + "Id: " + newUser.Id);



            // Call function to update a user
            if (ORM.UpdateUser("Hansi Seskarpt", 2))
            {
                Console.WriteLine("\nBruger opdateret, hurra!");
            } else
            {
                Console.WriteLine("\nÅhhh nej, noget gik galt i opdateringen af bruger!");
            }
            
            



            //// Call function to delete 1 user
            //    // DeleteUser returns a boolean depending if it went well or not
            //if (ORM.DeleteUser(1005))
            //{
            //    Console.WriteLine("Bruger er slettet, hurraaaa!");
            //} else
            //{
            //    Console.WriteLine("Hm, noget gik galt i sletningen af bruger!");
            //}
            
        }
    }
}
