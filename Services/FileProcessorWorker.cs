namespace FileProcessor.Services;
public class FileProcessorWorker : BackgroundService
{
    private readonly IServiceProvider _sp;
    public FileProcessorWorker(IServiceProvider sp) => _sp = sp;
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var directory = Path.Combine(AppContext.BaseDirectory, "Input");
        Directory.CreateDirectory(directory);
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _sp.CreateScope();
            var processor = scope.ServiceProvider.GetRequiredService<FileProcessingService>();
            foreach (var file in Directory.GetFiles(directory, "*.txt")) await processor.ProcessFileAsync(file);
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}
