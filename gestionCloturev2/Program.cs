using System;

//using MySql.Data.MySqlClient;
using Gsb.gestionCloturev2.logic;

namespace gestionCloturev2
{
    class Program
    {


        //date de test
        //static DateTime dateTest = new DateTime(2021, 01, 31);     



        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); //a supprimer
            ClotureLogic toto = new ClotureLogic();

            toto.clotureFicheFrais();
            toto.miseEnRemboursement();

        }
    }
}