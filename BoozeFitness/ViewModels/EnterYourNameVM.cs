using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class EnterYourNameVM : ViewModelBase
    {

        private NavigationVM nav;
        private string username;
        
        public string Username
        {
            get => this.username;
            set => this.RaiseAndSetIfChanged(ref this.username, value);
        }

        public EnterYourNameVM(NavigationVM navigationVM)
        {
            this.nav = navigationVM;
        }



    }
}
