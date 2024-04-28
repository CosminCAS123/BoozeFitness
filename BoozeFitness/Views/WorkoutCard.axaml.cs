using Avalonia.Controls;
using BoozeFitness.ViewModels;

namespace BoozeFitness.Views
{
    public partial class WorkoutCard : UserControl
    {
        public WorkoutCard(WorkoutCardVM vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
