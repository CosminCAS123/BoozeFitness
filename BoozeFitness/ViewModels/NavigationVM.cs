using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class NavigationVM : ViewModelBase
    {
        private ViewModelBase currentvm;
        public ViewModelBase CurrentViewmodel
        {
            get => this.currentvm;
            set => this.RaiseAndSetIfChanged(ref this.currentvm, value);
        }
        public NavigationVM()
        {
            //add first viewmodel
             CurrentViewmodel = new DoYouHaveAnAccountVM(this);
            


        }
    }
}
