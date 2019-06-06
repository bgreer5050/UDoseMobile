using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using UDOSE.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static UDOSE.Model.List;

namespace UDOSE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        private HttpClient _Client = new HttpClient();
        public LogIn()
        {
            InitializeComponent();
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Password.Text;
            ExistErrorlabel.Text = "";
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                try
                {
                   
                    string posturl = UrlConnection.Url + "Login/" + email + "/" + password;
                    var content = await _Client.GetStringAsync(posturl);
                    var objValue = (JObject)JsonConvert.DeserializeObject(content);
                    if (content != "null")
                    { 

                        await Navigation.PushAsync(new MenuPage());
                    }
                    else
                    {
                        ExistErrorlabel.Text = "Wrong Email and Password";
                    }
                }
                catch (Exception ex)
                {
                   
                    ExistErrorlabel.Text = "Something went wrong";
                }
            }
            else
            {
                ExistErrorlabel.Text = "Please Enter email and password";
            }
        }



        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }


        private void MainSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private async void btnForgotPassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExistErrorlabel.Text = "";
            bool IsValid = false;
            string email = Email.Text;
            var emailpattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (email.Length > 7)
            {
                if (Regex.IsMatch(email, emailpattern))
                {
                    IsVisible = true;
                    ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Black;
                    EmailIdErrorLabel.Text = "";
                    btnLogIn.IsEnabled = true;
                }
                else
                {
                    ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
                    EmailIdErrorLabel.Text = Format.EmailFormat;
                    btnLogIn.IsEnabled = false;
                    IsVisible = true;
                }
            }
            else
            {
                ((Entry)sender).TextColor = Color.Black;
                EmailIdErrorLabel.Text = "";
            }
        }
    }
}