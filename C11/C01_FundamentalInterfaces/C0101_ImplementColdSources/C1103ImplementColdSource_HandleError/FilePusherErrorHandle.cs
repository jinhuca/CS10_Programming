namespace C1103ImplementColdSource_HandleError;

public class FilePusherErrorHandle : IObservable<string>
{
  private readonly string _path;
  public FilePusherErrorHandle(string path)
  {
    _path = path;
  }

  public IDisposable Subscribe(IObserver<string> observer)
  {
    StreamReader sr = null;
    string line = null;
    bool failed = false;

    try
    {
      while (true)
      {
        try
        {
          if (sr == null)
          {
            sr = new StreamReader(_path);
          }
          if (sr.EndOfStream)
          {
            break;
          }
          line = sr.ReadLine();
        }
        catch (IOException x)
        {
          observer.OnError(x);
          failed = true;
          break;
        }

        observer.OnNext(line);
      }
    }
    finally
    {
      if (sr != null)
      {
        sr.Dispose();
      }
    }
    if (!failed)
    {
      observer.OnCompleted();
    }
    return NullDisposable.Instance;
  }

  private class NullDisposable : IDisposable
  {
    public static NullDisposable Instance = new();
    public void Dispose() { }
  }
}