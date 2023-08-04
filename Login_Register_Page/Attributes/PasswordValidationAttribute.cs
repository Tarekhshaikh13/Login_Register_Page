using System.ComponentModel.DataAnnotations;

namespace Login_Register_Page.Attributes
{
    public class PasswordValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string pass = value.ToString();

            return 
                   pass.Any(char.IsLetter) &&
                   pass.Any(char.IsDigit) &&
                   pass.Any(c => !char.IsLetterOrDigit(c));
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} Should include Alphanumeric and Specialcharacters .";
        }
    }
}
