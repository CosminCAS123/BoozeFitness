using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class DoYouHaveAnAccountVM : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> CreateAccountCommand { get; set; }

        public ReactiveCommand<Unit, Unit> ExistingAccountCommand
        {
            get;set;
        }
        private NavigationVM nav = null!;
        public DoYouHaveAnAccountVM(NavigationVM navigationVM)
        {
            nav = navigationVM;
            CreateAccountCommand = ReactiveCommand.Create(SwitchToCreateAcc);
            ExistingAccountCommand = ReactiveCommand.Create(SwitchToExistingAcc);
        }

        private void SwitchToCreateAcc() => this.nav.CurrentViewmodel = new EnterYourNameVM(nav);
        private void SwitchToExistingAcc() => this.nav.CurrentViewmodel = new EnterExistingAccountVM(nav);
       

    }
}
