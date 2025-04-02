namespace SKKernelDemo.Services;

internal interface IAzurePromptService
{
    Task<string?> GetPromptResponseAsync(string prompt);
}
