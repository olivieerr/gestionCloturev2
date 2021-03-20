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

            string connStr = "server=192.168.1.103/phpmyadmin;user=essai;database=gsb_frais;port=3306;password=secret";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("connecting to MySQL...");
                conn.Open();

                string sql = "SELECT nom FROM visiteur WHERE id=a131";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string nom = Convert.ToString(result);
                    Console.WriteLine("Le nom du visiteur est : " + nom);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("echec de la connexion");
            }

            conn.Close();
            Console.WriteLine("Done");
        }
    }
}
