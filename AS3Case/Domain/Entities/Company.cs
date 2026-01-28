using AS3Case.Domain.ValueObjects;

namespace AS3Case.Domain.Entities
{
    public class Company
    {
        public CompanyName Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public Company(CompanyName name, string address, string city, string zipCode, PhoneNumber phoneNumber)
        {
            Name = name;
            Address = address;
            City = city;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
        }
    }
}