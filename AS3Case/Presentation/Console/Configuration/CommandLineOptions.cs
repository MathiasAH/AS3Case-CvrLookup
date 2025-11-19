using System.CommandLine;

namespace AS3Case.Presentation.Console.Configuration
{
    public class CommandLineOptions
    {
        public static List<Option> Options()
        {
            List<Option> options = [];
            Option<string> registrationNumber = new("--rn")
            {
                Description = "Registration number number of the company to retrieve (CVR/VAT)."
            };
            options.Add(registrationNumber);

            Option<string> name = new("--name")
            {
                Description = "Name of the company to retrieve."
            };
            options.Add(name);

            Option<string> phoneNumber = new("--phone")
            {
                Description = "Phone number of the company to retrieve."
            };
            options.Add(phoneNumber);

            Option<string> country = new("--country")
            {
                Description = "Country from which the company is in. (DK or NO)"
            };
            options.Add(country);

            return options;
        }
    }
}