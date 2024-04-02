using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class EnterYourPinVM : ViewModelBase
    {
       
        /*
         Don't let the user enter more than 6 digits
         Don't let him proceed  if he doesn't have 6 digits
        
         */
        private string pin;
        public string Pin
        {
            get => this.pin;
            set => this.RaiseAndSetIfChanged(ref this.pin, value);
        }

        public EnterYourPinVM()
        {
        
        
        }
    }
}
