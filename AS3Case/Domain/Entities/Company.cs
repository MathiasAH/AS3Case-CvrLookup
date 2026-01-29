using AS3Case.Domain.ValueObjects;

namespace AS3Case.Domain.Entities
{
    public class Company
    {
        public CompanyName Name { get; private set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public Company(string name, string address, string city, string zipCode, string phoneNumber)
        {
            Name = CompanyName.Create(name);
            Address = address;
            City = city;
            ZipCode = zipCode;
            PhoneNumber = PhoneNumber.Create(phoneNumber);
        }
    }
}