using BoozeFitness.Resources;
using BoozeFitness.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class EnterAccountVM : ViewModelBase
    {
        #region Public Properties
        public string Username
        {
            get => this.username;
            set => this.RaiseAndSetIfChanged(ref this.username, value);
        }


        public string Pin
        {
            get => this.pin;
            set => this.RaiseAndSetIfChanged(ref this.pin, value);
        }
       
        public string Account_Error_Label
        {
            get => this.account_error_label;
            set => this.RaiseAndSetIfChanged(ref this.account_error_label, value);
        }
        public string Name_Error_Label
        {
            get => this.name_error_label;
            set => this.RaiseAndSetIfChanged(ref name_error_label, value);
        }

        public string Pin_Error_Label
        {
            get => this.pin_error_label;
            set => this.RaiseAndSetIfChanged(ref pin_error_label, value);
        }
        #endregion

        #region Private Variables
        private string name_error_label;
        private string username;
        private string pin;
        private string pin_error_label;
        private string account_error_label;
        private NavigationVM nav;
        #endregion

        #region Public Commands
        public ReactiveCommand<Unit, Unit> EnterAccountCommand { get; set; }
        #endregion
        #region Constructor
        public EnterAccountVM(NavigationVM navigationVM)
        {
           
            this.nav = navigationVM;
            var canExecuteName = this.WhenAnyValue(x => x.Username, (username) =>
            {
                var CanExecuteTuple = AuthObservables.NameCanExecute(username);
                this.Name_Error_Label = CanExecuteTuple.Item2;
                return CanExecuteTuple.Item1;
            });
            var canExecutePin = this.WhenAnyValue(x => x.Pin, (pin) =>
            {
                var CanExecuteTuple = AuthObservables.PinCanExecute(pin);
                this.Pin_Error_Label = CanExecuteTuple.Item2;
                return CanExecuteTuple.Item1;       
            });
            var CanExecute = canExecuteName.Merge(canExecutePin);
            this.EnterAccountCommand = ReactiveCommand.Create(enteracccmd, CanExecute);
        }
        #endregion
        private void enteracccmd()
        {


            try
            {
                var service = new UserService();
                var user = service.GetUserByUsername(this.Username);//if it doesn't exist it throws exception
                service.Dispose();//dispose the context
                if (string.Equals(user.PIN, this.Pin))//check if it matches with password
                    this.nav.CurrentViewmodel = new MainAppVM(this.nav);
                else
                {
                    //pin doesn't correspond with username error
                    this.Account_Error_Label = ErrorClass.CREDENTIALS_DONT_CORRESPOND;
                }
                
            }
            catch
            {
                //Not Found in DB error
                this.Account_Error_Label = ErrorClass.ACCOUNT_DOESNT_EXIST;
            }
        }
    }
}
