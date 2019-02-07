using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadvantageTest
{
    #region Class PlayMap----------------------------------------------------
    /// <summary>
    /// Classe PlayMap.
    /// </summary>
    public class PlayMap : IPlayMap
    {
        /// <summary>
        /// Method to fill a map
        /// </summary>
        /// <param name="nbRows">Number of rows in a map</param>
        /// <param name="nbColumns">Number of columns in a map.</param>
        /// <returns></returns>
        public int[,] FillMap(int nbRows, int nbColumns)
        {
            int[,] map = new int[nbRows, nbColumns];
            for (var i = 0; i < nbRows; i++)
            {
                for (var j = 0; j < nbColumns; j++)
                {
                    int key = (int)(Console.ReadKey().KeyChar);
                    map[i, j] = key == 49 ? 1 : 0;
                }
                Console.Write('\n');
            }

            Console.Write('\n');
            return map;
        }
        /// <summary>
        /// Method that allows
        ///to display the status
        ///of a map.
        /// </summary>
        /// <param name="map">Map of elements</param>
        private static void Printmap(int[,] map)
        {
            int nbColumns = map.GetLength(1);
            int nbRows = map.GetLength(0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Next step :\n");
            for (var i = 0; i < nbRows; i++)
            {

                for (var j = 0; j < nbColumns; j++)
                {
                    Console.BackgroundColor = map[i, j] == 1 ? ConsoleColor.Black : ConsoleColor.White;
                    Console.ForegroundColor = map[i, j] == 1 ? ConsoleColor.Black : ConsoleColor.White;
                    Console.Write('|');
                }
                Console.Write('\n');
            }

        }
        /// <summary>
        /// Recursive method that counts the 
        /// number of continents in a map.
        /// </summary>
        /// <param name="map">map of elements</param>
        /// <returns>return number of continents</returns>
        public int Continents(int[,] map)
        {
            Printmap(map); // Print the state of map.
            int nbColumns = map.GetLength(1);
            int nbRows = map.GetLength(0);

            int i = 0;
            int clRef = -1;
            bool isContour = false;
            while (i < nbRows && !isContour)
            {
                int j = 0;
                while (j < nbColumns && !isContour)
                {
                    if (map[i, j] == 1)
                    {
                        isContour = true;
                        clRef = j;
                    }
                    else
                        j++;
                }
                if (!isContour)
                    i++;
            }


            int retour = !isContour ? 0 : 1 + Continents(InitContours(map, i, clRef));
            return retour;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map">map of elements</param>
        /// <param name="i">coordinates of an element (line index)</param>
        /// <param name="j">Coordinates of an element (column index)</param>
        /// <returns>returns a matrix after the
        /// continent deletion that contains the current element
        /// (we assign 0 to all the elements of a continent)</returns>
        private int[,] InitContours(int[,] map, int i, int j)
        {
            int nbColumns = map.GetLength(1);
            int nbRows = map.GetLength(0);
            if (i < 0 || j < 0 || i >= nbRows || j >= nbColumns) return map;

            if (map[i, j] == 0) return map;
            else
            {
                //  Intialize the storytellers of an element recursively.  
                //  [i-1, j-1][i-1, j][i-1, j+1]
                //  [i,   j-1][i, j  ][i,  j+ 1]
                //  [i+1, j-1][i+1, j][i+1,  +1]

                map[i, j] = 0;
                map = InitContours(map, i - 1, j);
                map = InitContours(map, i - 1, j + 1);
                map = InitContours(map, i - 1, j - 1);
                map = InitContours(map, i, j - 1);
                map = InitContours(map, i, j + 1);
                map = InitContours(map, i + 1, j);
                map = InitContours(map, i + 1, j + 1);
                map = InitContours(map, i + 1, j - 1);
            }

            return map;
        }
    }
    #endregion
}
