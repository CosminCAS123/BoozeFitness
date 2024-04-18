using BoozeFitness.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class EnterAccountVM : ViewModelBase
    {
        #region Public Properties
        public string Username { get; set; }
      
        public string Pin { get; set; }

        #endregion

        #region Private Variables
        private NavigationVM nav;
        #endregion

        #region Public Commands
        public ReactiveCommand<Unit, Unit> EnterAccountCommand { get; set; }
        #endregion
        #region Constructor
        public EnterAccountVM(NavigationVM navigationVM)
        {
            var canExecute = this.WhenAnyValue(x => x.Username, x => x.Pin, (username, pin) => !(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pin)));
            this.nav = navigationVM;
            this.EnterAccountCommand = ReactiveCommand.Create(enteracccmd , canExecute);
        }
        #endregion
        private void enteracccmd()
        {
            try
            {
                var service = new UserService();
                var user = service.GetUserByUsername(this.Username);
                //check if it matches with password
                if (string.Equals(user.PIN , this.Pin))
                {
                    //enter the app
                    this.nav.CurrentViewmodel = new MainAppVM(this.nav);

                }
                
            }
            catch
            {
                //show error
            }
        }
    }
}
