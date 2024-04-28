using Avalonia.Controls;
using BoozeFitness.Resources;
using BoozeFitness.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class WorkoutsTwoVM : ViewModelBase
    {
       private readonly Enums.WorkoutDifficulty WorkoutDifficulty;
        private StackPanel? stackpanel;
       public StackPanel? stack_panel
        {
            get { return this.stackpanel; }
            set
            {

                ConfigureStackPanel(value!);
                this.RaiseAndSetIfChanged(ref this.stackpanel, value);
            }
        }
        public WorkoutsTwoVM(Enums.WorkoutDifficulty difficulty)
        {
            this.WorkoutDifficulty = difficulty;
            this.stack_panel = new StackPanel();
           
            
        }
        private void ConfigureStackPanel(StackPanel vstackpanel)
        {
            //ADD THE TEXTBLOCK
            var text_block = new TextBlock
            {
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top,
                Text = "CHOOSE YOUR WORKOUT"
            };
            vstackpanel.Children.Add(text_block);
            //create the viewmodels for the cards
            var biceps_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Biceps Workout");
            var triceps_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Triceps Workout");
            var chest_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Chest Workout");
            var back_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Back Workout");
            var abs_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Abs Workout");
            var legs_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Legs Workout");
            var shoulders_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Shoulders Workout");
            var forearms_card_vm = new WorkoutCardVM(this.WorkoutDifficulty, ExercisesDictionary.WorkoutDuration[this.WorkoutDifficulty], "Forearms Workout");

            //create the card views and add vm's as data context
            ICollection<WorkoutCard> card_collection = new List<WorkoutCard> {
                new WorkoutCard(biceps_card_vm),

                new WorkoutCard(triceps_card_vm),

                new WorkoutCard(chest_card_vm),

                new WorkoutCard(back_card_vm),

                new WorkoutCard(abs_card_vm),

                new WorkoutCard(legs_card_vm),

                new WorkoutCard(shoulders_card_vm),

                new WorkoutCard(forearms_card_vm)
            };

            vstackpanel.Children.AddRange(card_collection);
        }
        
    }
}
