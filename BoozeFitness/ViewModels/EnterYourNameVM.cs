using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    /*
     Name cannot be empty
     Name cannot contain special characters(only english letters and digits)
     Name cannot have any whitespaces
     */
    public class EnterYourNameVM : ViewModelBase
    {
        private bool first_time_entering = true;
        private NavigationVM nav;
        private string username;
        private string error_label = ErrorClass.NO_ERROR;
        public ReactiveCommand<Unit , Unit> GoToPinCommand { get; set; }

        public string Username
        {
            get => this.username;
            set => this.RaiseAndSetIfChanged(ref this.username, value);
        }
        public string Error_Label
        {
            get => this.error_label;
            set => this.RaiseAndSetIfChanged(ref error_label, value);
        }

      
       
        public EnterYourNameVM(NavigationVM navigationVM)
        {
            this.nav = navigationVM;
            var canExecute = this.WhenAnyValue(x => x.Username, (userName) =>
            {
                
                if (string.IsNullOrEmpty(userName))
                {
                     if (!first_time_entering) Error_Label = ErrorClass.NAME_IS_EMPTY_ERROR;
                    else first_time_entering = false;   
                    return false;
                }
                if (!userName.All(char.IsLetterOrDigit))
                {
                    Error_Label = ErrorClass.NAME_CONTAINS_OTHER_CHAR;      
                    return false;
                }
                Error_Label = ErrorClass.NO_ERROR;
                return true;
            });
           
            GoToPinCommand = ReactiveCommand.Create(goToPinCommand , canExecute);

        }

        private void goToPinCommand() => this.nav.CurrentViewmodel = new EnterYourPinVM(this.Username , nav);


    }
}
