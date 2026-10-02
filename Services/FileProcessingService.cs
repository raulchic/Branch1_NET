using FileProcessor.Repository;
namespace FileProcessor.Services;
public class FileProcessingService
{
    private readonly IProcessedFileRepository _repository;
    public FileProcessingService(IProcessedFileRepository repository) => _repository = repository;
    public async Task ProcessFileAsync(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        if (_repository.Exists(fileName)) { Console.WriteLine($"Archivo ya procesado: {fileName}"); return; }
        using StreamReader reader = new(filePath);
        while (!reader.EndOfStream) { 
            var line = await reader.ReadLineAsync(); 
            if (!string.IsNullOrWhiteSpace(line))
            {
                          

                var campos = line.Split(',');

            for (int i = 0; i < campos.Length; i += 5)
            {
                Console.WriteLine(
                    string.Join(",", campos.Skip(i).Take(5))+","
                );
            }

            Console.WriteLine("------------");


            //Console.WriteLine(line);
            }
        }
        _repository.Add(fileName);
        Console.WriteLine($"Archivo completado: {fileName}");
    }
}
