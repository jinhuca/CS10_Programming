namespace C1105CreateWithDelegates;

public class MySubscriber<T> : IObserver<T>
{
  public void OnCompleted()
  {
    Console.WriteLine("Completed.");
  }

  public void OnError(Exception error)
  {
    Console.WriteLine("Error: " + error);
  }

  public void OnNext(T value)
  {
    Console.WriteLine("Received: " + value);
  }
}