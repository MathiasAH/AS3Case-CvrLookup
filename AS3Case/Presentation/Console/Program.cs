using AS3Case.Application.Contracts.Interfaces;
using AS3Case.Application.UseCases.CompanyLookup;
using AS3Case.Domain.Entities;
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

    ServiceProvider provider = SetupDI.BuildServiceProvider();

    ICompanyLookupUseCase service = provider.GetRequiredService<ICompanyLookupUseCase>();

    LookupCompanyCommand command = LookupCompanyCommand.Parse(args);

    CompanyLookupRequest request = CommandMapper.ToRequest(command);

    Company result = await service.HandleRequestAsync(request);

    if (result != null)
    {
        Console.WriteLine(
            $"Name: {result.Name.Value}" + Environment.NewLine +
            $"Address: {result.Address}" + Environment.NewLine +
            $"Zip Code: {result.ZipCode}" + Environment.NewLine +
            $"Phone Number: {result.PhoneNumber.Value}" + Environment.NewLine +
            $"City: {result.City}"
            );
    }
    parseResult.Invoke();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}