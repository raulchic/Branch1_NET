using FileProcessor.Repository;
using FileProcessor.Services;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IProcessedFileRepository, ProcessedFileRepository>();
builder.Services.AddScoped<FileProcessingService>();
builder.Services.AddHostedService<FileProcessorWorker>();
var host = builder.Build();
await host.RunAsync();