using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using BoozeFitness.Resources;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BoozeFitness.ViewModels
{
    public class SelectCountryVM : ViewModelBase
    {
        public Dictionary<Country , Bitmap> Flags { get; set; }
     

        private bool dropdownopened = false;
        public bool DropDownOpened
        {
            get => this.dropdownopened;
            set => this.RaiseAndSetIfChanged(ref dropdownopened, value);
        }

        private bool isflagvisible = false;
        public bool IsFlagVisible
        {
            get => this.isflagvisible;
            set => this.RaiseAndSetIfChanged(ref this.isflagvisible, value);
        }
         public enum Country
        {
            Romania,
            Italy,
            Spain,
            England,
            None

        }
        private List<string>? _countries;
        public List<string> Countries
        {
            get => this._countries!;
            set => this.RaiseAndSetIfChanged(ref this._countries, value);
        }
        private Bitmap current_flag;
        public Bitmap CurrentFlag
        {
            get => this.current_flag;
            set => this.RaiseAndSetIfChanged(ref this.current_flag, value);
        }
        private string autotext;
        public string AutoCompleteBoxText
        {
            get => this.autotext;
            set => this.RaiseAndSetIfChanged(ref autotext, value);
        }
        private string UsernameToPass;
        private string PinToPass;
        private string CountryToPass;
        private NavigationVM nav;
        public ReactiveCommand<Unit , Unit> GoToAgeSelectionCommand { get; set; }
        public SelectCountryVM(string username , string pin , NavigationVM navigationVM)
        {
            Countries = new List<string>() { Country.Romania.ToString() , Country.Italy.ToString() , Country.Spain.ToString() , Country.England.ToString()};
            this.UsernameToPass = username;
            this.PinToPass = pin;
            this.nav = navigationVM;
            AddFlagsToDictionary();
            this.WhenAnyValue(x => x.DropDownOpened).
                Subscribe(x => ChangeFlag());
            var canExecute = this.WhenAnyValue(x => x.AutoCompleteBoxText,
                (country) =>
                {
                   
                    if (string.Equals(country, "Romania") || string.Equals(country, "Italy") || string.Equals(country , "England") || string.Equals(country, "Spain"))
                    {
                        this.CountryToPass = country;
                        return true;
                    }
                    return false;
                });

            this.GoToAgeSelectionCommand = ReactiveCommand.Create(goToAgeSelectionCmd, canExecute);
           

        }
        private Country ToCountry(string country)
        {
            switch (country) 
            {
                case "Romania":
                    return Country.Romania;
                    
                case "Italy":
                    return Country.Italy;
                   
                case "Spain":
                    return Country.Spain;
                case "England":
                    return Country.England;
                default:
                    return Country.None;
                 
            
            }
           

        }
        private void goToAgeSelectionCmd()
        {
            this.nav.CurrentViewmodel = new SelectAgeVM(this.UsernameToPass, this.PinToPass, ToCountry(this.CountryToPass), this.nav);
        }
       private void ChangeFlag()
        {
            //you look for the flag

            if (DropDownOpened == true)
            {
                var first_letter = AutoCompleteBoxText[0];
                IsFlagVisible = true;
                if (first_letter == 'R' || first_letter == 'r') CurrentFlag = Flags[Country.Romania];
                else if (first_letter == 'I' || first_letter == 'i') CurrentFlag = Flags[Country.Italy];
                else if (first_letter == 'S' || first_letter == 's') CurrentFlag = Flags[Country.Spain];
                else if (first_letter == 'E' || first_letter == 'e') CurrentFlag = Flags[Country.England];
            }
            else IsFlagVisible = false;
        }
        private void AddFlagsToDictionary()
        {
            string uri_default = "avares://BoozeFitness/Assets/";

            Flags = new Dictionary<Country, Bitmap>();

            Flags[Country.Romania] = ImageHelper.LoadFromResource(new Uri(uri_default + "RomaniaIcon.png"));
            Flags[Country.Italy] = ImageHelper.LoadFromResource(new Uri(uri_default + "ItalyIcon.png"));
            Flags[Country.Spain] = ImageHelper.LoadFromResource(new Uri(uri_default + "SpainIcon.png"));
            Flags[Country.England] = ImageHelper.LoadFromResource(new Uri(uri_default + "EnglandIcon.png"));
            


        }
    }
}
