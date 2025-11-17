using AS3Case.Application.Enums;
using AS3Case.Application.Interfaces;
using AS3Case.Domain.Interfaces;
using AS3Case.Domain.ValueObjects;
using AS3Case.Presentation.Console.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using System.CommandLine.Parsing;

ServiceProvider provider = SetupDI.BuildServiceProvider();

RootCommand rootCommand = new("Company info retriever");
foreach (Option option in CommandLineOptions.Options())
{
    rootCommand.Options.Add(option);
}
ParseResult parseResult = rootCommand.Parse(args);

if (parseResult.Errors.Count > 0)
{
    foreach (var error in parseResult.Errors)
    {
        Console.WriteLine(error.ToString());
    }
}

IEnumerable<OptionResult> suppliedOptions = parseResult.CommandResult
    .Children
    .OfType<OptionResult>()
    .Where(or => or.Tokens.Any());

string languageValue = suppliedOptions
    .FirstOrDefault(o => o.Option.Name == "--country")?
    .Tokens
    .FirstOrDefault()?
    .Value
    ?? "dk"; // default

Country country = languageValue.ToLower() switch
{
    "dk" or "denmark" => Country.Denmark,
    "se" or "sweden" => Country.Sweden,
    "no" or "norway" => Country.Norway,
    _ => Country.Denmark
};

ICompanyLookupServiceFactory factory = provider.GetRequiredService<ICompanyLookupServiceFactory>();
ICompanyLookupService service = factory.GetService(Country.Denmark);
AS3Case.Domain.Entities.Company? result = null;
try
{
    foreach (var optResult in suppliedOptions)
    {
        string optionName = optResult.Option.Name;

        string value = string.Join(" ", optResult.Tokens.Select(t => t.Value));

        switch (optionName)
        {
            case "--rn":
                if (CvrNumber.TryParse(value, out var cvrNumber))
                {
                    result = await service.LookupByRegistrationNumberAsync(value);
                    break;
                }
                Console.WriteLine("Please enter a valid CVR number");
                break;
            case "--phone":
                if (!string.IsNullOrEmpty(value))
                {
                    result = await service.LookupByPhoneNumberAsync(value);
                    break;
                }
                Console.WriteLine("Please enter a valid phone number.");
                break;
            case "--name":
                if (!string.IsNullOrEmpty(value))
                {
                    result = await service.LookupByNameAsync(value);
                    break;
                }
                Console.WriteLine("Please enter a valid name.");
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}

if (result != null)
{
    Console.WriteLine(
        $"Name: {result.Name}" + Environment.NewLine +
        $"Address: {result.Address}" + Environment.NewLine +
        $"Zip Code: {result.ZipCode}" + Environment.NewLine +
        $"Phone Number: {result.PhoneNumber}" + Environment.NewLine +
        $"City: {result.City}"
        );
}
Console.ReadLine();