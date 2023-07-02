namespace C1102ImplementColdSource_FilePusher;

public class FilePusher : IObservable<string>
{
  private readonly string _path;
  public FilePusher(string path)
  {
    _path = path;
  }

  public IDisposable Subscribe(IObserver<string> observer)
  {
    using (var sr = new StreamReader(_path))
    {
      while (!sr.EndOfStream)
      {
        observer.OnNext(sr.ReadLine() ?? string.Empty);
      }
    }
    observer.OnCompleted();
    return NullDisposable.Instance;
  }

  private class NullDisposable : IDisposable
  {
    public static readonly NullDisposable Instance = new();
    public void Dispose() { }
  }
}