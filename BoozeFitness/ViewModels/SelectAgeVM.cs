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
using System.Threading;
using BoozeFitness.Models;
using BoozeFitness.Data;
using BoozeFitness.Services;
using BoozeFitness.Repositories;

namespace BoozeFitness.ViewModels
{
    public class SelectAgeVM : ViewModelBase
    {
        private const string child_uri = "avares://BoozeFitness/Assets/babyimg (1).png";
        private const string teen_uri = "avares://BoozeFitness/Assets/teenagerimg.png";
        private const string adult_uri = "avares://BoozeFitness/Assets/devonlarrat.png";
        private string UsernameToPass;
        private string PinToPass;
        private string CountryToPass;
        private NavigationVM nav;
        private Bitmap age_img;
        public ReactiveCommand<ToggleButton, Unit> AgeChosenCommand { get; set; }
        public ToggleButton? SelectedButton { get; set; } = null;
        private bool canProceed = false;
        public bool CanProceed
        {
            get => this.canProceed;
            set => this.RaiseAndSetIfChanged(ref this.canProceed , value);
        }
        public Bitmap AgeImage
        {
            get => this.age_img;
            set => this.RaiseAndSetIfChanged(ref this.age_img, value);
        }
        public ReactiveCommand<Unit , Unit> CreateAccountCommand { get; set; }
        public enum AgeType
        {
            Child = 1,
            Teenager = 2,
            Adult = 3
        }
        private string AgeToPass;
        private UserRepository UserRepository;
        public SelectAgeVM(IRepository<User> userRepository , string username, string pin , string country, NavigationVM navigationVM )
        {
            this.UserRepository = (UserRepository)userRepository;
            //
            //

            this.UsernameToPass = username;
            this.PinToPass = pin; 
            this.CountryToPass = country;
            this.nav = navigationVM;
            this.AgeChosenCommand = ReactiveCommand.Create<ToggleButton>(agechosencmd);
            this.CreateAccountCommand = ReactiveCommand.Create(createacccmd);
        }
       
        private async void createacccmd()
        {
            //add in db
            var user = new User(this.CountryToPass, this.UsernameToPass, this.PinToPass, this.AgeToPass);
            var userService = new UserService(this.UserRepository);
            await userService.AddUserAsync(user);
            userService.Dispose();
            //enter app
            this.nav.CurrentViewmodel = new MainAppVM(this.nav , user);
        }

        private void agechosencmd(ToggleButton button)
        {
            
            if (SelectedButton == button)
            {
                SelectedButton.IsChecked = true;
                return;
            }
            if (SelectedButton is not null)
            {
                SelectedButton.IsChecked = false;
            
            }//uncheck last one
            SelectedButton = button;//mark pressed one as current button
            this.CanProceed = true;
            switch (button.Content!.ToString())
            {
                case "Child":
                    this.AgeImage = ImageHelper.LoadFromResource(new Uri(child_uri));
                    AgeToPass = AgeType.Child.ToString();
                    break;
                case "Teen":
                    this.AgeImage = ImageHelper.LoadFromResource(new Uri(teen_uri));
                    AgeToPass = AgeType.Teenager.ToString();
                    break;
                case "Adult":
                    this.AgeImage = ImageHelper.LoadFromResource(new Uri(adult_uri));
                    AgeToPass = AgeType.Adult.ToString();
                    break;
            }//update image based on checked button
            

        }

    }
}
