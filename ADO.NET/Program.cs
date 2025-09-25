using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

namespace ADO.NET
{
    internal class Program
    {
        class clsContacts
        {
            public int ContactID { set; get; }
            public string FirstName { set; get; }
            public string LastName { set; get; }
            public string Email{ set; get; }
            public string Phone{ set; get; }
            public string Address{ set; get; }
            public int CountryID { set; get; }
        }

        static clsContacts ReadContactFromUser()
        {

            clsContacts contact = new clsContacts();

            Console.Write("Enter The First Name: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("\nEnter The Last Name: ");
            contact.LastName = Console.ReadLine();

            Console.Write("\nEnter The Email: ");
            contact.Email = Console.ReadLine();

            Console.Write("\nEnter The Phone: ");
            contact.Phone = Console.ReadLine();

            Console.Write("\nEnter The Address: ");
            contact.Address = Console.ReadLine();

            Console.Write("\nEnter The CountryID: ");
            contact.CountryID = ReadInt();

            return contact;
        }

        static int ReadInt()
        {

            int Input = 0;

            string IntInput = Console.ReadLine();
            while (!InputIsInt(IntInput))
            {

                Console.Write("\nEnter A Valid Number: ");
                IntInput = Console.ReadLine();
            }
            Input = Convert.ToInt32(IntInput);

            return Input;
        }

        static bool InputIsInt(string CountryID)
        {

            int temp;

            return int.TryParse(CountryID, out temp);
        }

        static string connectionString = "Data Source=FAISALSC\\MSSSQLSERVER;Initial Catalog=Contacts;Integrated Security=True;";

        static void PrintAllContactsWithFirstName(string FirstName)
        {

            string query = "Select * From Contacts Where FirstName = @FirstName;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", FirstName);
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ContactID = (int)reader["ContactID"];
                            string FirstName1 = (string)reader["FirstName"];
                            string LastName = (string)reader["LastName"];
                            string Email = (string)reader["Email"];
                            string Phone = (string)reader["Phone"];
                            string Address = (string)reader["Address"];
                            int CountryID = (int)reader["CountryID"];

                            Console.WriteLine($"ContactID: {ContactID}");
                            Console.WriteLine($"FirstName: {FirstName1}");
                            Console.WriteLine($"LastName: {LastName}");
                            Console.WriteLine($"Email: {Email}");
                            Console.WriteLine($"Phone: {Phone}");
                            Console.WriteLine($"Address: {Address}");
                            Console.WriteLine($"CountryID: {CountryID}");
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void PrintAllContactsWithFirstNameAndCountryID(string FirstName, int CountryID)
        {

            string query = "SELECT * FROM Contacts WHERE FirstName = @FirstName AND CountryID = @CountryID";

            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@CountryID", CountryID);

                try
                {
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            int ContactID = (int)reader["ContactID"];
                            string FirstName1 = (string)reader["FirstName"];
                            string LastName = (string)reader["LastName"];
                            string Email = (string)reader["Email"];
                            string Phone = (string)reader["Phone"];
                            string Address = (string)reader["Address"];
                            int CountryID1 = (int)reader["CountryID"];

                            Console.WriteLine($"ContactID: {ContactID}");
                            Console.WriteLine($"FirstName: {FirstName1}");
                            Console.WriteLine($"LastName: {LastName}");
                            Console.WriteLine($"Email: {Email}");
                            Console.WriteLine($"Phone: {Phone}");
                            Console.WriteLine($"Address: {Address}");
                            Console.WriteLine($"CountryID: {CountryID1}");
                            Console.WriteLine();
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }

        static void PrintAllContacts()
        {

            string query = "SELECT * FROM Contacts";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ContactID = (int)reader["ContactID"];
                            string FirstName = (string)reader["FirstName"];
                            string LastName = (string)reader["LastName"];
                            string Email = (string)reader["Email"];
                            string Phone = (string)reader["Phone"];
                            string Address = (string)reader["Address"];
                            int CountryID = (int)reader["CountryID"];

                            Console.WriteLine($"ContactID: {ContactID}");
                            Console.WriteLine($"Name: {FirstName} {LastName}");
                            Console.WriteLine($"Email: {Email}");
                            Console.WriteLine($"Phone: {Phone}");
                            Console.WriteLine($"Address: {Address}");
                            Console.WriteLine($"CountryID: {CountryID}");
                            Console.WriteLine();
                        }
                    }                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void SearchContactsWhereFirstNameStartsWith(string StartWith)
        {

            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '' + @StartWith + '%';";

            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("StartWith", StartWith);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int ContactID = (int)reader["ContactID"];
                            string FirstName = (string)reader["FirstName"];
                            string LastName = (string)reader["LastName"];
                            string Email = (string)reader["Email"];
                            string Phone = (string)reader["Phone"];
                            string Address = (string)reader["Address"];
                            int CountryID = (int)reader["CountryID"];

                            Console.WriteLine($"ContactID: {ContactID}");
                            Console.WriteLine($"Name: {FirstName} {LastName}");
                            Console.WriteLine($"Email: {Email}");
                            Console.WriteLine($"Phone: {Phone}");
                            Console.WriteLine($"Address: {Address}");
                            Console.WriteLine($"CountryID: {CountryID}");
                            Console.WriteLine();
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void SearchContactsWhereFirstNameEndsWith(string EndsWith)
        {

            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @EndsWith + ''";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("EndsWith", EndsWith);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int ContactID = (int)reader["ContactID"];
                            string FirstName = (string)reader["FirstName"];
                            string LastName = (string)reader["LastName"];
                            string Email = (string)reader["Email"];
                            string Phone = (string)reader["Phone"];
                            string Address = (string)reader["Address"];
                            int CountryID = (int)reader["CountryID"];

                            Console.WriteLine($"ContactID: {ContactID}");
                            Console.WriteLine($"Name: {FirstName} {LastName}");
                            Console.WriteLine($"Email: {Email}");
                            Console.WriteLine($"Phone: {Phone}");
                            Console.WriteLine($"Address: {Address}");
                            Console.WriteLine($"CountryID: {CountryID}");
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void SearchContactsWhereFirstNameContains(string Contains)
        {

            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @Contains + '%'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("Contains", Contains);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            int ContactID = (int)reader["ContactID"];
                            string FirstName = (string)reader["FirstName"];
                            string LastName = (string)reader["LastName"];
                            string Email = (string)reader["Email"];
                            string Phone = (string)reader["Phone"];
                            string Address = (string)reader["Address"];
                            int CountryID = (int)reader["CountryID"];

                            Console.WriteLine($"ContactID: {ContactID}");
                            Console.WriteLine($"Name: {FirstName} {LastName}");
                            Console.WriteLine($"Email: {Email}");
                            Console.WriteLine($"Phone: {Phone}");
                            Console.WriteLine($"Address: {Address}");
                            Console.WriteLine($"CountryID: {CountryID}");
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static string GetFirstNameUsingContactID(int ContactID)
        {

            string FirstName = "";

            string query = "SELECT FirstName FROM Contacts WHERE ContactID = @ContactID";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@ContactID", ContactID);
                    
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            FirstName = result.ToString();
                        }
                        else
                        {
                            FirstName = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return FirstName;
        }

        static clsContacts FindContactByContactID(int ContactID)
        {

            string query = @"SELECT ContactID, FirstName, LastName, Email, Phone, Address, CountryID FROM Contacts WHERE ContactID = @ContactID;";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ContactID",SqlDbType.Int).Value = ContactID;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                clsContacts contact = new clsContacts();

                                contact.ContactID = reader.GetInt32(reader.GetOrdinal("ContactID"));
                                contact.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                contact.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                contact.Email = reader.GetString(reader.GetOrdinal("Email"));
                                contact.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                                contact.Address = reader.GetString(reader.GetOrdinal("Address"));
                                contact.CountryID = reader.GetInt32(reader.GetOrdinal("CountryID"));

                                return contact;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }

            return null;
        }

        static void InsertRecordToContactsTable()
        {

            clsContacts UserInput = new clsContacts();

            UserInput = ReadContactFromUser();

            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = UserInput.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = UserInput.LastName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = UserInput.Email;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = UserInput.Phone;
                command.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = UserInput.Address;
                command.Parameters.Add("@CountryID", SqlDbType.Int).Value = UserInput.CountryID;

                try
                {
                    connection.Open();

                    int RowsAffected = command.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {

                        Console.WriteLine("Record Inserted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Record Insertion Failed!");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void InsertRecordToContactsTableAndGetContactID()
        {

            clsContacts UserInput = ReadContactFromUser();

            string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                            Values (@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                            SELECT SCOPE_IDENTITY();";

            using(SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = UserInput.FirstName;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = UserInput.LastName;
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = UserInput.Email;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = UserInput.Phone;
                command.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = UserInput.Address;
                command.Parameters.Add("@CountryID", SqlDbType.Int).Value = UserInput.CountryID;

                Console.Write("\nPress Any Key To Clear The Screen And Show The Last ContactID.");
                Console.ReadKey();
                Console.Clear();

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if(result != null)
                    {
                        
                        Console.WriteLine(result);
                    }
                    else
                    {
                        
                        Console.WriteLine("ContactID Not Found!");
                    }
                }catch(Exception ex)
                {
                    
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        static void PrintContact(clsContacts contact)
        {

            if (contact == null)
            {

                Console.WriteLine("Contact Not Found!");
            }
            else
            {
                Console.WriteLine("ContactID: " + contact.ContactID);
                Console.WriteLine("FirstName: " + contact.FirstName);
                Console.WriteLine("LastName: " + contact.LastName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("Phone: " + contact.Phone);
                Console.WriteLine("Address: " + contact.Address);
                Console.WriteLine("CountryID: " + contact.CountryID);
            }
        }

        static void UpdateContact()
        {
            Console.Clear();
            PrintAllContacts();

            Console.Write("\nEnter The ContactID Of The Record You Want To Update: ");
            int ContactIDToUpdate = ReadInt();
            Console.Clear();

            clsContacts ContactToUpdate = FindContactByContactID(ContactIDToUpdate);
            PrintContact(ContactToUpdate);
            Console.Write($"\n\nAre You Sure You Want To Update This Contact? Y/N: ");
            string Sure = Console.ReadLine().Trim().ToUpper();
            if (Sure == "Y")
            {

                clsContacts UpdatedContact = ReadContactFromUser();

                string query = @"UPDATE Contacts 
                            SET FirstName = @FirstName,
                                LastName = @LastName,
                                Email = @Email,
                                Phone = @Phone,
                                Address = @Address,
                                CountryID = @CountryID
                                WHERE ContactID = @ContactID;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = UpdatedContact.FirstName;
                        command.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = UpdatedContact.LastName;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = UpdatedContact.Email;
                        command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = UpdatedContact.Phone;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = UpdatedContact.Address;
                        command.Parameters.Add("@CountryID", SqlDbType.Int).Value = UpdatedContact.CountryID;
                        command.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactIDToUpdate;

                        try
                        {

                            connection.Open();

                            int RowsAffected = command.ExecuteNonQuery();

                            if (RowsAffected > 0)
                            {
                                Console.Write("\n\n\nContact Updated Successfully :)\nThe New Contact:\n\n");
                                PrintContact(FindContactByContactID(ContactIDToUpdate));
                            }
                            else
                            {
                                Console.Write("\nRecord Not Updated!");
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                Console.Write("OK, Nothing Updated!");
            }
        }

        static void DeleteContact()
        {
            Console.Write("\nEnter The ContactID You Want To Delete: ");
            int ContactIDToDelete = ReadInt();

            clsContacts ContactToDelete = FindContactByContactID(ContactIDToDelete);
            if (ContactToDelete != null)
            {
                PrintContact(ContactToDelete);

                Console.Write("\nAre You Sure You Want To Delete This Contact? Y/N: ");
                string Sure = Console.ReadLine().Trim().ToUpper();
                if (Sure == "Y")
                {

                    string query = "DELETE FROM Contacts WHERE ContactID = @ContactID";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add("@ContactID", SqlDbType.Int).Value = ContactIDToDelete;

                            try
                            {
                                connection.Open();

                                int AffectedRows = command.ExecuteNonQuery();

                                if (AffectedRows > 0)
                                {
                                    Console.Write("\nContact Deleted Succeessfully :)");
                                }
                                else
                                {
                                    Console.Write("\nContact Deletion Failed!");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    Console.Write("\nNothing Deleted!");
                }
            }
            else
            {
                Console.Write("\nThere's No Contacts With This ID!");
            }
            
        }

        static void DeleteUsingInStatement(string ContactIDs)
        {
            string query = "DELETE FROM Contacts WHERE ContactID in (" + ContactIDs + ")";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        int RowsAffected = command.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            Console.WriteLine("Record Deleted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Record Deletion Failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            //PrintAllContactsWithFirstName("Jane");
            //PrintAllContactsWithFirstNameAndCountryID("Jane", 1);
            //SearchContactsWhereFirstNameStartsWith("jo");
            //SearchContactsWhereFirstNameEndsWith("ne");
            //SearchContactsWhereFirstNameContains("an");
            //Console.WriteLine(GetFirstNameUsingContactID(9));
            //PrintContact(FindContactByContactID(11));
            //InsertRecordToContactsTable();
            //PrintContact(FindContactByContactID(14));
            //InsertRecordToContactsTableAndGetContactID();
            //UpdateContact();
            //DeleteContact();
            //DeleteUsingInStatement("2,4");

            Console.ReadKey();
        }
    }
}
