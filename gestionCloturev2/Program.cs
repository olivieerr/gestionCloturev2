using System;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace gestionCloturev2
{
    class Program
    {
        abstract class GestionDate
        {
            /** fonction statique getMoisPrecedent
             * Retourne uniquement le mois précedent par rapport au mois courant
             * sous forme "mm"
             * 
             * @return string moisPrecedent
             */
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
            /** fonction statique getMoisPrecedent
            * Retourne uniquement le mois précedent par rapport à la date envoyée en paramètre
            * sous forme "mm"
            * 
            * @return string moisPrecedent
            */
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
             * Retourne le mois suivant par rapport au mois courant 
             * sous forme "mm"
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
             * Retourne le mois suivant par rapport à la date envoyée en paramètre
             * sous forme "mm"
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
                //DateTime date = new DateTime(2021, 3, 11);
                //int jourActuel = date.Day;
                int jourActuel = DateTime.Now.Day;
                if (jour1 <= jourActuel && jourActuel <= jour2)
                {
                    return true;
                }
                return false ;

            }

            /** 
             * fonction entre qui retourne vrai si la date actuelle se situe entre les 2 jours reçus en paramètre
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
                if (jour1 <= jourActuel && jourActuel <= jour2)
                {
                    return true;
                }
                return false;

            }
        }

        /**
         * 
         * La fonction clotureFicheFrais permettout d'abord de se connecter à la BDD distante puis de mttre à jour celle-ci
         * en fonction du mois courant recu en parametre
         * 
         * @param1 string date sous forme aaaamm
         * 
         */
        static void clotureFicheFrais(string date)
        {
            
            //pour test de date
            DateTime dateTest = new DateTime(2021, 01, 20);

            if (GestionDate.entre(1,10, dateTest))
            {

            
            string connStr = "server=naseb3ef3.myqnapcloud.com;port=3306;user=usergsb;database=gsb_frais;password=secret";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("connecting to MySQL...");
                conn.Open();

                string sql = "UPDATE fichefrais SET idetat = 'CL', datemodif = now()  WHERE idetat = 'CR' AND mois =" + date;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Requête de clôture executée !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + " echec de la clotureFicheFrais : " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Nous ne sommes pas entre le 1 et le 10 du mois");
            }
        }


        /**
         * Fonction miseEnRemboursement 
         * Fonction qui permet de modifier le statut des fiches de frais à "rembourser" (RB) 
         * si le comptable ne l'a pas deja fait
         * 
         * @param1 String date sous forme aaaamm
         * 
         */
        static void miseEnRemboursement(string date)
        {
            if (GestionDate.entre(20, 31))
            {

            
            string connStr = "server=naseb3ef3.myqnapcloud.com;port=3306;user=usergsb;database=gsb_frais;password=secret";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("connecting to MySQL...");
                conn.Open();

                string sql = "UPDATE fichefrais SET idetat = 'RB' WHERE idetat = 'VA' AND mois =" + date;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Requête de mise en remboursement executée !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + " echec de la clotureFicheFrais : " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Nous ne sommes pas entre le 20 et la fin du mois");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime date = new DateTime(2021, 01, 15);
            string annee = date.Year.ToString();
            string moisA = date.Month.ToString("D2");
            string moisP = GestionDate.getMoisPrecedent(date);
            //string moisA = DateTime.Now.Month.ToString("D2");
            //string moisP = GestionDate.getMoisPrecedent();
            string moisS = GestionDate.getMoisSuivant();
            bool jour = GestionDate.entre(10, 20);
            Console.WriteLine(moisP);
            Console.WriteLine(moisA);
            Console.WriteLine(moisS);
            Console.WriteLine(jour);
            Console.WriteLine(annee);

            //Concatenation de la date pour obtenir la fomre aaaamm
            string testDate = annee+moisP;

            Console.WriteLine(testDate);

            clotureFicheFrais(testDate);
            miseEnRemboursement(testDate);

            //Sommes-nous entre le 1 et le 10 du mois courant ?
            /*if (GestionDate.entre(1, 10, date))
            {
                clotureFicheFrais("202012");
            }
            else
            {
                Console.WriteLine("Nous ne sommes pas entre le 1 et le 10 du mois");
            }*/

            //sommes-nous entre le 20 et la fin du mois ?
            /*if (GestionDate.entre(20, 31, date))
            {
                miseEnRemboursement(testDate);
            }
            else
            {
                Console.WriteLine("Nous ne sommes pas entre le 20 et la fin du mois");
            }*/

            //clotureFicheFrais("202012");
            //miseEnRemboursement("202012");



        }
    }
}
