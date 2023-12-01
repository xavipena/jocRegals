using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JocRegals.Models
{
    public class Player : ObservableObject
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPhoto { get; set; }
    }
    public class PlayerList : List<Player>
    {
        public List<Player> ThePlayerList { get; set; }
    }
}
