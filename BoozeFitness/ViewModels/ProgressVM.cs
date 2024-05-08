using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Material.Icons;
using Material.Icons.Avalonia;
using ReactiveUI;
namespace BoozeFitness.ViewModels
{
    public class ProgressVM : ViewModelBase
    {
        /*
         ICON KIND :
         medal outline - info closed
         medal - info opened
         
        the listbox will contain : 
             -


         */

        private readonly MainAppVM mainAppVM;
        private  MaterialIconKind kind;
        public MaterialIconKind MaterialIconKind
        {
            get => this.kind;
            set => this.RaiseAndSetIfChanged(ref this.kind, value);
        }
        public ProgressVM(MainAppVM mainVM)
        {
            this.mainAppVM = mainVM;
            
        }
    }
}
