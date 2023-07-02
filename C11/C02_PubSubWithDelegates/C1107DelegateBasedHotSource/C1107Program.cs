using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace C1107DelegateBasedHotSource;

public class C1107Program
{
  public static void Main()
  {
    IConnectableObservable<char> keySource = SingularHotSource.Publish();
    keySource.Subscribe(new MySubscriber<char>());
    keySource.Connect();
  }

  private static readonly IObservable<char> SingularHotSource = Observable.Create(
    (Func<IObserver<char>, IDisposable>)(obs =>
    {
      while (true)
      {
        obs.OnNext(Console.ReadKey(true).KeyChar);
      }
    }));
}

public class MySubscriber<T> : IObserver<T>
{
  public void OnNext(T value) => Console.WriteLine("Received: " + value);
  public void OnCompleted() => Console.WriteLine("Completed");
  public void OnError(Exception error) => Console.WriteLine("Error: " + error);
}