using AS3Case.Application.CompanyLookup.Enums;

namespace AS3Case.Application.CompanyLookup.UseCases
{
    public class CompanyLookupRequest
    {
        public LookupType Type { get; }
        public string Value { get; }
        public string Country { get; }

        public CompanyLookupRequest(LookupType type, string value, string country)
        {
            Type = type;
            Value = value;
            Country = country;
        }
    }
}