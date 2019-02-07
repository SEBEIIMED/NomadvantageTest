using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadvantageTest
{
    #region IPlayMap---------------------------------------------------------
    /// <summary>
    /// Interface IPlayMap.
    /// </summary>
    public interface IPlayMap
    {
        // Fill the map.
        int[,] FillMap(int nbRows, int nbColumns);
        //  Counts the 
        /// number of continents in a map.
        int Continents(int[,] map);
    }
    #endregion
}
