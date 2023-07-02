using System.Reactive.Linq;

namespace C1110GenerateTimedItems;

public class C1110Program
{
  public static void Main()
  {
    var source = GenerateTimedItems();
    var subscriber = new MySubscriber<int>();
    source.Subscribe(subscriber);
    Console.ReadLine();
  }

  private static IObservable<int> GenerateTimedItems()
  {
    return Observable.Generate(
      (Current: 0, Total: 0, Random: new Random()),
      state => state.Total < 10000,
      state =>
      {
        int value = state.Random.Next(1000);
        return (value, state.Total + value, state.Random);
      },
      state => state.Current,
      state => TimeSpan.FromMilliseconds(state.Random.Next(1000)));
  }
}

public class MySubscriber<T> : IObserver<T>
{
  public void OnNext(T value) => Console.WriteLine("Received: " + value);
  public void OnCompleted() => Console.WriteLine("Completed");
  public void OnError(Exception error) => Console.WriteLine("Error: " + error);
}