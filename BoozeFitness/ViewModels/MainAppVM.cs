using Avalonia.Controls;
using BoozeFitness.Models;
using Microsoft.CodeAnalysis;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
     /*
      handles navigation between the 4 contents of the app(workouts, exercises, progress, profile
      */
     public class MainAppVM : ViewModelBase
    {
        private readonly NavigationVM nav;
        private readonly User user;
        private int selectedTabIndex = 0;
        public int SelectedTabIndex
        {
            get
            {
                return this.selectedTabIndex;
            }
            set
            {
                this.selectedTabIndex = value;
                switch (value)
                {
                    case 0:
                        this.CurrentTabView = new WorkoutsVM(this);
                        break;
                    case 1:
                        this.CurrentTabView = new ExercisesVM(this);
                        break;
                    case 2:
                        this.CurrentTabView = new ProgressVM(this);
                        break;
                    case 3:
                        this.CurrentTabView = new ProfileVM(this);
                      
                        break;
                }

            }
        }

        public ViewModelBase CurrentTabView
        {
            get => this.current_tab_view;
            set => this.RaiseAndSetIfChanged(ref this.current_tab_view, value);
        }
     
        private ViewModelBase current_tab_view;
        public MainAppVM(NavigationVM navigationVM , User user)
        {
            
            this.CurrentTabView = new WorkoutsVM(this);
            this.nav = navigationVM;
            this.user = user;
        }
    }
}
