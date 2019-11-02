using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;

namespace YesButYouMoreViewModel
{
    public class FinalViewModel : IViewToViewModelLink
    {
        private ICommand lookCloserCommand;
        public ICommand LookCloserCommand
        {
            get
            {
                if (lookCloserCommand == null)
                {
                    lookCloserCommand = new RelayCommand(LookCloser);
                }
                return lookCloserCommand;
            }
        }
        private void LookCloser(object sender)
        {
            Process.Start("https://www.youtube.com/user/damo0503");
            Environment.Exit(0);
        }
    }
}
