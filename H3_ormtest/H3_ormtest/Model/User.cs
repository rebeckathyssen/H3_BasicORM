using System;
using System.Collections.Generic;
using System.Text;

namespace H3_ormtest.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public UserType Type { get; set; }
        public Zipcode Zip { get; set; }

        public User(string name, string password, int phone, string mail, string address, UserType type, Zipcode zip)
        {
            Name = name;
            Password = password;
            Phone = phone;
            Mail = mail;
            Address = address;
            Type = type;
            Zip = zip;            
        }

        // Overloading constructor 
        public User(int id, string name, string password, int phone, string mail, string address, UserType type, Zipcode zip) {
            Id = id;
            Name = name;
            Password = password;
            Phone = phone;
            Mail = mail;
            Address = address;
            Type = type;
            Zip = zip;

        }
    }
}
