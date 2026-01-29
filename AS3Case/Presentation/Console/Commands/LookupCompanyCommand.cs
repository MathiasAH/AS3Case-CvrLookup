using AS3Case.Application.Enums;
using AS3Case.Application.UseCases.CompanyLookup;
using System.ComponentModel.DataAnnotations;

namespace AS3Case.Presentation.Console.Commands
{
    public class LookupCompanyCommand
    {
        public string Cvr { get; }
        public string Phone { get; }
        public string Name { get; }
        public string Country { get; }

        public LookupCompanyCommand(
            string cvr,
            string phone,
            string name,
            string country)
        {
            Cvr = cvr;
            Phone = phone;
            Name = name;
            Country = country;
        }
        public static LookupCompanyCommand Parse(string[] args)
        {
            string rn = null;
            string phone = null;
            string name = null;
            string country = "DK"; // default

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--rn":
                        rn = args[++i];
                        if (string.IsNullOrEmpty(rn))
                            throw new ArgumentException("--rn must contain a value");
                        break;

                    case "--phone":
                        phone = args[++i];
                        if (string.IsNullOrEmpty(phone))
                            throw new ArgumentException("--phone must contain a value");
                        break;

                    case "--name":
                        name = args[++i];
                        if (string.IsNullOrEmpty(name))
                            throw new ArgumentException("--name must contain a value");
                        break;

                    case "--country":
                        country = args[++i];
                        if (string.IsNullOrEmpty(country))
                            throw new ArgumentException("--country must contain a value");
                        break;

                    default:
                        throw new ArgumentException($"Unknown argument: {args[i]}");
                }
            }

            if (rn == null && phone == null && name == null)
            {
                throw new ArgumentException("You must supply either --rn, --phone or --name");
            }
            else if(rn != null && (phone != null || name != null))
            {
                throw new ArgumentException("You can only use one of either --rn, --phone or --name");
            }
            else if (phone != null && (rn != null || name != null))
            {
                throw new ArgumentException("You can only use one of either --rn, --phone or --name");
            }
            else if (name != null && (rn != null || phone != null))
            {
                throw new ArgumentException("You can only use one of either --rn, --phone or --name");
            }

            return new LookupCompanyCommand(
                    rn,
                    phone,
                    name,
                    country
                );
        }
    }
}