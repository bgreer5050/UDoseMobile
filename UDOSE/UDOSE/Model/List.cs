using System;
using System.Collections.Generic;
using System.Text;

namespace UDOSE.Model
{
   public class List
    {

        public class UrlConnection
        {
              public const string Url = "http://13.68.181.84/api/MobApp/";
             // public const string Url = " http://f0ad2277.ngrok.io/api/MobApp/";
             // public const string Url = "http://f75f4b41.ngrok.io/api/MobApp/";
        }
        public class SignUpModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string CompanyName { get; set; }
            public string OfficeNumber { get; set; }
            public string MobileNumber { get; set; }
            public string CompanyAddress { get; set; }
            public string RegistrationDate { get; set; }
           
        }

        public class APIMessage
        {
            public const string Saved = "\"SuccessFully Saved.\"";
            public const string EmailExist = "Already exist.";
            public const string APIInvalid = "Something Went wrong.";
            public const string RecordUnsaved = "Record not saved. Please try again";
            
        }
        public class Format
        {
            public const string EmailFormat = "EmailId should be contain '@' eg:abc @gmail.com";
            public const string Mobile = "Mobile number should be contain 10 digits";
            public const string Password = "Password should be contain atleast 8 characters.[eg: No1My#App]";
            public const string ConfirmPassword = "Entered Password Should be same";
        }


    }
}
