using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gsb.gestionCloturev2.logic
{
    public class ClotureLogic
    {
        ///<summary>
        ///La fonction clotureFicheFrais permet tout d'abord de se connecter à la BDD distante puis de mettre à jour celle-ci
        ///en fonction du mois qui est defini dans GestionDate.entre et GestionDategetMoisPrecedent
        ///Ensuite en fonction de la date, elle met à jour la base de données en modifiant l'état des fiches de frais du mois précédent 
        ///de l'état "créée" (CR) à cloturées (CL)
        ///Elles seront ainsi visible par les comptables
        ///</summary>
        public void clotureFicheFrais()
        {

            string date = formatDate();
            Console.WriteLine(date); //a supprimer

            if (GestionDate.entre(1, 10))
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

        ///<summary>
        ///Fonction miseEnRemboursement 
        ///Fonction qui permet de modifier le statut des fiches de frais de "validées" (VA)
        ///par le comptable du mois précédent à "rembourser" (RB) 
        ///si le comptable ne l'a pas deja fait
        ///</summary>
        public void miseEnRemboursement()
        {

            string date = formatDate();

            Console.WriteLine(date);

            if (GestionDate.entre(20, 31))
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
                    Console.WriteLine(DateTime.Now.ToString() + " echec de la clotureFicheFrais : " + ex.Message); //A supprimer
                }

                conn.Close();
                Console.WriteLine("Done"); //A supprimer
            }
            else
            {
                Console.WriteLine("Nous ne sommes pas entre le 20 et la fin du mois"); //A supprimer
            }
        }

        ///<summary>
        ///Fonction formatDate
        ///a pour but de formater la date sous forme aaaamm pour l'insertion dans la base de données
        ///Elle vérifie également que nous ne sommes pas en janvier, auquel cas, elle
        ///transmet l'année précendente en plus du mois de décembre
        ///</summary>
        ///<returns name="date">au format aaaamm</returns>
        private string formatDate()
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
    }
}
