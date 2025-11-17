namespace AS3Case.Domain.Entities
{
    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        public Company(string name, string address, string city, string zipCode, string phoneNumber)
        {
            Name = name;
            Address = address;
            City = city;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
        }
    }
}