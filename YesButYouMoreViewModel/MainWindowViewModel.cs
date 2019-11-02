using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YesButYouMoreViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IViewToViewModelLink currentPage;
        public IViewToViewModelLink CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private void ChangePage(object sender)
        {
            CurrentPage = PageCollection[1];
        }

        private List<IViewToViewModelLink> pageCollection;
        public List<IViewToViewModelLink> PageCollection
        {
            get
            {
                if (pageCollection == null)
                {
                    pageCollection = new List<IViewToViewModelLink>();
                }
                return pageCollection;
            }
        }

        public MainWindowViewModel()
        {
            PageCollection.Add(new IntroViewModel());
            PageCollection.Add(new FinalViewModel());

            CurrentPage = PageCollection[0];

            Mediator.SubscribeEvent("NavFinal", ChangePage);
        }
    }

}
