using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using SKKernelDemo.Configuration;

namespace SKKernelDemo.Kernels;

#pragma warning disable S125

internal sealed class AzureKernelWrapper
{
    public Kernel Kernel { get; }

    public AzureKernelWrapper(SemanticKernelConfig config, ILogger<AzureKernelWrapper> logger)
    {
        var builder = Kernel.CreateBuilder()
            .AddAzureOpenAIChatCompletion(config.AzureModel, config.AzureEndpoint, config.AzureKey);

        Kernel = builder.Build();
    }
}