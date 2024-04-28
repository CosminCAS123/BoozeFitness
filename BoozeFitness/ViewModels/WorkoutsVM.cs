using Avalonia.Controls;
using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class WorkoutsVM : ViewModelBase
    {
        private readonly MainAppVM mainAppVM;
        public ReactiveCommand<Button, Unit> DifficultyCommand { get; set; }
        public WorkoutsVM(MainAppVM mainVM)
        {
            this.mainAppVM = mainVM;
            this.DifficultyCommand = ReactiveCommand.Create<Button>(difficulty_command);
        }

        private void difficulty_command(Button sender)
        {
            Enums.WorkoutDifficulty difficulty_tosend;
            switch (sender.Content!.ToString())
            {
                case "Beginner":
                    difficulty_tosend = Enums.WorkoutDifficulty.Beginner;
                    break;
                case "Intermediate":
                    difficulty_tosend = Enums.WorkoutDifficulty.Intermediate;
                    break;
                case "Advanced":
                    difficulty_tosend = Enums.WorkoutDifficulty.Advanced;
                    break;
                default:
                    throw new ArgumentException();
            }
            this.mainAppVM.CurrentTabView = new WorkoutsTwoVM(difficulty_tosend);
        }

    }
}
