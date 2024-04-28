using Avalonia.Controls;
using BoozeFitness.Resources;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class ExercisesVM : ViewModelBase
    {

        public ReactiveCommand<Button , Unit> MuscleGroupSelectedCommand { get; set; }
        private readonly MainAppVM mainAppVM;
       
        public ExercisesVM(MainAppVM mainVM)
        {
            this.mainAppVM = mainVM;
            this.MuscleGroupSelectedCommand = ReactiveCommand.Create<Button>(muscleGroupSelected);
        }
        private void muscleGroupSelected(Button pressed)
        {
            /*
                Detect which muscle group was selected
                based on this, assign the corresponding exercises

             */
            Enums.MuscleGroup muscle_group;
            
            switch (pressed.Content!.ToString())
            {
                case "Biceps":
                    muscle_group = Enums.MuscleGroup.Biceps; break;
                case "Triceps":
                    muscle_group = Enums.MuscleGroup.Triceps; break;
                case "Back":
                    muscle_group = Enums.MuscleGroup.Back; break;
                case "Legs":
                    muscle_group = Enums.MuscleGroup.Legs; break;
                case "Forearms":
                    muscle_group = Enums.MuscleGroup.Forearms; break;
                case "Shoulders":
                    muscle_group = Enums.MuscleGroup.Shoulders;break;
                case "Abs":
                    muscle_group = Enums.MuscleGroup.Abs;break;
                case "Chest":
                    muscle_group = Enums.MuscleGroup.Chest;break;
                default:throw new Exception();

            }
           
            this.mainAppVM.CurrentTabView = new ExercisesListVM(mainAppVM, muscle_group);
        }
    }
}
