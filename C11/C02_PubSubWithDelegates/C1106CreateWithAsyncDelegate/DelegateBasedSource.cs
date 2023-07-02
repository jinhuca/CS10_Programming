using System.Reactive.Linq;

namespace C1106CreateWithAsyncDelegate;

public static class DelegateBasedSource
{
  public static IObservable<string> GetFilePusher(string path)
  {
    return Observable.Create<string>(async (observer, cancel) =>
    {
      using (var sr = new StreamReader(path))
      {
        while (!sr.EndOfStream && !cancel.IsCancellationRequested)
        {
          observer.OnNext(await sr.ReadLineAsync() ?? string.Empty);
        }
      }
      observer.OnCompleted();
      return () => { };
    });
  }
}