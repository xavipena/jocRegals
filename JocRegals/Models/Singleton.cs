using System;
using System.Collections.Generic;
using System.Text;

namespace JocRegals.Models
{
    static public class Singleton
    {
        static public int levelOneSelection = 0;
        static public int levelTwoSelection = 0;
        static public int currentRound = 0;

        static public string levelOneTitle = string.Empty;
        static public string levelTwoTitle = string.Empty;

        static public string icon = string.Empty;

        static public List<Player> listOfPlayers = new List<Player>();
        static public int gameMinutes;
        static public int numberOfGifts;
    }
}
