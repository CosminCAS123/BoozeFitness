using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media.Imaging;
using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data;

namespace BoozeFitness.ViewModels
{
    public class SelectAgeVM : ViewModelBase
    {
        private const string child_uri = "avares://BoozeFitness/Assets/babyimg (1).png";
        private const string teen_uri = "avares://BoozeFitness/Assets/teenagerimg.png";
        private const string adult_uri = "avares://BoozeFitness/Assets/devonlarrat.png";
        private string UsernameToPass;
        private string PinToPass;
        private SelectCountryVM.Country CountryToPass;
        private NavigationVM nav;
        private Bitmap age_img;
        public ReactiveCommand<ToggleButton, Unit> AgeChosenCommand { get; set; }
        public ToggleButton? SelectedButton { get; set; } = null;
        public Bitmap AgeImage
        {
            get => this.age_img;
            set => this.RaiseAndSetIfChanged(ref this.age_img, value);
        }
        public SelectAgeVM(string username, string pin , SelectCountryVM.Country country, NavigationVM navigationVM)
        {
            this.UsernameToPass = username;
            this.PinToPass = pin; 
            this.CountryToPass = country;
            this.nav = navigationVM;
            this.AgeChosenCommand = ReactiveCommand.Create<ToggleButton>(agechosencmd);
        }
        private void agechosencmd(ToggleButton button)
        {
            
            if (SelectedButton is not null) SelectedButton.IsChecked = false;//uncheck last one
            SelectedButton = button;//mark pressed one as current button
            switch (button.Content!.ToString())
            {
                case "Child":
                    this.AgeImage = ImageHelper.LoadFromResource(new Uri(child_uri));
                    break;
                case "Teen":
                    this.AgeImage = ImageHelper.LoadFromResource(new Uri(teen_uri));
                    break;
                case "Adult":
                    this.AgeImage = ImageHelper.LoadFromResource(new Uri(adult_uri));
                    break;
            }//update image based on checked button
            

        }

    }
}
