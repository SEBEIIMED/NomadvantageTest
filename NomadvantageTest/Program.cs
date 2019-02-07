using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadvantageTest
{
    #region Classe Program---------------------------------------------------
    /// <summary>
    /// Main class for
    /// run the console app
    /// </summary>
    public class Program
    {
        #region Methods------------------------------------------------------
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">liste of arguments.</param>
        public static void Main(string[] args)
        {
            PrintTitle();
            IPlayMap playMap = new PlayMap();
            while (true)
            {
                Console.Write("Construction MAP :\n");
                Console.Write("Please enter the number of map lines : ");
                int nbRows = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter the number of map columns: ");
                int nbColumns = Convert.ToInt32(Console.ReadLine());
                Console.Write("Thank you fill in the map (1 if belongs to a continent if not 0) :\n");

                int[,] map = playMap.FillMap(nbRows, nbColumns);

                int numberContinents = playMap.Continents(map);

                PrintNumberContinents(numberContinents);
            }
            
        }
        /// <summary>
        /// Method that allows
        /// to display the title
        //// the console app.
        /// </summary>
        private static void PrintTitle()
        {
            string title = "Nomadvantage Test\n\n";
            int nbEspaces = (Console.WindowWidth - title.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.Write(title);
        }
        /// <summary>
        /// Method displays the number
        ///continents.
        /// </summary>
        /// <param name="numberContinents">Number of continents.</param>
        private static void PrintNumberContinents(int numberContinents)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(string.Format("{0}\n", numberContinents));
        }
        #endregion
    }
    #endregion
}
