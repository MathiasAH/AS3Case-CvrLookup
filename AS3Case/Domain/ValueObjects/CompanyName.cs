using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS3Case.Domain.ValueObjects
{
    public class CompanyName
    {
        public string Value { get; }
        public CompanyName(string value)
        {
            Value = value;
        }
        public static bool TryParse(string input, out CompanyName? cvr)
        {
            cvr = null;

            if (input is null)
            {
                return false;
            }

            cvr = new CompanyName(input);
            return true;
        }
        public static CompanyName Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Company Name cannot be empty.");

            return new CompanyName(input);
        }
    }
}
