using System;

using MySql.Data.MySqlClient;

namespace gestionCloturev2
{
    class Program
    {


        //date de test
        //static DateTime dateTest = new DateTime(2021, 01, 31);

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
             * fonction entre qui retourne vrai si la date actuelle se situe entre les 2 jours reçus en parametre
             * 
             * @param1 int jour1
             * @param2 int jour2
             * 
             * @return bool
             */
            public static bool entre(int jour1, int jour2)
            {
                //initialisation au jour actuel
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
         * La fonction clotureFicheFrais permet tout d'abord de se connecter à la BDD distante puis de mettre à jour celle-ci
         * en fonction du mois courant recu en parametre
         * 
         * @param1 string date sous forme aaaamm
         * 
         */
        static void clotureFicheFrais()
        {

            string date = formatDate();
            Console.WriteLine(date); //a supprimer

            if (GestionDate.entre(1,10))
            {

            
            string connStr = "server=naseb3ef3.myqnapcloud.com;port=3306;user=usergsb;database=gsb_frais;password=secret";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("connecting to MySQL...");    //a supprimer            
                conn.Open();

                string sql = "UPDATE fichefrais SET idetat = 'CL', datemodif = now()  WHERE idetat = 'CR' AND mois =" + date;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Requête de clôture executée !"); //A supprimer
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + " echec de la clotureFicheFrais : " + ex.Message);
            }

            conn.Close();
            Console.WriteLine("Done"); //A suprrimer
            }
            else
            {
                Console.WriteLine("Nous ne sommes pas entre le 1 et le 10 du mois"); // a suppruimer
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
        static void miseEnRemboursement()
        {
            
            string date = formatDate();

            Console.WriteLine(date);

            if (GestionDate.entre(20, 31, dateTest))
            {

            
            string connStr = "server=naseb3ef3.myqnapcloud.com;port=3306;user=usergsb;database=gsb_frais;password=secret";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("connecting to MySQL..."); // Asupprimer
                conn.Open();

                string sql = "UPDATE fichefrais SET idetat = 'RB' WHERE idetat = 'VA' AND mois =" + date;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Requête de mise en remboursement executée !"); //a supprimer
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
                Console.WriteLine("Nous ne sommes pas entre le 20 et la fin du mois"); //A supprimer
            }
        }

        /** Fonction formatDatePrecedent
         * a pour but de formater la date sous forme aaaamm pour l'insertion dans la base de données
         * 
         * @return string date sous forme aaaamm
         * 
         */
        static string formatDate()
        {

            string precedent = GestionDate.getMoisPrecedent();            

            //Récupération de l'année 
            int annee = DateTime.Now.Year;          

            if (precedent == "12")
            {
                //on reduit d'une année et on convertit en string
                string moins = (annee - 1).ToString();

                //On retourne le format de la date sous forme aaaamm 
                return moins + precedent;
            }
            else
            {
                return annee + precedent;
            }
           
            

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); //a supprimer            

            clotureFicheFrais();
            miseEnRemboursement();
            
        }
    }
}
