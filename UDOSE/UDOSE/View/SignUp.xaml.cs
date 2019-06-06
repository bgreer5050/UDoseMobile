using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static UDOSE.Model.List;

namespace UDOSE.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
        private HttpClient _Client = new HttpClient();
        public SignUp objUser { get; set; }
        public SignUp ()
		{
			InitializeComponent ();
		}

        public void ClearMessage()
        {
            lblSignUp.Text = "";
            ValidateMessageShow.Text = "";
        }

        private void ShowErrorMessage(Color name, string message)
        {
            lblSignUp.TextColor = name;
            lblSignUp.Text = message;
        }
        public void EmptyFields()
        {
            FirstName.Text = "";
            LastName.Text = "";
            MobileNumber.Text = "";
            EmailId.Text = "";
            Password.Text = "";
            CompanyName.Text = "";
            txtOfficeNumber.Text = "";
            MobileNumber.Text = "";
            CompanyAddress.Text = "";



        }
        private void EmailValidation()
        {
            ClearMessage();
            string email = EmailId.Text;
            var emailpattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            bool IsValid = false;
            if (Regex.IsMatch(email, emailpattern))
            {
                lblEmailid.Text = "";
                btnSubmit.IsEnabled = true;
            }
            else
            {
                EmailId.TextColor = IsValid ? Color.Default : Color.Black;
                lblEmailid.TextColor = Color.Red;
                btnSubmit.IsEnabled = false;
                lblEmailid.Text = "";
            }

        }

        private bool Validation()
        {
            bool val = true;
            EmailValidation();
            if (lblEmailid.Text == "")
            {
                val = true;
            }
            else
            {
                val = false;               
            }
            return val;
        }



        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            
            SignUpModel objUser = new SignUpModel();
            objUser.FirstName = FirstName.Text;
            objUser.LastName = LastName.Text;
            objUser.Email = EmailId.Text;
            objUser.Password = Password.Text;
            objUser.CompanyName = CompanyName.Text;
            objUser.OfficeNumber = txtOfficeNumber.Text;
            objUser.MobileNumber = MobileNumber.Text;
            objUser.CompanyAddress = CompanyAddress.Text;
            objUser.RegistrationDate = DateTime.Now.ToString();
           
            this.IsBusy = true;
            this.Content.IsEnabled = false;
            if (!string.IsNullOrEmpty(objUser.FirstName) && !string.IsNullOrEmpty(objUser.LastName) && !string.IsNullOrEmpty(objUser.Email)
                && !string.IsNullOrEmpty(objUser.Password) && !string.IsNullOrEmpty(objUser.CompanyName) && !string.IsNullOrEmpty(objUser.OfficeNumber) &&
                !string.IsNullOrEmpty(objUser.MobileNumber) && !string.IsNullOrEmpty(objUser.CompanyAddress) && Validation()== true
                )
            {
                var content = JsonConvert.SerializeObject(objUser);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                try
                {
                    var data = await _Client.PostAsync(UrlConnection.Url + "Registration", byteContent);
                    var posturl = data;
                    var result = await data.Content.ReadAsStringAsync();
                    switch (result)
                    {
                        case APIMessage.Saved:
                            ShowErrorMessage(Color.Green, APIMessage.Saved);
                            EmptyFields();
                            break;
                        case APIMessage.EmailExist:
                            ShowErrorMessage(Color.Red, APIMessage.EmailExist);
                            break;
                        default:
                            ShowErrorMessage(Color.Red, APIMessage.APIInvalid);
                            lblSignUp.TextColor = Color.Red;
                            lblSignUp.Text = APIMessage.APIInvalid;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    ValidateMessageShow.Text = APIMessage.APIInvalid;
                   
                }
            }
            else
            {
                ValidateMessageShow.Text = "All Fields are required";
            }
            this.IsBusy = false;
            this.Content.IsEnabled = true;
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LogIn());
        }

        private async void btnForgot_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPassword());
        }
    }
}