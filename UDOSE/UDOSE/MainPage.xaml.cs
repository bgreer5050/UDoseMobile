using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDOSE.View;
using Xamarin.Forms;

namespace UDOSE
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());
        }

        private async void btnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        private void btnRX_Clicked(object sender, EventArgs e)
        {

        }

        private void btnControls_Clicked(object sender, EventArgs e)
        {

        }

        private void btnHazourdous_Clicked(object sender, EventArgs e)
        {

        }
    }
}
