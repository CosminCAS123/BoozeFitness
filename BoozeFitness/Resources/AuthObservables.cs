using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Resources
{
    public static class AuthObservables
    {
        public static (bool , string) PinCanExecute(string pin)
        {
            /* 
                PIN : 
                   -only digits
                   -length of 6
                   -not empty
            */
            if (string.IsNullOrEmpty(pin)) return (false, ErrorClass.PIN_IS_EMPTY_ERROR);
            if (!pin.All(char.IsDigit)) return (false, ErrorClass.PIN_CONTAINS_OTHER_CHAR);
            if (pin.Length < 6) return (false, ErrorClass.PIN_IS_NOT_SIX_DIGITS);
            return (true, ErrorClass.NO_ERROR);
          
        }
        

        public static (bool , string) NameCanExecute(string name)
        {
            /*
              NAME :
                  -not empty
                  -only english letters and digits
             */
            if (string.IsNullOrEmpty(name)) return (false, ErrorClass.NAME_IS_EMPTY_ERROR);
            if (!name.All(char.IsLetterOrDigit)) return (false , ErrorClass.NAME_CONTAINS_OTHER_CHAR);
            return (true, ErrorClass.NO_ERROR);
           
        }
        

    }
}
