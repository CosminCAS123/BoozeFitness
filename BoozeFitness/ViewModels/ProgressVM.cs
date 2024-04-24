using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class ProgressVM : ViewModelBase
    {
        private readonly MainAppVM mainAppVM;
        public ProgressVM(MainAppVM mainVM)
        {
            this.mainAppVM = mainVM;
        }
    }
}
