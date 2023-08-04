using System.ComponentModel.DataAnnotations;

namespace Login_Register_Page.Attributes
{
    public class PasswordLengthAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string pass = value.ToString();

            return pass.Length >= 6;
                 
        }
        public override string FormatErrorMessage(string name)
        {
            return $"{name} minimum length 6.";
        }
    }
}
