
using System;

namespace Gsb.gestionCloturev2.logic
{

    public abstract class GestionDate
    {
        /// <summary>fonction statique getMoisPrecedent
        /// retourne uniquement le mois précedent par rapport à la date envoyée en paramètre
        /// sous forme "mm"</summary>
        /// <returns>string moisPrecedent</returns>
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


        /// <summary>fonction statique getMoisPrecedent
        /// Retourne uniquement le mois précedent par rapport à la date envoyée en paramètre
        /// sous forme "mm"</summary>
        /// <param name="date">date</param>
        /// <returns>string moisPrecedent</returns>
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

        /// <summary>Fonction statique getMoisSuivant
        /// Retourne le mois suivant par rapport au mois courant
        /// sous forme "mm"</summary>
        /// <returns>string moisSuivant</returns>
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

        /// <summary>Fonction statique getMoisSuivant
        /// Retourne le mois suivant par rapport à la date envoyée en paramètre
        /// sous forme "mm"</summary>
        /// <param name="date">The date.</param>
        /// <returns>string moisSuivant</returns>
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

        ///<summary>
        ///fonction entre qui retourne vrai si la date actuelle se situe entre les 2 jours reçus en parametre
        ///</summary>
        ///<param name="jour1">int</param>
        ///<param name="jour2">int</param>
        ///<returns>bool</returns>
        public static bool entre(int jour1, int jour2)
        {
            //initialisation au jour actuel
            int jourActuel = DateTime.Now.Day;
            if (jour1 <= jourActuel && jourActuel <= jour2)
            {
                return true;
            }
            return false;

        }

        /// <summary>fonction entre qui retourne vrai si la date actuelle se situe entre les 2 jours reçus en paramètre</summary>
        /// <param name="jour1">int</param>
        /// <param name="jour2">int</param>
        /// <param name="date">DateTime</param>
        /// <returns>bool</returns>
        public static bool entre(int jour1, int jour2, DateTime date)
        {

            int jourActuel = date.Day;
            if (jour1 <= jourActuel && jourActuel <= jour2)
            {
                return true;
            }
            return false;

        }
    }    
}
