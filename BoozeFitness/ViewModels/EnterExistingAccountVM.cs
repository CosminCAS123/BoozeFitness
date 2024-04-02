using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    
    public class EnterExistingAccountVM : ViewModelBase
    {
        private NavigationVM nav;
        public EnterExistingAccountVM(NavigationVM navigationVM)
        {
            this.nav = navigationVM;
        }
    }
}
