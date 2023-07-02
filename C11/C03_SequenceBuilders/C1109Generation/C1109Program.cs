using System.Reactive.Linq;

namespace C1109Generation
{
  public class C1109Program
  {
    public static void Main()
    {
      var source = GenerateItems();
      var subscriber = new MySubscriber<int>();
      source.Subscribe(subscriber);
      Console.ReadLine();
    }

    private static IObservable<int> GenerateItems()
    {
      return Observable.Generate(
        (Current: 0, Total: 0, Random: new Random()),
        state => state.Total <= 10000,
        state =>
        {
          int value = state.Random.Next(1000);
          return (value, state.Total + value, state.Random);
        },
        state => state.Current);
    }

    private static IObservable<int> GenerateEmptySequence() => Observable.Empty<int>();
    private static IObservable<int> GenerateNeverSequence() => Observable.Never<int>();
  }

  public class MySubscriber<T> : IObserver<T>
  {
    public void OnNext(T value) => Console.WriteLine("Received: " + value);
    public void OnCompleted() => Console.WriteLine("Completed");
    public void OnError(Exception error) => Console.WriteLine("Error: " + error);
  }
}