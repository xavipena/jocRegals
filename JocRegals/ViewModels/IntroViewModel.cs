using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JocRegals.ViewModels
{
    public class IntroViewModel : ObservableObject
    {
        public Action DisplayInvalidLoginPrompt;

        public IntroViewModel()
        {
        }
    }
}
