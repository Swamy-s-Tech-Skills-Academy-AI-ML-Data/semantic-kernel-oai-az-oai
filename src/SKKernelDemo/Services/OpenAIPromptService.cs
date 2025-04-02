﻿using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SKKernelDemo.Kernels;

namespace SKKernelDemo.Services
{
    internal sealed class OpenAIPromptService(OpenAIKernelWrapper kernelWrapper) : IOpenAIPromptService
    {
        private readonly Kernel _kernel = kernelWrapper.Kernel;

        private static OpenAIPromptExecutionSettings GetDefaultExecutionSettings() =>
            new()
            {
                MaxTokens = 150,
                Temperature = 0.9
            };

        public async Task<string?> GetPromptResponseAsync(string prompt)
        {
            var result = await _kernel.InvokePromptAsync(prompt, new KernelArguments(GetDefaultExecutionSettings())).ConfigureAwait(false);

            return result?.GetValue<string>();
        }
    }
}
