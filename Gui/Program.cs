using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JobPortalGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Create an instance of DatabaseHelper
            DatabaseHelper dbHelper = new DatabaseHelper();

            // Attempt to connect to the database
            Console.WriteLine("Attempting to connect...");
            try
            {
                using (SqlConnection connection = dbHelper.GetConnection())
                {
                    connection.Open();  // Open the connection
                    Console.WriteLine("Connection successful!");
                }
            }
            catch (SqlException ex)
            {
                // If an error occurs, display the error message
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Catch any other general errors
                Console.WriteLine("Error: " + ex.Message);
            }

            // Now run the login form after testing the connection
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
