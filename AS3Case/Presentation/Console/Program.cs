using AS3Case.Application.CompanyLookup.Contracts.Dto.Views;
using AS3Case.Application.CompanyLookup.UseCases;
using AS3Case.Presentation.Console.Commands;
using AS3Case.Presentation.Console.Configuration;
using AS3Case.Presentation.Console.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using System.CommandLine.Parsing;

try
{
    RootCommand rootCommand = new("Company info retriever");
    foreach (Option option in CommandLineOptions.Options())
    {
        rootCommand.Options.Add(option);
    }
    ParseResult parseResult = rootCommand.Parse(args);

    if (parseResult.Errors.Count > 0)
    {
        foreach (ParseError error in parseResult.Errors)
        {
            Console.WriteLine(error.ToString());
        }
    }
    // First we build the request from the input from the UI
    LookupCompanyCommand command = LookupCompanyCommand.Parse(args);
    CompanyLookupRequest request = CommandMapper.ToRequest(command);
    
    // Then we pass the request to the correct use case via DI
    ServiceProvider provider = SetupDI.BuildServiceProvider();
    ICompanyLookup useCase = provider.GetRequiredService<ICompanyLookup>();

    // The use case handles the request and returns a result which can be displayed in the UI
    CompanyView result = await useCase.HandleRequestAsync(request);

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
    parseResult.Invoke();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}