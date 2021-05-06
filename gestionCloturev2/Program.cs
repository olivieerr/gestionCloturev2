using System;
using System.Timers;

//using MySql.Data.MySqlClient;
using Gsb.gestionCloturev2.logic;

namespace gestionCloturev2
{
    class Program
    {


        //date de test
        //static DateTime dateTest = new DateTime(2021, 01, 31);     

        private static System.Timers.Timer timer;

        private static void rebours(Object source, ElapsedEventArgs e)
        {
            ClotureLogic toto = new ClotureLogic();

            toto.clotureFicheFrais();
            toto.miseEnRemboursement();
        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += rebours;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!"); //a supprimer

            rebours(null,null);
            SetTimer();

            Console.ReadLine();
            timer.Stop();
            timer.Dispose();

        }
    }
}