using System;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace gestionCloturev2
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string connStr = "server=naseb3ef3.myqnapcloud.com;port=3306;user=usergsb;database=gsb_frais;password=secret";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("connecting to MySQL...");
                conn.Open();

                string sql = "SELECT nom FROM visiteur WHERE id='a131'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string nom = Convert.ToString(result);
                    Console.WriteLine(DateTime.Now.ToString() + " Le nom du visiteur est : " + nom);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + " echec de la connexion : " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done");
        }
    }
}
