using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace contactWinForm
{
    class DataAccessLayer
    {
        static string conexName = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Contacts;Data Source=DESKTOP-VBU73D2\\SQLEXPRESS";
        private SqlConnection conexion = new SqlConnection(conexName);

        public void InsertContact(Contact contact)
        {
            try
            {
                conexion.Open();
                string query = @"
                   INSERT INTO Contacts (FirstName, LastName, Phone, Address)
                   VALUES (@FirstName, @Lastname, @Phone, @Address)
                ";

                SqlParameter firstName = new SqlParameter();
                firstName.ParameterName = "@FirstName";
                firstName.Value = contact.FirstName;
                firstName.DbType = System.Data.DbType.String;

                SqlParameter lastName = new SqlParameter("@Lastname", contact.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contact.Phone);
                SqlParameter address = new SqlParameter("@Address", contact.Address);

                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                conexion.Close();
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                conexion.Open();
                string query = @"
                    UPDATE Contacts SET 
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Phone = @Phone,
                        Address = @Address
                    WHERE ID = @ID
                ";

                SqlParameter id = new SqlParameter("@ID", contact.ID);
                SqlParameter firstName = new SqlParameter("@FirstName", contact.FirstName);
                SqlParameter lastName = new SqlParameter("@Lastname", contact.LastName);
                SqlParameter phone = new SqlParameter("@Phone", contact.Phone);
                SqlParameter address = new SqlParameter("@Address", contact.Address);

                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.Add(id);
                command.Parameters.Add(firstName);
                command.Parameters.Add(lastName);
                command.Parameters.Add(phone);
                command.Parameters.Add(address);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally { conexion.Close(); }
        }
        public void DeleteContact(int id)
        {
            try
            {
                conexion.Open();
                string query = @"
                    DELETE FROM Contacts
                    WHERE ID = @ID;
                ";

                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.Add(new SqlParameter("@ID", id));

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally { conexion.Close(); }
        }

        public List<Contact> GetContacts(string searchText = null)
        {
            List<Contact> contacts = new List<Contact>();


            try
            {
                conexion.Open();
                string query = @"
                    SELECT 
                        ID,
                        FirstName, 
                        LastName, 
                        Phone, 
                        Address
                    FROM Contacts
                ";

                SqlCommand command = new SqlCommand();

                if (!string.IsNullOrEmpty(searchText))
                {
                    query += @"
                        WHERE FirstName LIKE @searchText 
                        OR
                        LastName LIKE @searchText 
                        OR 
                        Phone LIKE @searchText
                        OR
                        Address LIKE @searchText
                        ";
                    command.Parameters.Add(new SqlParameter("@searchText", $"%{searchText}%"));
                }

                command.CommandText = query;
                command.Connection = conexion;


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString()
                    };


                    contacts.Add(contact);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return contacts;
        }

    }
}
