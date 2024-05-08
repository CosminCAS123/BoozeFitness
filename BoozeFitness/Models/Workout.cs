using BoozeFitness.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoozeFitness.Resources;

namespace BoozeFitness.Models
{
    [PrimaryKey("ID")]
    public class Workout
    {
        public int ID { get; set; }
        public Enums.MuscleGroup GroupTargeted { get; set; }
        public Enums.WorkoutDifficulty Difficulty { get; set; }

        public string? Duration { get; set; }


    }
}
