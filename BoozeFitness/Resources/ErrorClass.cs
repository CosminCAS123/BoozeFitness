using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Resources
{
    public static class ErrorClass
    {

        public const string NAME_IS_EMPTY_ERROR = "The name field cannot be empty";
        public const string NAME_CONTAINS_OTHER_CHAR = "The name field can only have letters and digits";
        public const string PIN_IS_EMPTY_ERROR = "The PIN field cannot be empty";
        public const string PIN_CONTAINS_OTHER_CHAR = "The PIN field can only have digits";
        public const string NO_ERROR = "";
        public const string PIN_IS_NOT_SIX_DIGITS = "The PIN field must have a length of 6";
        public const string ACCOUNT_DOESNT_EXIST = "The account you provided doesn't exist";
        public const string CREDENTIALS_DONT_CORRESPOND = "The PIN is not correct for this username";

    }
}
