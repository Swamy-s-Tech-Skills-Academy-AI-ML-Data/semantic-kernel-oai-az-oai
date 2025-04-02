using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SKKernelDemo.Infrastructure;
using SKKernelDemo.Services;

#pragma warning disable SKEXP0010
#pragma warning disable SKEXP0001
#pragma warning disable S125
#pragma warning disable CA1303

// Set console output encoding to UTF-8
Console.OutputEncoding = Encoding.UTF8;

var host = HostBuilderFactory.BuildHost(args);

var openAiService = host.Services.GetRequiredService<IOpenAIPromptService>();
var azureService = host.Services.GetRequiredService<IAzurePromptService>();

// Ask user for input
Write("Enter your prompt: ");
string? prompt = ReadLine();

if (string.IsNullOrWhiteSpace(prompt))
{
    WriteLine("Prompt cannot be empty. Exiting...");
    return;
}

WriteLine($"\nPrompt: {prompt}");

WriteLine("\n******************** OpenAI Response ********************");
ForegroundColor = ConsoleColor.DarkCyan;
string? openAiResponse = await openAiService.GetPromptResponseAsync(prompt).ConfigureAwait(false);
WriteLine(openAiResponse);
ResetColor();
WriteLine("\n-------------------- OpenAI Response --------------------");


WriteLine("\n******************** Azure OpenAI Response ********************");
ForegroundColor = ConsoleColor.DarkYellow;
string? azureResponse = await azureService.GetPromptResponseAsync(prompt).ConfigureAwait(false);
WriteLine(azureResponse);
ResetColor();
WriteLine("\n-------------------- Azure OpenAI Response --------------------");

ResetColor();
WriteLine("\n\nPress any key to exit...");
ReadKey();
