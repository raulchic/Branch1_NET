namespace FileProcessor.Repository;
public interface IProcessedFileRepository { bool Exists(string fileName); void Add(string fileName); }
public class ProcessedFileRepository : IProcessedFileRepository
{
    private readonly HashSet<string> _processed = new();
    public bool Exists(string fileName) => _processed.Contains(fileName);
    public void Add(string fileName) => _processed.Add(fileName);
}