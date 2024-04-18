using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Resources
{
    public static class IdGenerator
    {
        private static uint id = 0;
        public static uint GenerateId()
        {
            id++;
            return id;
        }

    }
}
