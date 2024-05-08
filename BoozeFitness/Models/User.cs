using BoozeFitness.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.Models
{
    [PrimaryKey("ID")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nationality { get; set; }

        public string Age { get; set; }

        public ICollection<Workout> Workouts { get; set; }
        public string Username { get; set; }
        
        public string PIN { get; set; }
        public User() { }
        public User( string nationality, string username, string pin, string age)
        {
            
            this.Nationality = nationality ;
            this.PIN = pin;
            this.Username = username;
            this.Age = age;
        }
    }
}
