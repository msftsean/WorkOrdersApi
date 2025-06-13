using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System;
using System.Threading.Tasks;

public class SemanticKernelSample
{
    public async Task RunAsync()
    {
        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion(
            modelId: "gpt-3.5-turbo",
            apiKey: "da73c4ee58464524a64c5c9fa18bc3a5"
        );
        var kernel = builder.Build();
        var result = await kernel.InvokePromptAsync("Write a short poem about the sea.");
        Console.WriteLine(result.GetValue<string>());
    }
}
