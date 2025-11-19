using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS3Case.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public string Value { get; }
        private PhoneNumber(string value)
        {
            Value = value;
        }
        public static bool TryParse(string input, out PhoneNumber? cvr)
        {
            cvr = null;

            if (input is null || !input.All(char.IsDigit) || input.Length != 8)
            {
                return false;
            }

            cvr = new PhoneNumber(input);
            return true;
        }
        public static PhoneNumber Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Phone Number cannot be empty.");

            if (!input.All(char.IsDigit))
                throw new ArgumentException("Phone Number must contain only digits.");

            if (input.Length != 8)
                throw new ArgumentException("Phone number must be 8 digits long.");

            return new PhoneNumber(input);
        }
    }
}
