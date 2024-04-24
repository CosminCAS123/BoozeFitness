using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class WorkoutsVM : ViewModelBase
    {
        private readonly MainAppVM mainAppVM;

        public WorkoutsVM(MainAppVM mainVM)
        {
            this.mainAppVM = mainVM;
        }

    }
}
