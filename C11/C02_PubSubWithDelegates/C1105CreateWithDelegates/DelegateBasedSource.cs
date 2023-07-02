using System.Reactive.Linq;

namespace C1105CreateWithDelegates;

public static class DelegateBasedSource
{
  public static IObservable<string> GetFilePusher(string path)
  {
    return Observable.Create<string>(observer =>
    {
      using (var sr = new StreamReader(path))
      {
        while (!sr.EndOfStream)
        {
          observer.OnNext(sr.ReadLine() ?? string.Empty);
        }
      }
      observer.OnCompleted();
      return () => { };
    });
  }
}