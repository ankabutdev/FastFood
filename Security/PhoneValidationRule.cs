using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace FastFood.Security;

public partial class PhoneValidationRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string phoneNumber = (string)value;

        if (string.IsNullOrEmpty(phoneNumber))
            return new ValidationResult(false, "Phone number cannot be empty.");

        // Define your regex pattern for phone number validation
        Regex regex = MyRegex();

        if (!regex.IsMatch(phoneNumber))
            return new ValidationResult(false, "Please enter a valid phone number.");

        return ValidationResult.ValidResult;
    }

    [GeneratedRegex("^(\\+\\d{1,2}\\s?)?(\\(\\d{3}\\)|\\d{3})[\\s.-]?\\d{3}[\\s.-]?\\d{4}$")]
    private static partial Regex MyRegex();
}
