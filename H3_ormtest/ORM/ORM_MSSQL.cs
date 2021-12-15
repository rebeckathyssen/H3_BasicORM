using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using H3_ormtest.Model;

namespace H3_ormtest.ORM
{
    public class ORM_MSSQL
    {
        private string sqlConnection = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=\"H3_backend\";Integrated Security=True";

        // Constructor
        public ORM_MSSQL() { }



        // Method for getting all users -- GET/READ
        public List<User> GetAllUsers()
        {
            SqlConnection conn = new SqlConnection(sqlConnection);

            List<User> allUsers = new List<User>();

            using (conn) {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Name, Password, Phone, Email, Address, UserTypeID, ZipcodeID FROM [User]";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                string Name = reader.GetString(1);
                                string Password = reader.GetString(1);
                                int Phone = reader.GetInt32(0);
                                string Mail = reader.GetString(1);
                                string Address = reader.GetString(1);
                                UserType Type = new UserType() { Id = reader.GetInt32(0) };
                                Zipcode Zip = new Zipcode() { Zip = reader.GetInt32(0) };

                                allUsers.Add(new User(Id, Name, Password, Phone, Mail, Address, Type, Zip));

                                //allUsers.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(1), reader.GetInt32(0), reader.GetString(1), reader.GetString(1), reader.GetInt32(0), reader.GetInt32(0), reader.GetInt32(0)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return allUsers;
        }



        // Method for getting 1 user based on ID -- GET(ID)/READ
        public User GetUserById(int id) 
        {
            SqlConnection conn = new SqlConnection(sqlConnection);

            User user = null;

            using (conn)
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Name, Password, Phone, Email, Address, UserTypeID, ZipcodeID FROM [User] WHERE id = @val";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@val", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(0);
                                string Name = reader.GetString(1);
                                string Password = reader.GetString(1);
                                int Phone = reader.GetInt32(0);
                                string Mail = reader.GetString(1);
                                string Address = reader.GetString(1);
                                UserType Type = new UserType() { Id = reader.GetInt32(0) };
                                Zipcode Zip = new Zipcode() { Zip = reader.GetInt32(0) };

                                user = new User(Id, Name, Password, Phone, Mail, Address, Type, Zip);
                            }
                        }
                    }
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return user;
        }



        // Method for creating a new user -- POST/CREATE
        public User CreateNewUser(User user)
        {
            SqlConnection conn = new SqlConnection(sqlConnection);

            using (conn)
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO [User] (Name, Password, Phone, Email, Address, UserTypeID, ZipcodeID) output INSERTED.ID VALUES (@Name, @Password, @Phone, @Mail, @Address, @Type, @Zip)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.Parameters.AddWithValue("@Phone", user.Phone);
                        cmd.Parameters.AddWithValue("@Mail", user.Mail);
                        cmd.Parameters.AddWithValue("@Address", user.Address);
                        cmd.Parameters.AddWithValue("@Type", user.Type.Id);
                        cmd.Parameters.AddWithValue("@Zip", user.Zip.Zip);
                        user.Id = (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return user;
        }



        // Method for updating a user -- PUT/UPDATE
        public bool UpdateUser(string name, int id)
        {
            bool wentWell = false;

            SqlConnection conn = new SqlConnection(sqlConnection);

            try
            {
                conn.Open();
                string query = "UPDATE [User] SET Name = @val WHERE ID = @val2";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@val", name);
                    cmd.Parameters.AddWithValue("@val2", id);
                    cmd.ExecuteNonQuery();
                    wentWell = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return wentWell;
        }



        // Method for deleting a user -- DELETE
        public bool DeleteUser(int id)
        {
            SqlConnection conn = new SqlConnection(sqlConnection);

            //User user = null;
            bool wentWell = false;

            using (conn)
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM [User] WHERE id = @val";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@val", id);
                        cmd.ExecuteNonQuery();
                        wentWell = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return wentWell;
            }
            
        }

    }
}
