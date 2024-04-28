using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class WorkoutCardVM : ViewModelBase
    {
        #region Private variables
        private string difficulty;
        private string time;
        private string group;
        #endregion

        #region Binding Properties
        public string Difficulty
        {
            get => this.difficulty;
            set => this.RaiseAndSetIfChanged(ref this.difficulty, value);
        }
        public string Time
        {
            get => this.time;
            set => this.RaiseAndSetIfChanged(ref this.time, value);
        }
        public string Group
        {
            get => this.group;
            set => this.RaiseAndSetIfChanged(ref this.group, value);
        }
        #endregion
        public WorkoutCardVM(Enums.WorkoutDifficulty difficulty , string time , string group)
        {
            this.Difficulty = difficulty.ToString();
            this.Time = time;
            this.Group = group;
        }
    }
}
