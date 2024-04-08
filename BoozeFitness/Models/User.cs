using BoozeFitness.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Models
{
    [PrimaryKey("Username")]
    public class User
    {
        public SelectCountryVM.Country Nationality { get; set; }

        public uint Age { get; set; }

       
        public string Username { get; set; }
        
        public string PIN { get; set; }

    }
}
