using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class ProfileVM : ViewModelBase
    {
        private readonly MainAppVM mainAppVM;
        public ProfileVM(MainAppVM mainVM)
        {
            this.mainAppVM = mainVM;
        }
    }
}
