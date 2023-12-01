using System;
using System.Collections.Generic;
using MvvmHelpers;

namespace JocRegals.Models
{
    public class MenuOption : ObservableObject
    {
        public int MenuID { get; set; }
        public string Description { get; set; }
        public string IimageSource { get; set; }
    }
    public class MenuOptionList : List<MenuOption>
    {
        public List<MenuOption> MenuList { get; set; }
    }
}
