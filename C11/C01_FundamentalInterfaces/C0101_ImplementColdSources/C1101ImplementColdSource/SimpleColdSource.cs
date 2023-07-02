namespace C1101ImplementColdSource;

public class SimpleColdSource : IObservable<string>
{
  public IDisposable Subscribe(IObserver<string> observer)
  {
    observer.OnNext("Hello, ");
    observer.OnNext("world!");
    observer.OnCompleted();
    return NullDisposable.Instance;
  }

  private class NullDisposable : IDisposable
  {
    public static readonly NullDisposable Instance = new();
    public void Dispose() { }
  }
}