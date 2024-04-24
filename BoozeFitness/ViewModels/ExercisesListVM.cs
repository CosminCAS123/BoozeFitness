using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class ExercisesListVM : ViewModelBase
    {
        private readonly MainAppVM mainAppVM;

        private IEnumerable<string> exercise_items;
        private string exercise_info;
        public IEnumerable<string> ExerciseItems
        {
            get => this.exercise_items;
            set => this.RaiseAndSetIfChanged(ref this.exercise_items, value);
        }

        public string MuscleGroup { get; private set; }
        private object selected_exercise;
        public object SelectedExercise
        {
            //selected item is changed
            get
            {
                return this.selected_exercise;
            }

            set
            {
                this.selected_exercise = value;
                ExerciseInfo = ExercisesDictionary.GetExerciseInfo[value.ToString()!];
                
            }
        }
        public string ExerciseInfo 
        {
            get => this.exercise_info;
            set => this.RaiseAndSetIfChanged(ref this.exercise_info, value);
        }
        public ExercisesListVM(MainAppVM mainAppVM, ExercisesDictionary.MuscleGroup muscle)
        {
            this.mainAppVM = mainAppVM;
            this.MuscleGroup = muscle.ToString();
            ExerciseInfo = "Select an exercise to get more details on it!";
            ConfigureList(muscle);
            
        }

        private void ConfigureList(ExercisesDictionary.MuscleGroup group) => this.ExerciseItems = ExercisesDictionary.GetAllExercises(group);
        
    }
}

      
    

