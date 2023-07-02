﻿namespace C1102ImplementColdSource_FilePusher;

public class MySubscriber<T> : IObserver<T>
{
  public void OnNext(T value) => Console.WriteLine("Received: " + value);
  public void OnCompleted() => Console.WriteLine("Completed");
  public void OnError(Exception error) => Console.WriteLine("Error: " + error);
}