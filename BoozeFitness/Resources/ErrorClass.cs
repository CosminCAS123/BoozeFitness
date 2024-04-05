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

    }
}
