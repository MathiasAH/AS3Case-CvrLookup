using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS3Case.Domain.ValueObjects
{
    public class Country
    {
        public string Value { get; }
        public Country(string value)
        {
            Value = value;
        }
        public static bool TryParse(string input, out Country cvr)
        {
            cvr = null;

            if (input is null)
            {
                return false;
            }

            cvr = new Country(input);
            return true;
        }
        public static Country Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Country cannot be empty.");

            return new Country(input);
        }
    }
}
