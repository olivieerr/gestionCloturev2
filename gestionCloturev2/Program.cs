using System;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace gestionCloturev2
{
    class Program
    {
        abstract class GestionDate
        {
            public static string getMoisPrecedent()
            {
                //déclaration des variables
                //num initialisée au mois courant
                int num = DateTime.Now.Month;
                string moisPrecedent;

                //on verifie si nous sommes en janvier
                if (num == 1)
                {
                    int mois = 12;
                    moisPrecedent = mois.ToString("D2");
                }
                else
                {
                    int mois = num - 1;
                    moisPrecedent = mois.ToString("D2");
                }

                return moisPrecedent;
                
            }
            public static string getMoisPrecedent(DateTime date)
            {
                int num = date.Month;
                string moisPrecedent;
                if (num == 1)
                {
                    int mois = 12;
                    moisPrecedent = mois.ToString("D2");
                }
                else
                {
                    int mois = num - 1;
                    moisPrecedent = mois.ToString("D2");
                }

                return moisPrecedent;
            }

            /** 
             * Fonction statique getMoisSuivant
             * Retourne sous le mois suivant le mois actuel sous forme "mm"
             * 
             * @return string moisSuivant
             * 
             */
            public static string getMoisSuivant()
            {
                //déclaration des variables
                //num initialisée au mois courant
                int num = DateTime.Now.Month;
                string moisSuivant;

                //on verifie si nous sommes au mois de décembre
                if (num == 12)
                {
                    int mois = 1;
                    moisSuivant = mois.ToString("D2");
                }
                else
                {
                    int mois = num + 1;
                    moisSuivant = mois.ToString("D2");
                }

                return moisSuivant;
            }

            /**
             *  Fonction statique getMoisSuivant
             * Retourne sous le mois suivant le mois actuel sous forme "mm"
             * 
             * @param DateTime date
             * 
             * @return string moisSuivant
             * 
             */
            public static string getMoisSuivant(DateTime date)
            {
                int num = date.Month;
                string moisSuivant;
                if (num == 1)
                {
                    int mois = 12;
                    moisSuivant = mois.ToString("D2");
                }
                else
                {
                    int mois = num - 1;
                    moisSuivant = mois.ToString("D2");
                }

                return moisSuivant;
            }
            /** 
             * fonction entre qui retourne vrai si la date actuelle se situe entre les 2 jours reçus en parametre
             * 
             * @param1 int jour1
             * @param2 int jour2
             * 
             * @return bool
             */
            public static bool entre(int jour1, int jour2)
            {
                //DateTime date = new DateTime(2021, 3, 9);
                //int jourActuel = date.Day;
                 int jourActuel = DateTime.Now.Day;
                if (jour1 < jourActuel && jourActuel < jour2)
                {
                    return true;
                }
                return false ;

            }

            /** 
             * fonction entre qui retourne vrai si la date actuelle se situe entre les 2 jours reçus en parametre
             * 
             * @param1 int jour1
             * @param2 int jour2
             * @param3 DateTime date
             * 
             * @return bool
             */
            public static bool entre(int jour1, int jour2, DateTime date)
            {
                //DateTime date = new DateTime(2021, 3, 9);
                //int jourActuel = date.Day;
                int jourActuel= date.Day;
                if (jour1 < jourActuel && jourActuel < jour2)
                {
                    return true;
                }
                return false;

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string moisA = DateTime.Now.Month.ToString("D2");
            string moisP = GestionDate.getMoisPrecedent();
            string moisS = GestionDate.getMoisSuivant();
            bool jour = GestionDate.entre(10, 20);
            Console.WriteLine(moisP);
            Console.WriteLine(moisA);
            Console.WriteLine(moisS);
            Console.WriteLine(jour);

            string connStr = "server=naseb3ef3.myqnapcloud.com;port=3306;user=usergsb;database=gsb_frais;password=secret";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("connecting to MySQL...");
                conn.Open();

                string sql = "SELECT nom FROM visiteur WHERE id='a17'";
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
