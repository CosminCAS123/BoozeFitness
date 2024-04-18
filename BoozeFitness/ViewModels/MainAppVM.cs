using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
     public class MainAppVM : ViewModelBase
    {
        private readonly NavigationVM nav;
        public MainAppVM(NavigationVM navigationVM)
        {
            this.nav = navigationVM;
        }
    }
}
