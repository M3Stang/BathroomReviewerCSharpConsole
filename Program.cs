using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BathroomReviewerCSharpConsole
{
    class Program
    {

        public static String username;
        public static String password;
        public static String Server = "192.168.0.212";
        public static String Database = "bathroom_reviewer_db";
        public static MySqlConnection logon;
        static void Main(string[] args)
        {
            Console.WriteLine("*****Bathroom Reviewer*****");
            Console.WriteLine("Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Password: ");
            password = Console.ReadLine();

            try
            {
                String connectionString = "SERVER=" + Server + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";" + "DATABASE=" + Database + ";" + "SslMode=None" + ";";
                logon = new MySqlConnection(connectionString);
                logon.Open();
                Console.Clear();
                Console.WriteLine("*****Bathroom Reviewer*****");
                Console.WriteLine("Hello " + username + " pick a choice below.");
                Console.WriteLine("\n\n1. Add Review\n\n2. View List");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Enter bathroom name: ");
                    String bathroomname = Console.ReadLine();
                    Console.Write("Is it clean? 1 for yes 2 for no: ");
                    int cleanstatus = Convert.ToInt32(Console.ReadLine());
                    String cleanstatusstring = "";
                    if (cleanstatus == 1)
                    {
                        cleanstatusstring = "Yes";
                    }
                    if (cleanstatus == 2)
                    {
                        cleanstatusstring = "No";
                    }
                    Console.Write("Would use again? 1 for yes 2 for no: ");
                    int woulduseagain = Convert.ToInt32(Console.ReadLine());
                    String woulduseagainstring = "";
                    if (woulduseagain == 1)
                    {
                        woulduseagainstring = "Yes";
                    }
                    if (woulduseagain == 2)
                    {
                        woulduseagainstring = "No";
                    }
                    Console.Write("Enter any comments: ");
                    String usercomms = Console.ReadLine();
                    try
                    {
                        String Query = "INSERT INTO br_table (bathroomName, cleanstatus, woulduseagain, userComms, latitude, longitude) VALUES ('" + bathroomname + "','" + cleanstatusstring + "','" + woulduseagainstring + "','" + usercomms + "','" + "null" + "','" + "null" + "');";
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, logon);
                        MySqlDataReader MyReader2;
                        MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        while (MyReader2.Read())
                        {
                        }
                        
                    }
                    catch (MySqlException ex)
                    {
                        String message = ex.ToString();

                    }
                
                }
                if (choice == 2)
                {
                    try {
                    Console.WriteLine("Bathroom Name -- Clean Status -- Would use again -- User Comments -- Lat -- Lon");
                    String sql = "SELECT * FROM br_table";
                    MySqlCommand cmd = new MySqlCommand(sql, logon);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                        
                    while (rdr.Read())
                    {
                    Console.WriteLine("Bathroom Name: " + rdr[0] + " -- Clean Status: " + rdr[1] + " -- Would use again: " + rdr[2] + " -- User Comments: " + rdr[3] + " -- Lat: " + rdr[4] + " -- Lon: " + rdr[5]);
                    }
                    rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    Console.ReadKey();
                }
            }
            catch (MySqlException ex)
            {
                String message = ex.ToString();
                
            }
        }
    }
}
