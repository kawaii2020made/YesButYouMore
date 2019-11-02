using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YesButYouMoreViewModel
{
    public class IntroViewModel : BaseViewModel, IViewToViewModelLink
    {
        private bool showingNextItem = false;

        #region UI Data Binding

        private string txtTopPart;
        public string TxtTopPart
        {
            get
            {
                if (showingNextItem)
                {
                    return txtTopPart = "Mei Cute";
                }
                return txtTopPart = "";
            }
        }

        private string txtBottomPart;
        public string TxtBottomPart
        {
            get
            {
                if (showingNextItem)
                {
                    return txtBottomPart = "But who cuter?";
                }
                return txtBottomPart = "";
            }
        }

        private string txtTopButton;
        public string TxtTopButton
        {
            get
            {
                if (showingNextItem)
                {
                    return txtTopButton = "";
                }
                return txtTopPart = "Who cute?";
            }
        }

        private string txtBottomButton;
        public string TxtBottomButton
        {
            get
            {
                if (showingNextItem)
                {
                    return txtBottomButton = "IDK";
                }
                return txtBottomButton = "";
            }
        }

        #endregion

        #region Command Definition

        private void ShowNextItem(object sender)
        {
            showingNextItem = true;
            OnPropertyChanged("TxtTopPart");
            OnPropertyChanged("TxtBottomPart");
            OnPropertyChanged("TxtTopButton");
            OnPropertyChanged("TxtBottomButton");
        }
        private ICommand topButtonCommand;
        public ICommand TopButtonCommand
        {
            get
            {
                if (topButtonCommand == null)
                {
                    //Top button disables after the first click
                    topButtonCommand = new RelayCommand(ShowNextItem, condition => showingNextItem.Equals(false));
                }
                return topButtonCommand;
            }
        }
        private ICommand navFinalCommand;
        public ICommand NavFinalCommand
        {
            get
            {
                if (navFinalCommand == null)
                {
                    //Button enables after the first one is clicked
                    navFinalCommand = new RelayCommand(a => Mediator.Notify("NavFinal", ""), condition => showingNextItem.Equals(true));
                }
                return navFinalCommand;
            }
        }


        #endregion



    }
}
