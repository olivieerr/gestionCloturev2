using System;
using System.Timers;
using Gsb.gestionCloturev2.logic;

namespace gestionCloturev2
{
    class Program
    {


        //date de test
        //static DateTime dateTest = new DateTime(2021, 01, 31);     

        private static System.Timers.Timer timer;
        private const int TEMPS = 10000; // A modifier en fonction de la durée souhaitée

        private static void rebours(Object source, ElapsedEventArgs e)
        {
            ClotureLogic service = new ClotureLogic();

            service.clotureFicheFrais();
            service.miseEnRemboursement();
        }
        private static void SetTimer()
        {
            
            timer = new System.Timers.Timer(TEMPS);
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